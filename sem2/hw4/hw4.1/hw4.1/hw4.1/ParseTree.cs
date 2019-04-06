using System;

namespace hw4._1
{
    /// <summary>
    /// Data structure that finds the result of the given expression.
    /// </summary>
    public class ParseTree
    {
        /// <summary>
        /// Root of the parse tree.
        /// </summary>
        private readonly Node root;

        private readonly string[] expression;

        /// <summary>
        /// Creates new parse tree.
        /// </summary>
        /// <param name="expression">The expression to calculate.</param>
        public ParseTree(string expression)
        {
            if (expression == "")
            {
                throw new FormatException("The expression was not entered.");
            }

            this.expression = expression.Split(' ', '(', ')');
            var index = 0;
            Add(ref root, ref index);
        }

        private void Add(ref Node current, ref int index)
        {
            while (expression[index] == "")
            {
                ++index;
            }

            if (Int32.TryParse(expression[index], out int number))
            {
                current = new Operand(number);
                ++index;
            }
            else
            {
                switch (expression[index])
                {
                    case "+":
                        current = new Addition();
                        break;

                    case "-":
                        current = new Subtraction();
                        break;

                    case "*":
                        current = new Multiplication();
                        break;

                    case "/":
                        current = new Division();
                        break;

                    default:
                        throw new FormatException("Input expression is incorrect.");
                }
                ++index;
                Node node1 = current.LeftChild;
                Node node2 = current.RightChild;

                Add(ref node1, ref index);
                current.LeftChild = node1;

                Add(ref node2, ref index);
                current.RightChild = node2;
            }
        }

        /// <summary>
        /// Prints the expression by traversing the tree.
        /// </summary>
        public void PrintTree()
        {
            RecursivePrintTree(root);
        }

        private void RecursivePrintTree(Node current)
        {
            string symbol = current.Symbol();
            if (Int32.TryParse(symbol, out int number))
            {
                current.Print();
            }
            else
            {
                Console.Write("(");
                current.Print();
                Console.Write(" ");
                RecursivePrintTree(current.LeftChild);
                Console.Write(" ");
                RecursivePrintTree(current.RightChild);
                Console.Write(")");
            }
        }

        public int Result() => root.Data();
    }
}
