using System;
using System.Globalization;
using TestConsole.Loggers;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            Logger log = new DebugOutputLogger();

            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");

            log.Flush();

            Console.ReadLine();
        }
    }
}
