using System;
using System.Diagnostics;

namespace Chapter1Excercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.2-2
            var n = ConvergesAt(2, x => 64 * x * Math.Log(x), x => 8 * x * x);
            Console.WriteLine($"Coverges at {n}");
            
            //1.2-3
            n = ConvergesAt(1, x => 100 * x * x, x => Math.Pow(2, x));
            Console.WriteLine($"Coverges at {n}");
        }

        private static int ConvergesAt(int startN, Func<int, double> f1, Func<int, double> f2)
        {
            var n = startN;
            var initiallyF1Greater = f1(n) > f2(n);

            bool f1Greater;
            do
            {
                n++;
                f1Greater = f1(n) > f2(n);
            } while (f1Greater == initiallyF1Greater);

            return n;
        }
    }
}