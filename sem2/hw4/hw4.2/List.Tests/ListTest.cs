namespace List.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw4._2;

    [TestClass]
    public class ListTest
    {
         [TestInitialize]
        public void Initialize()
        {
            list = new List();
            uniqueList = new UniqueList();
        }

        public void IsEmptyTest(IList testList)
        {
            Assert.IsTrue(testList.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyListTest()
        {
            IsEmptyTest(list);
        }

        [TestMethod]
        public void IsEmptyUniqueListTest()
        {
            IsEmptyTest(uniqueList);
        }

        public void IsNotEmptyTest(IList testList)
        {
            testList.AddElement(1, "Something");
            Assert.IsFalse(testList.IsEmpty());
        }

        [TestMethod]
        public void IsNotEmptyListTest()
        {
            IsNotEmptyTest(list);
        }

        [TestMethod]
        public void IsNotEmptyUniqueListTest()
        {
            IsNotEmptyTest(uniqueList);
        }

        public void GetDataFromEmptyList(IList testList)
        {
            string temp = testList.GetData(1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetDataFromEmptyListTest()
        {
            GetDataFromEmptyList(list);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetDataFromEmptyUniqueListTest()
        {
            GetDataFromEmptyList(uniqueList);
        }

        public void AddElementsInAscendingOrderTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            Assert.AreEqual("String 2", testList.GetData(2));
            Assert.AreEqual("String 3", testList.GetData(3));
            Assert.AreEqual("String 1", testList.GetData(1));
        }

        [TestMethod]
        public void AddElementsInAscendingOrderListTest()
        {
            AddElementsInAscendingOrderTest(list);
        }

        [TestMethod]
        public void AddElementsInAscendingOrderUniqueListTest()
        {
            AddElementsInAscendingOrderTest(uniqueList);
        }

        public void AddElementsInRandomOrderTest(IList testList)
        {
            testList.AddElement(1, "String 3");
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");

            Assert.AreEqual("String 2", testList.GetData(2));
            Assert.AreEqual("String 3", testList.GetData(3));
            Assert.AreEqual("String 1", testList.GetData(1));
        }

        [TestMethod]
        public void AddElementsInRandomOrderListTest()
        {
            AddElementsInRandomOrderTest(list);
        }

        [TestMethod]
        public void AddElementsInRandomOrderUniqueListTest()
        {
            AddElementsInRandomOrderTest(uniqueList);
        }

        public void AddTheSameElementsTest(IList testList)
        {
            testList.AddElement(1, "String");
            testList.AddElement(2, "String");

            Assert.AreEqual("String", testList.GetData(1));
            Assert.AreEqual("String", testList.GetData(2));
        }

        [TestMethod]
        public void AddTheSameElementsListTest()
        {
            AddTheSameElementsTest(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistsException))]
        public void AddTheSameElementsUniqueListTest()
        {
            AddTheSameElementsTest(uniqueList);
        }

        public void AddElementInIncorrectPositionTest(IList testList)
        {
            testList.AddElement(2, "lala");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddElementInIncorrectPositionListTest()
        {
            AddElementInIncorrectPositionTest(list);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddElementInIncorrectPositionUniqueListTest()
        {
            AddElementInIncorrectPositionTest(uniqueList);
        }

        public void SetDataInEmptyList(IList testList)
        {
            testList.SetData(1, "123");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetDataInEmptyListTest()
        {
            SetDataInEmptyList(list);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetDataInEmptyUniqueListTest()
        {
            SetDataInEmptyList(uniqueList);
        }

        public void SetDataTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            testList.SetData(2, "New string 2");
            testList.SetData(1, "New string 1");
            testList.SetData(3, "New string 3");
            testList.SetData(2, "Super new string 2");

            Assert.AreEqual("New string 1", testList.GetData(1));
            Assert.AreEqual("Super new string 2", testList.GetData(2));
            Assert.AreEqual("New string 3", testList.GetData(3));
        }

        [TestMethod]
        public void SetDataListTest()
        {
            SetDataTest(list);
        }

        [TestMethod]
        public void SetDataUniqueListTest()
        {
            SetDataTest(uniqueList);
        }

        public void SetTheSameDataTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            testList.SetData(2, "String 1");
            Assert.AreEqual("String 1", testList.GetData(1));
            Assert.AreEqual("String 1", testList.GetData(2));
            Assert.AreEqual("String 3", testList.GetData(3));
        }

        [TestMethod]
        public void SetTheSameDataListTest()
        {
            SetTheSameDataTest(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistsException))]
        public void SetTheSameDataUniqueListTest()
        {
            SetTheSameDataTest(uniqueList);
        }

        public void DeleteByPositionFromEmptyList(IList testList)
        {
            testList.DeleteElementByPosition(1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteByPositionFromEmptyListTest()
        {
            DeleteByPositionFromEmptyList(list);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteByPositionFromEmptyUniqueListTest()
        {
            DeleteByPositionFromEmptyList(uniqueList);
        }

        public void DeleteByPositionTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            testList.DeleteElementByPosition(2);
            Assert.AreEqual("String 1", testList.GetData(1));
            Assert.AreEqual("String 3", testList.GetData(2));
        }

        [TestMethod]
        public void DeleteByPositionListTest()
        {
            DeleteByPositionTest(list);
        }

        [TestMethod]
        public void DeleteByPositionUniqueListTest()
        {
            DeleteByPositionTest(uniqueList);
        }

        public void DeleteAllElementsTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            testList.DeleteElementByPosition(1);
            testList.DeleteElementByPosition(1);
            testList.DeleteElementByPosition(1);

            Assert.IsTrue(testList.IsEmpty());
        }

        [TestMethod]
        public void DeleteAllElementsListTest()
        {
            DeleteAllElementsTest(list);
        }

        [TestMethod]
        public void DeleteAllElementsUniqueListTest()
        {
            DeleteAllElementsTest(uniqueList);
        }

        public void GetSizeOfEmptyList(IList testList)
        {
            Assert.AreEqual(0, testList.Size);
        }

        [TestMethod]
        public void GetSizeOfEmptyListTest()
        {
            GetSizeOfEmptyList(list);
        }

        [TestMethod]
        public void GetSizeOfEmptyUniqueListTest()
        {
            GetSizeOfEmptyList(uniqueList);
        }

        public void GetSizeTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            Assert.AreEqual(3, testList.Size);

            testList.DeleteElementByPosition(3);

            Assert.AreEqual(2, testList.Size);
        }

        [TestMethod]
        public void GetSizeListTest()
        {
            GetSizeTest(list);
        }

        [TestMethod]
        public void GetSizeUniqueListTest()
        {
            GetSizeTest(uniqueList);
        }

        public void DeleteElementByDataTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");
            testList.AddElement(3, "String 3");

            testList.DeleteElementByData("String 2");
            Assert.AreEqual("String 1", testList.GetData(1));
            Assert.AreEqual("String 3", testList.GetData(2));
        }

        [TestMethod]
        public void DeleteElementByDataListTest()
        {
            DeleteElementByDataTest(list);
        }

        [TestMethod]
        public void DeleteElementByDataUniqueListTest()
        {
            DeleteElementByDataTest(uniqueList);
        }
 
        [TestMethod]
        public void DeleteSeveralElementsWithTheSameDataTest()
        {
            list.AddElement(1, "String 1");
            list.AddElement(2, "String 2");
            list.AddElement(3, "String 2");
            list.AddElement(4, "String 3");

            list.DeleteElementByData("String 2");
            Assert.AreEqual("String 1", list.GetData(1));
            Assert.AreEqual("String 3", list.GetData(2));
        }

        public void DeleteNotExistingElementTest(IList testList)
        {
            testList.AddElement(1, "String");

            testList.DeleteElementByData("Not existing string");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementDoesNotExistException))]
        public void DeleteNotExistingElementListTest()
        {
            DeleteNotExistingElementTest(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementDoesNotExistException))]
        public void DeleteNotExistingElementUniqueListTest()
        {
            DeleteNotExistingElementTest(uniqueList);
        }

        public void ExistsTest(IList testList)
        {
            testList.AddElement(1, "String 1");
            testList.AddElement(2, "String 2");

            Assert.IsTrue(testList.Exists("String 1"));
            Assert.IsTrue(testList.Exists("String 2"));
            Assert.IsFalse(testList.Exists("String that doesn't exist"));
        }

        [TestMethod]
        public void ExistsListTest()
        {
            ExistsTest(list);
        }

        [TestMethod]
        public void ExistsUniqueListTest()
        {
            ExistsTest(uniqueList);
        }

        private List list;
        private UniqueList uniqueList;
    }
}
