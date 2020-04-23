using System;
using System.Globalization;
using TestConsole.Loggers;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            //Logger log = new DebugOutputLogger();
            Logger log = new TraceLogger();

            Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");

            log.Flush();

            //Console.ReadLine();
        }
    }
}
