# MyRecipe - Шаблон сервиса
Готовый шаблон сервиса, из которого можно создавать новые сервисы и модифицировать их под свои нужды.

## Переименование проектов и неймспейсов при использовании шаблона
В решении присутствует файл **rename-backend-template.py**, при помощи которого можно переименовать все проекты и все наименования в коде под названия нового сервиса.
Для этого необходимо открыть этот файл в тестовом редакторе и в переменные **newProjectName** и **newProjectNamespace** добавить новые названия, в соответствии с новым именем сервиса.
После этого исполняем этот файл от имени администратора и скрипт обновить все названия. После того, как файл отработает, скрипт можно будет удалять, чтобы он не засорял репозиторий сервиса. Дополнительно нужно будет удалить файл, указанный в переменной **scriptLockFile**, на текущий момент это **lock-rename-backend-template**. Этот файл нужен исключительно для блокировки повторного использования скрипта обновления названий.

