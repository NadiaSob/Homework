using System;

namespace hw3._2
{
    /// <summary>
    /// Calculates hash for string values using PJW hash function.
    /// </summary>
    public class PJWHash : IHash
    {
        /// <summary>
        /// PJW hash function.
        /// </summary>
        /// <param name="data">Value to calculate hash of.</param>
        /// <returns>Hash of the given value.</returns>
        public uint GetHash(string data)
        {
            uint hash = 0;
            uint test;

            foreach (uint character in data)
            {
                hash = (hash << 4) + character;

                test = hash & 0xF0000000;
                if (test != 0)
                {
                    hash = (hash ^ (test >> 24)) & (0xFFFFFFF);
                }
            }
            return hash;
        }
    }
}
