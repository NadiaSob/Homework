using System;

namespace hw1._5
{
    class Program
    {
        private static int[,] ArrayFilling(int length, int height)
        {
            var randomArray = new int[height, length];
            var rand = new Random();
            for (var i = 0; i < height; ++i)
            {
                for (var j = 0; j < length; ++j)
                {
                    randomArray[i, j] = rand.Next(0, 30);
                }
            }
            return randomArray;
        }

        private static void ArrayPrinting(int[,] array)
        {
            var height = array.GetLength(0);
            var length = array.GetLength(1);
            for (var i = 0; i < height; ++i)
            {
                for (var j = 0; j < length; ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void QuickSort(int[,] array, int first, int last)
        {
            var height = array.GetLength(0);
            var left = first;
            var right = last;
            var pivot = array[0, first];
            while (left <= right)
            {
                while (array[0, left] < pivot)
                {
                    ++left;
                }
                while (array[0, right] > pivot)
                {
                    --right;
                }
                if (left <= right)
                {
                    for (var i = 0; i < height; ++i)
                    {
                        var temp = array[i, left];
                        array[i, left] = array[i, right];
                        array[i, right] = temp;
                    }
                    ++left;
                    --right;
                }
            }
            if (first < right)
            {
                QuickSort(array, first, right);
            }
            if (last > left)
            {
                QuickSort(array, left, last);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the array");
            var length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the height of the array");
            var height = int.Parse(Console.ReadLine());

            var array = ArrayFilling(length, height);

            Console.WriteLine("The array:");
            ArrayPrinting(array);

            QuickSort(array, 0, length - 1);
            Console.WriteLine("Sorted array:");
            ArrayPrinting(array);
        }
    }
}