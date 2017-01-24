using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiThread.work
{
    public class DoWork
    {
        public static void work1(object arg)
        {
            int num = (int)arg;
            for (int i = 0; i <num; i++)
            {
                Console.Write('+');
            }
        }
        public static void work2(object arg)
        {
            int num = (int)arg;
            for (int i = 0; i < num; i++)
            {
                Console.Write('=');
            }
        }
    }
}
