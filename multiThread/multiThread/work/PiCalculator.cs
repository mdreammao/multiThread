using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiThread.work
{
    public class PiCalculator
    {
        public static string Calculate(int digits=100)
        {
            string piString;
            int num = 0;
            double sum = 0;
            int[] pi = new int[100000];
            for (int i = 1; i <= 100000; i++)
            {
                sum += Math.Log((2 * i + 1) / i);
                if (sum>digits+1)
                {
                    num = i;
                    break;
                }
            }
            pi[0] = 1;
            for (int j = num; j >=1; j--)
            {
                multiplication(ref pi, j);
                division(ref pi, 2*j+1);
                pi[0] += 1;
            }
            multiplication(ref pi, 2);
            piString = pi[0].ToString() + ".";
            for (int i = 1; i <= digits; i++)
            {
                piString += pi[i].ToString();
            }
            return piString;
        }
        private static void multiplication(ref int[] result,int n)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i] * n;
            }
            for (int i=result.Length-1;  i>=1; i--)
            {
                result[i - 1] += result[i] / 10;
                result[i] = result[i] % 10;
            }
        }

        private static void division(ref int[] result,int n)
        {
            for (int i = 0; i < result.Length-1; i++)
            {
                result[i + 1] += result[i] % n * 10;
                result[i] = result[i] / n;
            }
            result[result.Length - 1] /= n;
        }
    }
}
