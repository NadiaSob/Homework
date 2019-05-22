using System;

namespace homework
{
    /// <summary>
    /// Class that do calculating operation with two numbers. 
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Do the operation with two numbers.
        /// </summary>
        /// <param name="operation">Symbol of the operation.</param>
        /// <param name="firstNumber">First number of the expression.</param>
        /// <param name="secondNumber">Second number of the expression.</param>
        /// <returns>Result of the operation.</returns>
        public static double Calculate(string operation, double firstNumber, double secondNumber)
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
