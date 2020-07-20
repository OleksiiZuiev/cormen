using System;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new [] { 31, 41, 59, 26, 41, 58};
            InsertionSortDesc(array);
            Console.WriteLine(string.Join(",", array));
        }

        // 2.1-2
        static void InsertionSortDesc(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;
                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        // 2.1-3
        static int? LinearSearch(int[] input, int key)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == key) return i;
            }
            
            //loop invariant
                // At start of each iteration, subarray A[0..i] doesn't contain key, or i = result
                //initizializaiton A[0..-1] trivially doesn't have key
                //maintenance:
                    //if A[0..i] doesn't have key,  and A[i+1] is not a key, A[i+1] doesn't have key
                    //if A[0..i] doesn't have key, and i+1 is key, invariant holds
                    // if is key, loop terminates, and there is no next itertion
        }

        // 2.1 - 4
        static int[] SumBinary(int[] a, int[] b)
        {
            //input: 2 arrays of binary integers of size n
            //output: array of size n+1 countaining sum of binary integers in a and b

            var c = new int[a.Length + 1];
            var reminder = 0;
            for (var i = a.Length - 1; i >= 0; i--)
            {
                var current = reminder + a[i] + b[i];
                c[i] = current % 2;
                reminder = current / 2;
            }

            c[0] = reminder;
        }
    }
}