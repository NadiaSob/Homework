﻿using System;

namespace hw2._1
{
    /// <summary>
    /// List interface.
    /// </summary>
    interface IList
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
        /// <returns>True if the element is added, false if the given position is incorrect.</returns>
        bool AddElement(int position, int data);

        /// <summary>
        /// Deletes an element from the list by its position.
        /// </summary>
        /// <param name="position">Position of the element to delete.</param>
        /// <returns>True if the element is deleted, false if the given position is incorrect.</returns>
        bool DeleteElement(int position);

        /// <summary>
        /// Gets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <returns>Data of the element or ' ' if the given position is incorrect or the list is empty.</returns>
        int GetData(int position);

        /// <summary>
        /// Sets data of the list element by its position.
        /// </summary>
        /// <param name="position">Position of the element.</param>
        /// <param name="data">Data of the element.</param>
        /// <returns>True if data is set successfully, false if the given position is incorrect.</returns>
        bool SetData(int position, int data);

        /// <summary>
        /// Prints the list.
        /// </summary>
        void PrintList();
    }
}
