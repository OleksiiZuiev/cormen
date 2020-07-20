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
    }
}