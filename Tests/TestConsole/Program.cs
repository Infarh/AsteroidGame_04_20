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

            combine_log.LogInformation("Message1");
            combine_log.LogWarning("Info message");
            combine_log.LogError("Error message");

            Student student = new Student { Name = "Иванов" };

            ILogger log = combine_log;
            ComputeLongDataValue(100, student);

            Console.WriteLine("Программа завершена!");
            //Console.ReadLine();

            using (var file_logger = new TextFileLogger("another.log"))
            {
                file_logger.LogInformation("123");
            }

            combine_log.Flush();
        }

        private static double ComputeLongDataValue(int Count, ILogger Log)
        {
            var result = 0;
            for (var i = 0; i < Count; i++)
            {
                result++;
                Log.Log($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(100);
            }

            return result;
        }
    }
}
