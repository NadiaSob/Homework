namespace HashTable.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw2._2;

    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable();
        }

        [TestMethod]
        public void ExistsInEmptyHashTableTest()
        {
            Assert.IsFalse(hashTable.Exists(0));
            Assert.IsFalse(hashTable.Exists(1));
            Assert.IsFalse(hashTable.Exists(-2));
        }

        [TestMethod]
        public void AddAndExistsTest()
        {
            hashTable.Add(1);
            hashTable.Add(-2);
            hashTable.Add(0);

            Assert.IsTrue(hashTable.Exists(-2));
            Assert.IsTrue(hashTable.Exists(1));
            Assert.IsTrue(hashTable.Exists(0));
            Assert.IsFalse(hashTable.Exists(4));
        }

        [TestMethod]
        public void AddTheSameElementTwiceTest()
        {
            Assert.IsTrue(hashTable.Add(1));
            Assert.IsFalse(hashTable.Add(1));
            Assert.IsFalse(hashTable.Add(1));
        }

        [TestMethod]
        public void DeleteFromEmptyHashTableTest()
        {
            Assert.IsFalse(hashTable.Delete(10));
            Assert.IsFalse(hashTable.Delete(-10));
            Assert.IsFalse(hashTable.Delete(0));
        }

        [TestMethod]
        public void DeleteTest()
        {
            hashTable.Add(10);
            hashTable.Add(20);
            hashTable.Add(30);

            Assert.IsTrue(hashTable.Delete(20));
            Assert.IsFalse(hashTable.Delete(-20));
            Assert.IsTrue(hashTable.Delete(10));

            Assert.IsFalse(hashTable.Exists(10));
            Assert.IsFalse(hashTable.Exists(20));
            Assert.IsTrue(hashTable.Exists(30));
        }

        [TestMethod]
        public void SizeOfEmptyHashTableTest()
        {
            Assert.AreEqual(0, hashTable.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfHashTableTest()
        {
            hashTable.Add(10);
            hashTable.Add(20);
            hashTable.Add(30);
            hashTable.Delete(20);

            Assert.AreEqual(2, hashTable.NumberOfElements);
        }

        private HashTable hashTable;
    }
}
