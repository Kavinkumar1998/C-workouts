using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Singleton
{
    class Logger
    {
        public static Logger instance;

        private Logger()
        {
            Console.WriteLine("Private Constructor is Called");
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }

        public static Logger CreateInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
                return instance;
            }

            return instance;
        }
    }

    internal class TaskSingleton
    {
        public static void Main()
        {
           
            Console.WriteLine("Enter first log message:");
            string msg1 = Console.ReadLine();
            Console.WriteLine("Enter second log message:");
            string msg2 = Console.ReadLine();
            Console.WriteLine("Enter third log message:");
            string msg3 = Console.ReadLine();

            Logger logger1 = Logger.CreateInstance();
            Logger logger2 = Logger.CreateInstance();

         
            logger1.Log(msg1);
            logger2.Log(msg2);
            logger1.Log(msg3);

            bool same = object.ReferenceEquals(logger1, logger2);
            Console.WriteLine($"Are logger1 and logger2 the same object? {same}");
        }
    }
}
