using System;

namespace hw1._4
{
    class Program
    {
        private static int[,] ArrayFilling(int size)
        {
            int[,] randomArray = new int[size, size];
            Random rnd = new Random();
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    randomArray[i, j] = rnd.Next(0, 30);
                }
            }
            return randomArray;
        }

        private static void ArrayPrinting(int[,] array)
        {
            var size = array.GetLength(0);
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void ArraySpiralPrinting(int[,] array)
        {
            var size = array.GetLength(0);
            if (size == 1)
            {
                Console.WriteLine(array[0, 0]);
                return;
            }
            var stepLeft = 1;
            var stepDown = 1;
            var stepRight = 2;
            var stepUp = 2;
            var center = size / 2;

            var x = center;
            var y = center;

            Console.Write($"{array[x, y]} ");
            while (y != size - 1)
            {
                for (var i = 1; i <= stepLeft; ++i)
                {
                    Console.Write($"{array[x, y - i]} ");
                }
                y -= stepLeft;
                stepLeft += 2;

                for (var i = 1; i <= stepDown; ++i)
                {
                    Console.Write($"{array[x + i, y]} ");
                }
                x += stepDown;
                stepDown += 2;

                for (var i = 1; i <= stepRight; ++i)
                {
                    Console.Write($"{array[x, y + i]} ");
                }
                y += stepRight;
                stepRight += 2;

                for (var i = 1; i <= stepUp; ++i)
                {
                    Console.Write($"{array[x - i, y]} ");
                }
                x -= stepUp;
                stepUp += 2;
            }
            for (var i = 1; i <= size - 1; ++i)
            {
                Console.Write($"{array[x, y - i]} ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            var size = int.Parse(Console.ReadLine());

            if (size % 2 == 0)
            {
                Console.WriteLine("Size should be an odd number");
                return;
            }
            if (size <= 0)
            {
                Console.WriteLine("Size should be a positive number");
                return;
            }

            int[,] array = ArrayFilling(size);

            Console.WriteLine("The array:");
            ArrayPrinting(array);

            Console.WriteLine("Spirally printed: ");
            ArraySpiralPrinting(array);
        }
    }
}
