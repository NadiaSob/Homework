using System;

namespace hw1._1
{
    class Program
    {
        private static int Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Factorial of {number} is {Factorial(number)}");
        }
    }
}
