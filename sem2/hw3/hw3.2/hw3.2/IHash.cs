using System;

namespace hw3._2
{
    /// <summary>
    /// Hash function.
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Calculates hash for string values.
        /// </summary>
        /// <param name="data">Value to calculate hash of.</param>
        /// <returns>Hash of the given value.</returns>
        uint GetHash(string data);
    }
}
