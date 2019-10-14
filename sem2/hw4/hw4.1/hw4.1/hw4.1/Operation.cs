using System;

namespace hw4._1
{
    abstract public class Operation : Node
    {
        /// <summary>
        /// Left child of the node.
        /// </summary>
        public Node LeftChild { get; set; }

        /// <summary>
        /// Right child of the node.
        /// </summary>
        public Node RightChild { get; set; }

        /// <summary>
        /// Prints the operation and it left and right child in correct form.
        /// </summary>
        public override void Print()
        {
            Console.Write("(");
            Console.Write(Symbol());
            Console.Write(" ");
            LeftChild.Print();
            Console.Write(" ");
            RightChild.Print();
            Console.Write(")");
        }
    }
}
