using System;

namespace hw4._2
{
    /// <summary>
    /// Operation of subtraction.
    /// </summary>
    class Subtraction : Node
    {
        /// <summary>
        /// Calculates the operation of subtraction.
        /// </summary>
        /// <returns>Result of the calculation.</returns>
        public override int Data() => LeftChild.Data() - RightChild.Data();

        /// <summary>
        /// Returns the symbol of subtraction.
        /// </summary>
        /// <returns>The symbol of subtraction.</returns>
        public override string Symbol() => "-";
    }
}
