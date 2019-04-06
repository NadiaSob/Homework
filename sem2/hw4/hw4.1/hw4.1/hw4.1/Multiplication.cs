using System;

namespace hw4._1
{
    /// <summary>
    /// Operation of multiplication.
    /// </summary>
    class Multiplication : Node
    {
        /// <summary>
        /// Calculates the operation of multiplication.
        /// </summary>
        /// <returns>Result of the multiplication.</returns>
        public override int Data() => LeftChild.Data() * RightChild.Data();

        /// <summary>
        /// Returns the symbol of multiplication.
        /// </summary>
        /// <returns>The symbol of multiplication.</returns>
        public override string Symbol() => "*";
    }
}
