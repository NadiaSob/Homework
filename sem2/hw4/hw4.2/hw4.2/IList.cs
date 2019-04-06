using System;

namespace hw4._2
{
    /// <summary>
    /// List interface.
    /// </summary>
    public interface IList
    {
        /// <summary>
        /// Number of elements in list.
        /// </summary>
        int Size { get; }

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
        void AddElement(int position, string data);

        /// <summary>
        /// Deletes an element from the list by its position.
        /// </summary>
        /// <param name="position">Position of the element to delete.</param>
        void DeleteElementByPosition(int position);

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
        string GetData(int position);

        /// <summary>
        /// Sets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <param name="data">Data of the element.</param>
        void SetData(int position, string data);

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
