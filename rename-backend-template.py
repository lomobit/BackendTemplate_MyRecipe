#!/usr/bin/env python3

import io
import os
import re
import ctypes
import shutil

# Конфигурация
##############################################################

scriptStartPoint: str = "."
scriptLockFile: str = "lock-rename-backend-template"
gitFolder: str = ".git"

# Замена имени переменных, методов, строк подключения и т.д.
oldProjectName: str = "MyRecipe"
newProjectName: str = "FileService"

# Замена имени названий проектов, вложенных папок и неймспейсов
oldProjectNamespace: str = "MyRecipe"
newProjectNamespace: str = "MyRecipe.FileService"

# Указываем файлы, которые мы не будем обрабатывать
filesToIgnore: list = [
	".dockerignore",
	"Dockerfile",
	scriptLockFile,
	os.path.basename(__file__) # Имя текущего скрипта
]

# Указываем папки, которые мы будем удалять
directoriesToRemove: list = [
	"bin",
	"obj",
	".vs",
	".idea"
]


# Определение функций
##############################################################

def isRegexMatch(regexTempalte: str, row: str) -> bool:
	regexMatch: SRE_Match = re.match(regexTempalte, row)
	if regexMatch is not None:
		#print(regexMatch.group(0))
		return True
	
	return False

def isNamespace(rowFile: str) -> bool:
	return isRegexMatch(r'.*' + oldProjectNamespace + '\.', rowFile)

def isLoggingNamespace(rowFile: str) -> bool:
	return isRegexMatch(r'.*' + oldProjectNamespace + 'Logging\.', rowFile)

def changeNameInFiles(filesToChange: list):
	for file in filesToChange:
		if not os.path.exists(file):
			continue

		resultFileContent: str = ''

		try:
			with io.open(file, 'r', encoding="utf-8-sig") as fp:
				for line in fp:
					if isNamespace(line) or isLoggingNamespace(line):
						resultFileContent += line.replace(oldProjectNamespace, newProjectNamespace)
					else:
						resultFileContent += line.replace(oldProjectName, newProjectName)
			
			with io.open(file, 'w', encoding="utf-8-sig") as fp:
				fp.write(resultFileContent)
		except UnicodeDecodeError as e:
			continue

def changeFileNames(filesToChange: list):
	for file in filesToChange:
		if not os.path.exists(file):
			continue

		fileName = os.path.basename(file)
		fileFolder = os.path.dirname(file)

		if isNamespace(fileName) or isLoggingNamespace(fileName):
			os.rename(file, os.path.join(fileFolder, fileName.replace(oldProjectNamespace, newProjectNamespace)))
		else:
			os.rename(file, os.path.join(fileFolder, fileName.replace(oldProjectName, newProjectName)))

def changeDirectoriesNames(directoriesToChange: list):
	# Здесь важно идти с конца списка, иначе вложенные папки в итоге не будут переименованы
	directory: str = ''
	for i in range(len(directoriesToChange)-1, -1, -1):
		directory = directoriesToChange[i]
		if directory == scriptStartPoint or not os.path.exists(directory):
			continue

		folderName = os.path.basename(directory)
		rootFolder = os.path.dirname(directory)

		if isNamespace(folderName) or isLoggingNamespace(folderName):
			os.rename(directory, os.path.join(rootFolder, folderName.replace(oldProjectNamespace, newProjectNamespace)))
		else:
			os.rename(directory, os.path.join(rootFolder, folderName.replace(oldProjectName, newProjectName)))

def checkFilesAndDirectoriesAvailability(filesToChange: list, directoriesToChange: list) -> bool:
	try:
		for file in filesToChange:
			os.rename(file, file)
	except PermissionError:
		print('Ошибка: Файл "' + file + '" занят другим процессом!')
		return False

	try:
		for directory in directoriesToChange:
			if directory == scriptStartPoint:
				continue

			os.rename(directory, directory)
	except PermissionError:
		print('Ошибка: Папка "' + directory + '" занята другим процессом!')
		return False

	return True

def isAdmin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False

def main():
	if isAdmin():
		print('Запуск: Необходимо запустить скрипт с правами администратора')
		return

	if os.path.exists(scriptLockFile):
		print('Ошибка: переименование уже было произведено. Для повторного переименования проекта необходимо удалить файл "' + scriptLockFile + '".')
		return

	with io.open(scriptLockFile, 'w', encoding="utf-8-sig") as fp:
		fp.write("")

	specificDirectoriesToRemove: list = []
	directoriesToChange: list = []
	filesToChange: list = []

	for root, dirs, files in os.walk(scriptStartPoint):
		directoriesToChange.append(root)
		for dirname in dirs:
			if dirname in directoriesToRemove:
				specificDirectoriesToRemove.append(os.path.join(root, dirname))

		
		for file in files:
			if gitFolder in root or file in filesToIgnore:
				continue
			
			filesToChange.append(os.path.join(root, file))

	if checkFilesAndDirectoriesAvailability(filesToChange, directoriesToChange):
		for dirToRemove in specificDirectoriesToRemove:
			shutil.rmtree(dirToRemove)

		changeNameInFiles(filesToChange)
		changeFileNames(filesToChange)
		changeDirectoriesNames(directoriesToChange)
	else:
		os.remove(scriptLockFile)



# Начало исполнения скрипта
##############################################################

if __name__ == '__main__':
	main()


