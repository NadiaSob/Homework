using System;

namespace hw4._1
{
    /// <summary>
    /// Operation of addition.
    /// </summary>
    class Addition : Operation
    {
        /// <summary>
        /// Calculates the operation of addition
        /// </summary>
        /// <returns>Result of the calculation.</returns>
        public override int Data() => LeftChild.Data() + RightChild.Data();

        /// <summary>
        /// Returns the symbol of addition.
        /// </summary>
        /// <returns>The symbol of addition.</returns>
        public override string Symbol() => "+";
    }
}
