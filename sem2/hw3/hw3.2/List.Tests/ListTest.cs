namespace List.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw3._2;

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
            list.AddElement(1, "Something");
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetDataFromEmptyListTest()
        {
            string temp = list.GetData(1);
        }

        [TestMethod]
        public void AddElementsInAscendingOrderTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            Assert.AreEqual("String 2", list.GetData(2));
            Assert.AreEqual("String 3", list.GetData(3));
            Assert.AreEqual("String 1", list.GetData(1));
        }

        [TestMethod]
        public void AddElementsInRandomOrderTest()
        {
            list.AddElement(1, "String 3");
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");

            Assert.AreEqual("String 2", list.GetData(2));
            Assert.AreEqual("String 3", list.GetData(3));
            Assert.AreEqual("String 1", list.GetData(1));
        }

        [TestMethod]
        public void AddElementInIncorrectPositionTest()
        {
            Assert.IsFalse(list.AddElement(2, "lala"));
            Assert.IsFalse(list.AddElement(0, "Lala"));
            Assert.IsFalse(list.AddElement(4, "lalala"));
        }

        [TestMethod]
        public void SetDataInEmptyListTest()
        {
            Assert.IsFalse(list.SetData(0, "123"));
            Assert.IsFalse(list.SetData(1, "Something"));
            Assert.IsFalse(list.SetData(5, "Another something"));
        }

        [TestMethod]
        public void SetDataTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            list.SetData(2, "New string 2");
            list.SetData(1, "New string 1");
            list.SetData(3, "New string 3");
            list.SetData(2, "Super new string 2");

            Assert.AreEqual("New string 1", list.GetData(1));
            Assert.AreEqual("Super new string 2", list.GetData(2));
            Assert.AreEqual("New string 3", list.GetData(3));
        }

        [TestMethod]
        public void DeleteByPositionFromEmptyListTest()
        {
            Assert.IsFalse(list.DeleteElementByPosition(1));
            Assert.IsFalse(list.DeleteElementByPosition(0));
            Assert.IsFalse(list.DeleteElementByPosition(5));
        }

        [TestMethod]
        public void DeleteByPositionTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            list.DeleteElementByPosition(2);
            Assert.AreEqual("String 1", list.GetData(1));
            Assert.AreEqual("String 3", list.GetData(2));
        }

        [TestMethod]
        public void DeleteAllElementsTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            list.DeleteElementByPosition(1);
            list.DeleteElementByPosition(1);
            list.DeleteElementByPosition(1);

            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void GetSizeOfEmptyListTest()
        {
            Assert.AreEqual((uint)0, list.Size);
        }

        [TestMethod]
        public void GetSizeTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            Assert.AreEqual((uint)3, list.Size);

            list.DeleteElementByPosition(3);

            Assert.AreEqual((uint)2, list.Size);
        }

        [TestMethod]
        public void DeleteElementByDataTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 3");

            list.DeleteElementByData("String 2");
            Assert.AreEqual("String 1", list.GetData(1));
            Assert.AreEqual("String 3", list.GetData(2));
        }

        [TestMethod]
        public void ExistsTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");

            Assert.IsTrue(list.Exists("String 1"));
            Assert.IsTrue(list.Exists("String 2"));
            Assert.IsFalse(list.Exists("String that doesn't exist"));
        }

        private List list;
    }
}
