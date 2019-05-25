using System;
using System.Collections;
using System.Collections.Generic;

namespace homework8
{
    /// <summary>
    /// Realisation of the collection of objects that can be individually accessed by index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class GenericList<T> : IList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;

        /// <summary>
        /// The number of elements contained in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The value indicating whether the list is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index] { get => GetNode(index).Data; set => GetNode(index).Data = value; }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">The object to add to the list.</param>
        public void Add(T item)
        {
            var newNode = new Node(item, null);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                GetNode(Count - 1).Next = newNode;
            }
        }

        /// <summary>
        /// Inserts an item to the list at the specified index.
        /// </summary>
        /// <param name="index">The index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the list.</param>
        public void Insert(int index, T item)
        {
            if (!IsCorrectIndex(index) && index != Count + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            var newNode = new Node(item, null);

            if (index == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                var current = GetNode(index - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            ++Count;
        }

        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns>true if item is found in the list; otherwise, false.</returns>
        public bool Contains(T item)
        {
            var current = head;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Determines the index of a specific item in the list.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            var current = head;
            var index = 0;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return index;
                }
                ++index;
                current = current.Next;
            }

            return -1;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="item">The object to remove from the list.</param>
        /// <returns>true if item was successfully removed from the list; otherwise, false.</returns>
        public bool Remove(T item)
        {
            if (Equals(head.Data, item))
            {
                head = head.Next;
                --Count;
                return true;
            }

            Node previous = head;
            Node current = head.Next;

            for (var i = 1; i < Count; ++i)
            {
                if (Equals(current.Data, item))
                {
                    previous.Next = current.Next;
                    --Count;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes the list item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            if (!IsCorrectIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            var previous = GetNode(index - 1);
            previous.Next = previous.Next.Next;
            --Count;
        }

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Copies the elements of the list to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from list.</param>
        /// <param name="arrayIndex">The index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < Count; ++i)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node GetNode(int index)
        {
            if (!IsCorrectIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            Node current = head;

            for (var i = 1; i < index; ++i)
            {
                current = current.Next;
            }

            return current;
        }

        private bool IsCorrectIndex(int index) => index > 0 && index <= Count;
    }
}
