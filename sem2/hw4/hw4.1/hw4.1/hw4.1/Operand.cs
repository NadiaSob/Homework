using System;

namespace hw4._1
{
    /// <summary>
    /// Operand of the expression.
    /// </summary>
    class Operand : Node
    {
        private readonly int data;

        /// <summary>
        /// Creates new operand.
        /// </summary>
        /// <param name="data"></param>
        public Operand(int data)
        {
            this.data = data;
        }

        /// <summary>
        /// Returns the operand.
        /// </summary>
        /// <returns>The operand.</returns>
        public override int Data() => data;

        /// <summary>
        /// Returns the operand in string.
        /// </summary>
        /// <returns>The operand in string</returns>
        public override string Symbol() => data.ToString();
    }
}
