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
            //Logger log = new TraceLogger();

            Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            CombineLogger combine_log = new CombineLogger();
            combine_log.Add(new ConsoleLogger());
            combine_log.Add(new DebugOutputLogger());
            combine_log.Add(new TraceLogger());
            combine_log.Add(new TextFileLogger("new_log.log"));

            ILogger log = combine_log;
            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");


            ComputeLongDataValue(100, log);

            Console.WriteLine("Программа завершена!");
            Console.ReadLine();

            combine_log.Flush();
        }

        private static double ComputeLongDataValue(int Count, ILogger Log)
        {
            var result = 0;
            for (var i = 0; i < Count; i++)
            {
                result++;
                Log.LogInformation($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(100);
            }

            return result;
        }
    }
}
