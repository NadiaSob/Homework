using System;
using System.IO;

namespace hw4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            using (StreamReader streamReader = new StreamReader("..\\..\\InputExpression.txt"))
            {
                expression = streamReader.ReadToEnd();
            }
            var parseTree = new ParseTree(expression);

            Console.WriteLine("The expression:");
            parseTree.PrintTree();

            Console.WriteLine();
            Console.WriteLine("The result:");
            Console.WriteLine(parseTree.Result());
        }
    }
}
