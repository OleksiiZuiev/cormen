using System;
using System.Diagnostics;
using System.Linq;

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
            
            //1-1
            RunningTimeComparison();
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

        private static void RunningTimeComparison()
        {
            (double microseconds, string name)[] intervals = new (double microseconds, string name)[]
            {
                (microseconds: 1_000_000 * 1, name: "1 second"), 
                (microseconds: 1_000_000 * 60, name: "1 minute"), 
                (microseconds: 1_000_000.0 * 60 * 60, "1 hour"), 
                (microseconds: 1_000_000.0 * 60 * 60 * 24, "1 day"),
                (microseconds: 1_000_000.0 * 60 * 60 * 24 * 30.438, "1 month"),
                (microseconds: 1_000_000.0 * 60 * 60 * 24 * 365.25, "1 year"),
                (microseconds: 1_000_000.0 * 60 * 60 * 24 * 365.25 * 100, "1 century")
            };

            (Func<double, double> func, string name)[] functions = new(Func<double, double> func, string name)[]
            {
                (func: x => x * Math.Log(x), "n * ln(n)"),
                (func: x => x * x, "n ^ 2"),
                (func: x => x * x * x, "n ^ 3"),
                (func: x => Math.Pow(2, x), "2 ^ n"),
                (func: x => Factorial((int)x), "n!")
            };
            
            //for lg n - e ^ microseconds
            //for sqrt(n) - n ^ 2


            foreach (var function in functions)
            {
                double n = 1;
                int currentInterval = 0;
                while (currentInterval < intervals.Length)
                {
                    var nMicroseconds = function.func(n);
                    if (nMicroseconds > intervals[currentInterval].microseconds)
                    {
                        Console.WriteLine($"Function {function.name} can perform {n-1} operations within {intervals[currentInterval].name}");
                        currentInterval++;
                    }

                    n += 1000;
                }
            }
        }

        static double Factorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}