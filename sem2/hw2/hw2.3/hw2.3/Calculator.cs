using System;

namespace hw2._3
{
    /// <summary>
    /// Class that finds the result of the given expression in postfix form.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// The expression to calculate.
        /// </summary>
        public string Expression { get; private set; }

        /// <summary>
        /// Creates new calculator.
        /// </summary>
        /// <param name="expression">Expression to calculate.</param>
        public Calculator(string expression)
        {
            Expression = expression;
        }

        private int DoTheOperation(string sign, int firstNum, int secondNum)
        {
            switch (sign)
            {
                case "+":
                    return firstNum + secondNum;
                case "-":
                    return firstNum - secondNum;
                case "*":
                    return firstNum * secondNum;
                case "/":
                    return firstNum / secondNum;
                default:
                    return ' ';
            }
        }

        /// <summary>
        /// Calculates the expression given in postfix.
        /// </summary>
        /// <returns>Result of calculation.</returns>
        public int Calculate(IStack stack)
        {
            string[] expression =  Expression.Split(' ');

            foreach (var symbol in expression)
            {
                if (Int32.TryParse(symbol, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    int firstNumber;
                    int secondNumber;

                    if (!stack.IsEmpty())
                    {
                        secondNumber = stack.Pop();
                    }
                    else
                    {
                        throw new FormatException("The expression is entered incorrectly");
                    }

                    if (!stack.IsEmpty())
                    {
                        firstNumber = stack.Pop();
                    }
                    else
                    {
                        throw new FormatException("The expression is entered incorrectly");
                    }

                    int newNumber = DoTheOperation(symbol, firstNumber, secondNumber);
                    if (newNumber != ' ')
                    {
                        stack.Push(newNumber);
                    }
                    else
                    {
                        throw new FormatException("The expression is entered incorrectly");
                    }
                }
            }
            return stack.Pop();
        }
    }
}
