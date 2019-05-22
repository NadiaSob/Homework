using System;
using System.Collections.Generic;

namespace test2
{
    /// <summary>
    /// Realisation of comparing two list objects by their length.
    /// </summary>
    /// <typeparam name="T">Type of list object.</typeparam>
    public class Comparer<T> : IComparer<T> where T : List<string>
    {
        /// <summary>
        /// Compares two list objects by their length.
        /// </summary>
        /// <param name="value1">First object.</param>
        /// <param name="value2">Second object.</param>
        /// <returns>1 if the first object is bigger than the second, -1 is the second object is bigger than the ferst, else 0.</returns>
        public int Compare(T value1, T value2)
        {
            if (value1.Count < value2.Count)
            {
                return 1;
            }
            else if (value1.Count > value2.Count)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
