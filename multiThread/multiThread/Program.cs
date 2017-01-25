using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using multiThread.work;
using System.Diagnostics;
using System.Threading.Tasks;

namespace multiThread
{
    public class Program
    {
        public const int num = 1000;
        static void Main(string[] args)
        {
            Task<string> task = Task.Run<string>(()=>PiCalculator.Calculate(10));
            Task faultedTask = task.ContinueWith((antecedentTask)=> { Trace.Assert(task.IsFaulted);Console.WriteLine("Task State: Faulted"); },TaskContinuationOptions.OnlyOnFaulted);
            Task canceledTask = task.ContinueWith((antecedentTask)=> { Trace.Assert(task.IsCanceled);Console.WriteLine("Task State: Canceled"); },TaskContinuationOptions.OnlyOnCanceled);
            Task completedTask = task.ContinueWith((antecedentTask) => { Trace.Assert(task.IsCompleted); Console.WriteLine("Task State: Completed"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
            Console.ReadKey();
        }
        public static void doWork()
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write('=');
            }
        }

        public void sample1()
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
            Trace.Assert(task.IsCompleted);
            Console.ReadKey();
        }
    }
}
