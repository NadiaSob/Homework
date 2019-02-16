using System;

namespace hw1._3
{
    class Program
    {
        private static void quickSort(int[] array, int first, int last)
        {
            var left = first;
            var right = last;
            var pivot = array[first];
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    ++left;
                }
                while (array[right] > pivot)
                {
                    --right;
                }
                if (left <= right)
                {
                    var temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    ++left;
                    --right;
                }
            }
            if (first < right)
            {
                quickSort(array, first, right);
            }
            if (last > left)
            {
                quickSort(array, left, last);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            var size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the array");
            var array = new int[size];
            var tempString = Console.ReadLine();
            string[] temp = tempString.Split(' ');
            for (var i = 0; i < size; ++i)
            {
                array[i] = int.Parse(temp[i]);
            }

            quickSort(array, 0, size - 1);

            Console.WriteLine("Sorted array:");
            foreach (var element in array)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
