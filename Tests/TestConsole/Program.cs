using System;
using System.Globalization;
using TestConsole.Loggers;
using System.Diagnostics;
using System.Runtime.Serialization;

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
            //ComputeLongDataValue(100, student);

            //Console.WriteLine("Программа завершена!");
            ////Console.ReadLine();

            //using (var file_logger = new TextFileLogger("another.log"))
            //{
            //    file_logger.LogInformation("123");
            //}

            try
            {
                ComputeLongDataValue(600, log);
            }
            catch (ArgumentNullException error)
            {
                combine_log.LogError(error.ToString());
                combine_log.LogError(error.Message);
                throw new ComputeExceptionException("Ошибка в значении входного параметра", error);

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Число итераций слишком велико!");
                throw;
            }
            catch (Exception error)
            {
                combine_log.LogError(error.ToString());
                combine_log.LogError(error.Message);
                throw new ComputeExceptionException("Произошла неизвестная ошибка при вычислении", error);
            }


            combine_log.Flush();
        }

        private static double ComputeLongDataValue(int Count, ILogger Log)
        {
            if(Log is null)
                //throw new ArgumentNullException("Log");
                throw new ArgumentNullException(nameof(Log));

            if(Count <= 0)
                throw new ArgumentOutOfRangeException(nameof(Count), Count, "Число итераций обязано быть больше нуля!");

            var result = 0;
            for (var i = 0; i < Count; i++)
            {
                result++;
                Log.Log($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(10);

                if(i > 500)
                    throw new InvalidOperationException("Число итераций оказалось слишком большим!",
                        new ArgumentException($"Число итераций было указано больше 500 и равно {Count}", nameof(Count)));
            }

            return result;
        }
    }

    [Serializable]
    public class ComputeExceptionException : ApplicationException
    {
        public ComputeExceptionException() { }
        public ComputeExceptionException(string message) : base(message) { }
        public ComputeExceptionException(string message, Exception inner) : base(message, inner) { }

        protected ComputeExceptionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
