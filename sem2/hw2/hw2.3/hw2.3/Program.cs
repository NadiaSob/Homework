using System;

namespace hw2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the expression in postfix form");
            Console.WriteLine("Each number and operator must be separated by spaces");
            var expression = Console.ReadLine();

            Console.WriteLine("Enter:");
            Console.WriteLine("0 - to use array stack");
            Console.WriteLine("1 - to use list stack");
            var command = int.Parse(Console.ReadLine());

            var calculation = new Calculator(expression);
            int result;

            if (command == 0)
            {
                var stack = new ArrayStack();
                result = calculation.Calculation(stack);
            }
            else if (command == 1)
            {
                var stack = new ListStack();
                result = calculation.Calculation(stack);
            }
            else
            {
                Console.WriteLine("Command you entered is incorrect");
                return;
            }

            Console.WriteLine($"The result of calculation is {result}");

        }
    }
}
