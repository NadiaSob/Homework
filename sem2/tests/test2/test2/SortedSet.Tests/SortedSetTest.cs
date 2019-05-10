namespace SortedSet.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using test2;

    [TestClass]
    public class SortedSetTest
    {
        [TestInitialize]
        public void Initialize()
        {
            testSet = new SortedSet();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(testSet.IsEmpty());
        }

        [TestMethod]
        public void AddElementTest()
        {
            testSet.AddElement(new List<string>() { "abc", "def " });
            Assert.IsFalse(testSet.IsEmpty());
        }

        [TestMethod]
        public void AddFewElementsTest()
        {
            testSet.AddElement(new List<string>() { "one", "two", "three" });
            testSet.AddElement(new List<string>() { "TestString" });
            testSet.AddElement(new List<string>() { "lala", "la " });
            Assert.IsFalse(testSet.IsEmpty());
        }

        [TestMethod]
        public void SizeTest()
        {
            testSet.AddElement(new List<string>() { "a", "b" });
            testSet.AddElement(new List<string>() { "d", "e" });
            testSet.AddElement(new List<string>() { "fgh" });
            Assert.AreEqual(3, testSet.Size);
        }

        [TestMethod]
        public void SizeZeroTest()
        {
            Assert.IsTrue(testSet.IsEmpty());
            Assert.AreEqual(0, testSet.Size);
        }

        private SortedSet testSet;
    }
}
