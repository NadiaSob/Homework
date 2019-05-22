using System;
using System.Collections.Generic;

namespace hw6._1
{
    /// <summary>
    /// Map, Filter and Fold functions.
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Applies given function to list elements.
        /// </summary>
        /// <param name="list">List to apply the function.</param>
        /// <param name="function">Function applied to list elements.</param>
        /// <returns>List obtained by applying the function to each element of the given list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var result = new List<int>();
            foreach (var element in list)
            {
                result.Add(function(element));
            }

            return result;
        }

        /// <summary>
        /// Returns the list of elements which satisfy certain condition.
        /// </summary>
        /// <param name="list">Given list.</param>
        /// <param name="function">Function that checks if list element satisfy the condition.</param>
        /// <returns>List of elements that satisfy certain condition.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var result = new List<int>();
            foreach (var element in list)
            {
                if (function(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the accumulated value obtained after applying the function to each element of the given list.
        /// </summary>
        /// <param name="list">Given list.</param>
        /// <param name="startValue">Starting value.</param>
        /// <param name="function">Function applied to list elements.</param>
        /// <returns>The accumulated value</returns>
        public static int Fold(List<int> list, int startValue, Func<int, int, int> function)
        {
            var result = startValue;
            foreach (var element in list)
            {
                result = function(result, element);
            }

            return result;
        }
    }
}
