using System;

namespace hw2._3
{
    /// <summary>
    /// Methods to find the result of the given expression in postfix.
    /// </summary>
    public class Calculation : ICalculation
    {
        /// <summary>
        /// The expression to calculate.
        /// </summary>
        public string Expression { get; set; }

        public Calculation(string expression)
        {
            Expression = expression;
        }

        private Stack stack = new Stack();

        private int Operation(char sign, int firstNum, int secondNum)
        {
            switch (sign)
            {
                case '+':
                    return firstNum + secondNum;
                case '-':
                    return firstNum - secondNum;
                case '*':
                    return firstNum * secondNum;
                case '/':
                    if (secondNum != 0)
                    {
                        return firstNum / secondNum;
                    }
                    else
                    {
                        Console.WriteLine("There is a division by 0!");
                        return 1;
                    }
                default:
                    return ' ';
            }
        }

        private bool IsDigit(char symbol) => symbol <= '9' && symbol >= '0';

        private int CharToInt(char digit) => digit - '0';

        /// <summary>
        /// Calculates the expression given in postfix.
        /// </summary>
        /// <returns>Result of calculation.</returns>
        public int CalculationProcess()
        {
            for (var i = 0; i < Expression.Length; ++i)
            {
                if (IsDigit(Expression[i]))
                {
                    stack.Push(CharToInt(Expression[i]));
                }
                else
                {
                    int secondNumber = stack.Pop();
                    int firstNumber = stack.Pop();

                    int newNumber = Operation(Expression[i], firstNumber, secondNumber);
                    stack.Push(newNumber);
                }
            }

            return stack.Pop();
        }
    }
}
