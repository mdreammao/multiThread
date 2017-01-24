using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using multiThread.work;
using System.Threading.Tasks;

namespace multiThread
{
    public class Program
    {
        public const int num = 1000;
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(() => PiCalculator.Calculate(1000));
            foreach (char busySymbol in Utility.BusySymbols())
            {
                if (task.IsCompleted)
                {
                    Console.Write('\b');
                    break;
                }
                Console.Write(busySymbol);
            }
            Console.WriteLine();
            Console.WriteLine(task.Result);
            System.Diagnostics.Trace.Assert(task.IsCompleted);
            Console.ReadKey();
        }
        public static void doWork()
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write('=');
            }
        }
    }
}
