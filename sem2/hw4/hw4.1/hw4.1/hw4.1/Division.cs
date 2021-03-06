﻿using System;

namespace hw4._1
{
    /// <summary>
    /// Operation of division.
    /// </summary>
    class Division : Operation
    {
        /// <summary>
        /// Calculates the operation of division.
        /// </summary>
        /// <returns>Result of the division.</returns>
        public override int Data() => LeftChild.Data() / RightChild.Data();

        /// <summary>
        /// Returns the symbol of division.
        /// </summary>
        /// <returns>The symbol of division.</returns>
        public override string Symbol() => "/";
    }
}
