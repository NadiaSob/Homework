using System;

namespace hw4._1
{
    /// <summary>
    /// Parse tree's node that keeps the element of the expression.
    /// </summary>
    abstract public class Node
    {
        /// <summary>
        /// Element of the node.
        /// </summary>
        /// <returns></returns>
        public abstract string Symbol();

        /// <summary>
        /// Returns operand or calculates the result of the operation which is kept in the node.
        /// </summary>
        /// <returns>The operand or the result of the operation which is kept in the node.</returns>
        public abstract int Data();

        /// <summary>
        /// Prints the element of the node.
        /// </summary>
        public abstract void Print();
    }
}
