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

        [TestMethod]
        public void ExistsInEmptyHashTableJenkinsTest()
        {
            Assert.IsFalse(hashTableJenkins.Exists("TestString"));
        }

        [TestMethod]
        public void ExistsInEmptyHashTableFNVTest()
        {
            Assert.IsFalse(hashTableFNV.Exists("TestString"));
        }

        [TestMethod]
        public void ExistsInEmptyHashTablePJWTest()
        {
            Assert.IsFalse(hashTablePJW.Exists("TestString"));
        }

        [TestMethod]
        public void AddAndExistsJenkinsTest()
        {
            hashTableJenkins.Add("Existing string");

            Assert.IsTrue(hashTableJenkins.Exists("Existing string"));
            Assert.IsFalse(hashTableJenkins.Exists("Not existing string"));
        }

        [TestMethod]
        public void AddAndExistsFNVTest()
        {
            hashTableFNV.Add("Existing string");

            Assert.IsTrue(hashTableFNV.Exists("Existing string"));
            Assert.IsFalse(hashTableFNV.Exists("Not existing string"));
        }

        [TestMethod]
        public void AddAndExistsPJWTest()
        {
            hashTablePJW.Add("Existing string");

            Assert.IsTrue(hashTablePJW.Exists("Existing string"));
            Assert.IsFalse(hashTablePJW.Exists("Not existing string"));
        }

        [TestMethod]
        public void AddTheSameElementTwiceJenkinsTest()
        {
            Assert.IsTrue(hashTableJenkins.Add("TestString"));
            Assert.IsFalse(hashTableJenkins.Add("TestString"));
        }

        [TestMethod]
        public void AddTheSameElementTwiceFNVTest()
        {
            Assert.IsTrue(hashTableFNV.Add("TestString"));
            Assert.IsFalse(hashTableFNV.Add("TestString"));
        }

        [TestMethod]
        public void AddTheSameElementTwicePJWTest()
        {
            Assert.IsTrue(hashTablePJW.Add("TestString"));
            Assert.IsFalse(hashTablePJW.Add("TestString"));
        }

        [TestMethod]
        public void DeleteFromEmptyHashTableJenkinsTest()
        {
            Assert.IsFalse(hashTableJenkins.Delete("TestString"));
        }

        [TestMethod]
        public void DeleteFromEmptyHashTableFNVTest()
        {
            Assert.IsFalse(hashTableFNV.Delete("TestString"));
        }

        [TestMethod]
        public void DeleteFromEmptyHashTablePJWTest()
        {
            Assert.IsFalse(hashTablePJW.Delete("TestString"));
        }

        [TestMethod]
        public void DeleteJenkinsTest()
        {
            hashTableJenkins.Add("TestString1");
            hashTableJenkins.Add("TestString2");
            hashTableJenkins.Add("TestString3");

            Assert.IsTrue(hashTableJenkins.Delete("TestString1"));
            Assert.IsFalse(hashTableJenkins.Delete("TestString1"));
            Assert.IsTrue(hashTableJenkins.Delete("TestString3"));

            Assert.IsFalse(hashTableJenkins.Exists("TestString1"));
            Assert.IsFalse(hashTableJenkins.Exists("TestString3"));
            Assert.IsTrue(hashTableJenkins.Exists("TestString2"));
        }

        [TestMethod]
        public void DeleteFNVTest()
        {
            hashTableFNV.Add("TestString1");
            hashTableFNV.Add("TestString2");
            hashTableFNV.Add("TestString3");

            Assert.IsTrue(hashTableFNV.Delete("TestString1"));
            Assert.IsFalse(hashTableFNV.Delete("TestString1"));
            Assert.IsTrue(hashTableFNV.Delete("TestString3"));

            Assert.IsFalse(hashTableFNV.Exists("TestString1"));
            Assert.IsFalse(hashTableFNV.Exists("TestString3"));
            Assert.IsTrue(hashTableFNV.Exists("TestString2"));
        }

        [TestMethod]
        public void DeletePJWTest()
        {
            hashTablePJW.Add("TestString1");
            hashTablePJW.Add("TestString2");
            hashTablePJW.Add("TestString3");

            Assert.IsTrue(hashTablePJW.Delete("TestString1"));
            Assert.IsFalse(hashTablePJW.Delete("TestString1"));
            Assert.IsTrue(hashTablePJW.Delete("TestString3"));

            Assert.IsFalse(hashTablePJW.Exists("TestString1"));
            Assert.IsFalse(hashTablePJW.Exists("TestString3"));
            Assert.IsTrue(hashTablePJW.Exists("TestString2"));
        }

        [TestMethod]
        public void SizeOfEmptyHashTableJenkinsTest()
        {
            Assert.AreEqual(0, hashTableJenkins.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfEmptyHashTableFNVTest()
        {
            Assert.AreEqual(0, hashTableFNV.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfEmptyHashTablePJWTest()
        {
            Assert.AreEqual(0, hashTablePJW.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfHashTableJenkinsTest()
        {
            hashTableJenkins.Add("TestString 1");
            hashTableJenkins.Add("TestString 2");
            hashTableJenkins.Add("TestString 3");
            hashTableJenkins.Delete("TestString 2");

            Assert.AreEqual(2, hashTableJenkins.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfHashTableFNVTest()
        {
            hashTableFNV.Add("TestString 1");
            hashTableFNV.Add("TestString 2");
            hashTableFNV.Add("TestString 3");
            hashTableFNV.Delete("TestString 2");

            Assert.AreEqual(2, hashTableFNV.NumberOfElements);
        }

        [TestMethod]
        public void SizeOfHashTablePJWTest()
        {
            hashTablePJW.Add("TestString 1");
            hashTablePJW.Add("TestString 2");
            hashTablePJW.Add("TestString 3");
            hashTablePJW.Delete("TestString 2");

            Assert.AreEqual(2, hashTablePJW.NumberOfElements);
        }

        private HashTable hashTableJenkins;
        private HashTable hashTableFNV;
        private HashTable hashTablePJW;
    }
}
