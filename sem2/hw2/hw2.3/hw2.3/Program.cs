using System;

namespace hw2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the expression in postfix form without spaces");

            var expression = Console.ReadLine();

            var calculation = new Calculation(expression);
            Console.WriteLine($"The result of calculation is {calculation.CalculationProcess()}");

        }
    }
}
