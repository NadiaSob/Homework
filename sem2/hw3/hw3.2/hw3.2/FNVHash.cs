using System;

namespace hw3._2
{
    /// <summary>
    /// Calculates hash for string values using FNV hash function.
    /// </summary>
    public class FNVHash : IHash
    {
        private const uint fnvPrime = 16777619;
        private const uint offsetBasis = 2166136261;

        /// <summary>
        /// FNV hash function.
        /// </summary>
        /// <param name="data">Value to calculate hash of.</param>
        /// <returns>Hash of the given value.</returns>
        public uint GetHash(string data)
        {
            uint hash = offsetBasis;
            foreach (uint character in data)
            {
                hash *= fnvPrime;
                hash ^= character;
            }

            return hash;
        }
    }
}
