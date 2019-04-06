namespace HashTable.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw3._2;

    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashTableJenkins = new HashTable(new JenkinsHash());
            hashTableFNV = new HashTable(new FNVHash());
            hashTablePJW = new HashTable(new PJWHash());
        }

        public void ExistsInEmptyHashTableTest(IHashTable hashTable)
        {
            Assert.IsFalse(hashTable.Exists("TestString"));
        }

        [TestMethod]
        public void ExistsInEmptyHashTableJenkinsTest()
        {
            ExistsInEmptyHashTableTest(hashTableJenkins);
        }

        [TestMethod]
        public void ExistsInEmptyHashTableFNVTest()
        {
            ExistsInEmptyHashTableTest(hashTableFNV);
        }

        [TestMethod]
        public void ExistsInEmptyHashTablePJWTest()
        {
            ExistsInEmptyHashTableTest(hashTablePJW);
        }

        public void AddAndExistsTest(IHashTable hashTable)
        {
            hashTable.Add("Existing string");

            Assert.IsTrue(hashTable.Exists("Existing string"));
            Assert.IsFalse(hashTable.Exists("Not existing string"));
        }

        [TestMethod]
        public void AddAndExistsJenkinsTest()
        {
            AddAndExistsTest(hashTableJenkins);
        }

        [TestMethod]
        public void AddAndExistsFNVTest()
        {
            AddAndExistsTest(hashTableFNV);
        }

        [TestMethod]
        public void AddAndExistsPJWTest()
        {
            AddAndExistsTest(hashTablePJW);
        }

        public void AddTheSameElementTwiceTest(IHashTable hashTable)
        {
            Assert.IsTrue(hashTable.Add("TestString"));
            Assert.IsFalse(hashTable.Add("TestString"));
        }

        [TestMethod]
        public void AddTheSameElementTwiceJenkinsTest()
        {
            AddTheSameElementTwiceTest(hashTableJenkins);
        }

        [TestMethod]
        public void AddTheSameElementTwiceFNVTest()
        {
            AddTheSameElementTwiceTest(hashTableFNV);
        }

        [TestMethod]
        public void AddTheSameElementTwicePJWTest()
        {
            AddTheSameElementTwiceTest(hashTablePJW);
        }

        public void DeleteFromEmptyHashTableTest(IHashTable hashTable)
        {
            Assert.IsFalse(hashTable.Delete("TestString"));
        }

        [TestMethod]
        public void DeleteFromEmptyHashTableJenkinsTest()
        {
            DeleteFromEmptyHashTableTest(hashTableJenkins);
        }

        [TestMethod]
        public void DeleteFromEmptyHashTableFNVTest()
        {
            DeleteFromEmptyHashTableTest(hashTableFNV);
        }

        [TestMethod]
        public void DeleteFromEmptyHashTablePJWTest()
        {
            DeleteFromEmptyHashTableTest(hashTablePJW);
        }

        public void DeleteTest(IHashTable hashTable)
        {
            hashTable.Add("TestString1");
            hashTable.Add("TestString2");
            hashTable.Add("TestString3");

            Assert.IsTrue(hashTable.Delete("TestString1"));
            Assert.IsFalse(hashTable.Delete("TestString1"));
            Assert.IsTrue(hashTable.Delete("TestString3"));

            Assert.IsFalse(hashTable.Exists("TestString1"));
            Assert.IsFalse(hashTable.Exists("TestString3"));
            Assert.IsTrue(hashTable.Exists("TestString2"));
        }

        [TestMethod]
        public void DeleteJenkinsTest()
        {
            DeleteTest(hashTableJenkins);
        }

        [TestMethod]
        public void DeleteFNVTest()
        {
            DeleteTest(hashTableFNV);
        }

        [TestMethod]
        public void DeletePJWTest()
        {
            DeleteTest(hashTablePJW);
        }

        public void SizeOfEmptyHashTableTest(IHashTable hashTable)
        {
            Assert.AreEqual(0, hashTable.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfEmptyHashTableJenkinsTest()
        {
            SizeOfEmptyHashTableTest(hashTableJenkins);
        }

        [TestMethod]
        public void SizeOfEmptyHashTableFNVTest()
        {
            SizeOfEmptyHashTableTest(hashTableFNV);
        }

        [TestMethod]
        public void SizeOfEmptyHashTablePJWTest()
        {
            SizeOfEmptyHashTableTest(hashTablePJW);
        }

        public void SizeOfHashTableTest(IHashTable hashTable)
        {
            hashTable.Add("TestString 1");
            hashTable.Add("TestString 2");
            hashTable.Add("TestString 3");
            hashTable.Delete("TestString 2");

            Assert.AreEqual(2, hashTable.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfHashTableJenkinsTest()
        {
            SizeOfHashTableTest(hashTableJenkins);
        }

        [TestMethod]
        public void SizeOfHashTableFNVTest()
        {
            SizeOfEmptyHashTableTest(hashTableFNV);
        }

        [TestMethod]
        public void SizeOfHashTablePJWTest()
        {
            SizeOfHashTableTest(hashTablePJW);
        }

        private HashTable hashTableJenkins;
        private HashTable hashTableFNV;
        private HashTable hashTablePJW;
    }
}
