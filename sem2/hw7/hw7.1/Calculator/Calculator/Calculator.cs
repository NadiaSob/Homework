using System;

namespace homework
{
    public class Calculator
    {
        public double Calculate(string operation, double firstNumber, double secondNumber)
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                default:
                    throw new FormatException("Invalid symbol");
            }
        }
    }
}
