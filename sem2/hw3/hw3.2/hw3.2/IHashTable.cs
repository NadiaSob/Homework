using System;

namespace hw3._2
{
    /// <summary>
    /// Hash table, data structure that is used to store keys/value pairs.
    /// </summary>
    public interface IHashTable
    {
        /// <summary>
        /// Number of elements in hash table.
        /// </summary>
        int NumberOfElements { get; }

        /// <summary>
        /// Checks if the given hash table element exists.
        /// </summary>
        /// <param name="data">Element to check.</param>
        /// <returns>True if the hash table element is found, else false.</returns>
        bool Exists(string data);

        /// <summary>
        /// Adds new element in hash table.
        /// </summary>
        /// <param name="data">Element to add.</param>
        /// <returns>True if the element is added successfully, false if it already exists.</returns>
        bool Add(string data);

        /// <summary>
        /// Deletes element from hash table.
        /// </summary>
        /// <param name="data">Element to delete.</param>
        /// <returns>True if the element is deleted successfully, false if it is not found.</returns>
        bool Delete(string data);

        /// <summary>
        /// Prints hash table.
        /// </summary>
        void Print();
    }
}