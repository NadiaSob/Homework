using System;

namespace hw3._2
{
    /// <summary>
    /// List interface.
    /// </summary>
    interface IList
    {
        /// <summary>
        /// Number of elements in list.
        /// </summary>
        uint Size { get; }

        /// <summary>
        /// Checks if the list has no elements in it.
        /// </summary>
        /// <returns>True if the list is empty, else false.</returns>
        bool IsEmpty();

        /// <summary>
        /// Adds new element in list by its position.
        /// </summary>
        /// <param name="position">Position of the element to add.</param>
        /// <param name="data">Element to add.</param>
        /// <returns>True if the element is added, false if the given position is incorrect.</returns>
        bool AddElement(uint position, string data);

        /// <summary>
        /// Deletes an element from the list by its position.
        /// </summary>
        /// <param name="position">Position of the element to delete.</param>
        /// <returns>True if the element is deleted, false if the given position is incorrect.</returns>
        bool DeleteElementByPosition(uint position);

        /// <summary>
        /// Deletes an element from the list by its data.
        /// </summary>
        /// <param name="data">Data of the element to delete.</param>
        void DeleteElementByData(string data);

        /// <summary>
        /// Gets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <returns>Data of the element.</returns>
        string GetData(uint position);

        /// <summary>
        /// Sets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <param name="data">Data of the element.</param>
        /// <returns>True if data is set successfully, false if the given position is incorrect.</returns>
        bool SetData(uint position, string data);

        /// <summary>
        /// Prints the list.
        /// </summary>
        void PrintList();

        /// <summary>
        /// Checks if the list element exists.
        /// </summary>
        /// <param name="data">Element to check.</param>
        /// <returns>True if the list element is found, else false</returns>
        bool Exists(string data);
    }
}