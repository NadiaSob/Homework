namespace List.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw2._1;

    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void TrueWhenEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void FalseWhenNotEmptyTest()
        {
            list.AddElement(1, 0);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void GetDataFromEmptyListTest()
        {
            Assert.AreEqual(' ', list.GetData(1));
        }

        [TestMethod]
        public void AddElementsInAscendingOrderTest()
        {
            list.AddElement(1, 10);
            list.AddElement(2, -20);
            list.AddElement(3, 30);

            Assert.AreEqual(-20, list.GetData(2));
            Assert.AreEqual(30, list.GetData(3));
            Assert.AreEqual(10, list.GetData(1));
        }

        [TestMethod]
        public void AddElementsInRandomOrderTest()
        {
            list.AddElement(1, 30);
            list.AddElement(1, 0);
            list.AddElement(2, 20);

            Assert.AreEqual(20, list.GetData(2));
            Assert.AreEqual(30, list.GetData(3));
            Assert.AreEqual(0, list.GetData(1));
        }

        [TestMethod]
        public void AddElementInIncorrectPositionTest()
        {
            Assert.IsFalse(list.AddElement(-1, 20));
            Assert.IsFalse(list.AddElement(0, 30));
            Assert.IsFalse(list.AddElement(4, 40));
        }

        [TestMethod]
        public void SetDataInEmptyListTest()
        {
            Assert.IsFalse(list.SetData(0, 10));
            Assert.IsFalse(list.SetData(1, 100));
            Assert.IsFalse(list.SetData(5, 500));
        }

        [TestMethod]
        public void SetDataTest()
        {
            list.AddElement(1, 10);
            list.AddElement(2, 20);
            list.AddElement(3, 30);

            list.SetData(2, 22);
            list.SetData(1, 100);
            list.SetData(3, 300);
            list.SetData(2, 200);

            Assert.AreEqual(100, list.GetData(1));
            Assert.AreEqual(200, list.GetData(2));
            Assert.AreEqual(300, list.GetData(3));
        }

        [TestMethod]
        public void DeleteElementFromEmptyListTest()
        {
            Assert.IsFalse(list.DeleteElement(1));
            Assert.IsFalse(list.DeleteElement(0));
            Assert.IsFalse(list.DeleteElement(5));
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            list.AddElement(1, 10);
            list.AddElement(2, 20);
            list.AddElement(3, 30);

            list.DeleteElement(2);
            Assert.AreEqual(10, list.GetData(1));
            Assert.AreEqual(30, list.GetData(2));
            Assert.AreEqual(' ', list.GetData(3));
        }

        [TestMethod]
        public void DeleteAllElementsTest()
        {
            list.AddElement(1, 10);
            list.AddElement(2, 20);
            list.AddElement(3, 30);

            list.DeleteElement(1);
            list.DeleteElement(1);
            list.DeleteElement(1);

            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void GetSizeOfEmptyListTest()
        {
            Assert.AreEqual(0, list.Size);
        }

        [TestMethod]
        public void GetSizeTest()
        {
            list.AddElement(1, 10);
            list.AddElement(2, 20);
            list.AddElement(3, 30);

            Assert.AreEqual(3, list.Size);

            list.DeleteElement(3);

            Assert.AreEqual(2, list.Size);
        }

        private List list;
    }
}
