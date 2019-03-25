using System;

namespace hw1._2
{
    class Program
    {
        private static int Fibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }
            else
            {
                var firstNum = 0;
                var secondNum = 1;
                var thirdNum = 1;
                for (var i = 2; i < number; ++i)
                {
                    firstNum = secondNum;
                    secondNum = thirdNum;
                    thirdNum = firstNum + secondNum;
                }
                return thirdNum;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the position of Fibonacci series element");
            var position = int.Parse(Console.ReadLine());

            if (position <= 0)
            {
                Console.WriteLine("You entered a non-positive number");
                return;
            }

            Console.WriteLine($"Fibonacci series up to the element on position {position}:");
            for (var i = 0; i < position; ++i)
            {
                Console.Write($"{Fibonacci(i)} ");
            }
        }
    }
}
