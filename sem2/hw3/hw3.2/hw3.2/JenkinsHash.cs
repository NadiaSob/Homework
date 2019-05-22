using System;

namespace hw3._2
{
    /// <summary>
    /// Calculates hash for string values using Jenkins hash function.
    /// </summary>
    public class JenkinsHash : IHash
    {
        /// <summary>
        /// Jenkins hash function.
        /// </summary>
        /// <param name="data">Value to calculate hash of.</param>
        /// <returns>Hash of the given value.</returns>
        public uint GetHash(string data)
        {
            uint hash = 0;

            foreach (uint character in data)
            {
                hash += character;
                hash += hash << 10;
                hash ^= hash >> 6;
            }
            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }
    }
}
