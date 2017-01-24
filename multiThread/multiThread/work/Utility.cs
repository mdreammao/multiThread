using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiThread.work
{
    public class Utility
    {
        public static IEnumerable<char> BusySymbols()
        {
            string busySymbols = @"-\|/-\|/";
            int next = 0;
            while(true)
            {
                yield return busySymbols[next]; //想迭代器返回数据，生成数据就返回，不用等所有数据都生成好，最后返回。
                next = (next + 1) % busySymbols.Length;
                yield return '\b';
            }
        }
    }
}
