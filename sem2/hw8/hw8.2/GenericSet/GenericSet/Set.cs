using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSet
{
    /// <summary>
    /// Realisation of the collection that has unique elements and specific operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(T data, Node leftChild, Node rightChild)
            {
                Data = data;
                LeftChild = leftChild;
                RightChild = rightChild;
            }
        }

        private Node root;

        /// <summary>
        /// The number of elements contained in the set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The value indicating whether the set is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Determines whether the set contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the set.</param>
        /// <returns>true if item is found in the set; otherwise, false.</returns>
        public bool Contains(T item)
        {
            if (root == null)
            {
                return false;
            }

            var current = root;
            while (true)
            {
                if (current.Data.CompareTo(item) > 0)
                {
                    if (current.LeftChild != null)
                    {
                        current = current.LeftChild;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (current.Data.CompareTo(item) < 0)
                {
                    if (current.RightChild != null)
                    {
                        current = current.RightChild;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Adds an element to the set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the set; false if the element is already in the set.</returns>
        public bool Add(T item)
        {
            if (root == null)
            {
                root = new Node(item, null, null);
                ++Count;
                return true;
            }
            else
            {
                return FindWhereToAdd(root, item);
            }
        }

        private bool FindWhereToAdd(Node current, T item)
        {
            if (current.Data.CompareTo(item) > 0 && current.LeftChild != null)
            {
                return FindWhereToAdd(current.LeftChild, item);
            }
            else if (current.Data.CompareTo(item) < 0 && current.RightChild != null)
            {
                return FindWhereToAdd(current.RightChild, item);
            }
            else
            {
                if (current.Data.CompareTo(item) > 0)
                {
                    current.LeftChild = new Node(item, null, null);
                }
                else if (current.Data.CompareTo(item) < 0)
                {
                    current.RightChild = new Node(item, null, null);
                }
                else
                {
                    return false;
                }
            }
            ++Count;
            return true;
        }

        /// <summary>
        /// Removes the specific object from the set.
        /// </summary>
        /// <param name="item">The object to remove from the set.</param>
        /// <returns>true if item was successfully removed from the set; otherwise, false.</returns>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            root = FindNodeToRemove(root, item);
            return true;
        }

        private Node FindNodeToRemove(Node current, T item)
        {
            if (current.Data.CompareTo(item) > 0)
            {
                current.LeftChild = FindNodeToRemove(current.LeftChild, item);
            }
            else if (current.Data.CompareTo(item) < 0)
            {
                current.RightChild = FindNodeToRemove(current.RightChild, item);
            }
            else
            {
                if (current.LeftChild == null && current.RightChild == null)
                {
                    current = null;
                }
                else if (current.LeftChild == null && current.RightChild != null)
                {
                    current = current.RightChild;
                }
                else if (current.LeftChild != null && current.RightChild == null)
                {
                    current = current.LeftChild;
                }
                else
                {
                    var maximum = current.LeftChild;
                    while (maximum.RightChild != null)
                    {
                        maximum = maximum.RightChild;
                    }
                    current.Data = maximum.Data;
                    current.LeftChild = FindNodeToRemove(current.LeftChild, current.Data);
                }

                --Count;
            }

            return current;
        }

        /// <summary>
        /// Removes all items from the set.
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Copies the elements of the set to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The Array that is the destination of the elements copied from set.</param>
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

            foreach (var current in this)
            {
                array[arrayIndex] = current;
                ++arrayIndex;
            }
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (other == this)
            {
                Clear();
                return;
            }

            foreach (var current in other)
            {
                Remove(current);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var nodesToRemove = new List<T>();

            foreach (var current in this)
            {
                if (!other.Contains(current))
                {
                    nodesToRemove.Add(current);
                }
            }

            ExceptWith(nodesToRemove);
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in this)
            {
                if (!other.Contains(current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a superset of other; otherwise, false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                if (!Contains(current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a proper subset of other; otherwise, false.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other) => Count.CompareTo(other.Count()) < 0 && IsSubsetOf(other);

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is a proper superset of other; otherwise, false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other) => Count.CompareTo(other.Count()) > 0 && IsSupersetOf(other);

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set and other share at least one common element; otherwise, false.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                if (Contains(current))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is equal to other; otherwise, false.</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (Count.CompareTo(other.Count()) != 0)
            {
                return false;
            }
            else
            {
                foreach (var current in other)
                {
                    if (!Contains(current))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                if (!Remove(current))
                {
                    Add(current);
                }
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                Add(current);
            }
        }

        void ICollection<T>.Add(T item) => Add(item);

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = root;
            var stack = new Stack<Node>();

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.LeftChild;
                }

                current = stack.Pop();
                yield return current.Data;
                current = current.RightChild;
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
