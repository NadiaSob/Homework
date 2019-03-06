using System;

namespace hw2._2
{
    /// <summary>
    /// Hash table, data structure that is used to store keys/value pairs.
    /// </summary>
    public class HashTable : IHashTable
    {
        /// <summary>
        /// Number of elements in hash table.
        /// </summary>
        public int NumberOfElements { get; private set; }
        private const int size = 200;
        private List[] bucket = new List[size];

        public HashTable()
        {
            for (var i = 0; i < size; ++i)
            {
                bucket[i] = new List();
            }
        }

        private int Hash(int data) => Math.Abs(data.GetHashCode()) % bucket.Length;

        /// <summary>
        /// Checks if the given hash table element exists.
        /// </summary>
        /// <param name="data">Element to check.</param>
        /// <returns>True if the hash table element is found, else false.</returns>
        public bool Exists(int data) => bucket[Hash(data)].Exists(data);

        /// <summary>
        /// Adds new element in hash table.
        /// </summary>
        /// <param name="data">Element to add.</param>
        /// <returns>True if the element is added successfully, false if it already exists.</returns>
        public bool Add(int data)
        {
            int hash = Hash(data);

            if (!bucket[hash].Exists(data))
            {
                bucket[hash].AddElement(bucket[hash].Size + 1, data);
                ++NumberOfElements;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes element from hash table.
        /// </summary>
        /// <param name="data">Element to delete.</param>
        /// <returns>True if the element is deleted successfully, false if it is not found.</returns>
        public bool Delete(int data)
        {
            int hash = Hash(data);

            if (bucket[hash].Exists(data))
            {
                bucket[hash].DeleteElementByData(data);

                --NumberOfElements;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prints hash table.
        /// </summary>
        public void Print()
        {
            if (NumberOfElements == 0)
            {
                Console.WriteLine("The hash table is empty");
                return;
            }

            for (var i = 0; i < bucket.Length; ++i)
            {
                if (!bucket[i].IsEmpty())
                {
                    bucket[i].PrintList();
                }
            }
        }
    }
}
