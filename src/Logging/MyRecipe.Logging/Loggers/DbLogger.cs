
using Microsoft.Extensions.Logging;

namespace MyRecipe.Logging.Loggers
{
    public class DbLogger : ILogger, IDisposable
    {
        public DbLogger()
        {

        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine(formatter(state, exception) + Environment.NewLine);
        }

        public void Dispose()
        {
        }
    }
}
