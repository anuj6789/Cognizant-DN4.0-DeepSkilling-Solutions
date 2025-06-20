using System;

namespace Singletonpattern
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private Logger()
        {
            Console.WriteLine("Logger instance created");
        }

       
        public static Logger Instance => instance.Value;

       
        public void Log(string message)
        {
            Console.WriteLine($"[LOG {DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
