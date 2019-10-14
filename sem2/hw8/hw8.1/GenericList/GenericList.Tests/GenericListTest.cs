namespace GenericList.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using homework8;

    [TestClass]
    public class GenericListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new GenericList<int>();
        }

        [TestMethod]
        public void AddTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            for (var j = 0; j < 10; ++j)
            {
                Assert.AreEqual(j, list[j]);
            }
        }

        [TestMethod]
        public void InsertInAscendingOrderTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.Insert(i, i * 10);
            }

            for (var j = 0; j < 10; ++j)
            {
                Assert.AreEqual(j * 10, list[j]);
            }
        }

        [TestMethod]
        public void InsertInRandomOrderTest()
        {
            list.Insert(0, 30);
            list.Insert(0, 0);
            list.Insert(1, 20);

            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(20, list[1]);
            Assert.AreEqual(30, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertInIncorrectPositionTest()
        {
            list.Insert(25, 300);
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (var i = 30; i < 36; ++i)
            {
                list.Add(i);
            }

            for (var j = 30; j < 36; ++j)
            {
                Assert.IsTrue(list.Contains(j));
            }

            Assert.IsFalse(list.Contains(0));
            Assert.IsFalse(list.Contains(36));
            Assert.IsFalse(list.Contains(1000));
        }

        [TestMethod]
        public void IndexOfTest()
        {
            for (var i = 100; i < 106; ++i)
            {
                list.Add(i);
            }

            for (var j = 0; j < 6; ++j)
            {
                Assert.AreEqual(j, list.IndexOf(j + 100));
            }

            Assert.AreEqual(-1, list.IndexOf(0));
            Assert.AreEqual(-1, list.IndexOf(50));
            Assert.AreEqual(-1, list.IndexOf(1234));
        }

        [TestMethod]
        public void RemoveTest()
        {
            for (var i = 10; i < 40; i += 10)
            {
                list.Add(i);
            }

            Assert.IsTrue(list.Remove(20));
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(30, list[1]);
            Assert.IsFalse(list.Remove(20));
        }

        [TestMethod]
        public void RemoveFirstOccurrenceTest()
        {
            list.Add(2000);

            for (var i = 2000; i < 2004; ++i)
            {
                list.Add(i);
            }

            Assert.IsTrue(list.Remove(2000));

            for (var j = 0; j < list.Count; ++j)
            {
                Assert.AreEqual(2000 + j, list[j]);
            }
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            for (var i = 200; i < 250; i += 10)
            {
                list.Add(i);
            }

            list.RemoveAt(0);
            list.RemoveAt(1);

            Assert.AreEqual(210, list[0]);
            Assert.AreEqual(230, list[1]);
            Assert.AreEqual(240, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtIncorrectPositionTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                list.Add(i);
            }

            list.RemoveAt(5);
        }

        [TestMethod]
        public void ClearTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                list.Add(i);
            }

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void CopyToTest()
        {
            var array = new int[10];

            for (var i = 0; i < 5; ++i)
            {
                list.Add(i);
            }

            list.CopyTo(array, 5);

            for (var j = 0; j < 5; ++j)
            {
                Assert.AreEqual(0, array[j]);
            }

            for (var i = 5; i < array.Length; ++i)
            {
                Assert.AreEqual(list[i - 5], array[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToIncorrectPositionTest()
        {
            var array = new int[2];

            for (var i = 0; i < 3; ++i)
            {
                list.Add(i);
            }

            list.CopyTo(array, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToTooSmallArrayTest()
        {
            var array = new int[2];

            for (var i = 0; i < 4; ++i)
            {
                list.Add(i);
            }

            list.CopyTo(array, 0);
        }

        [TestMethod]
        public void ForeachTest()
        {
            for (var i = 0; i < 5; ++i)
            {
                list.Add(i);
            }

            var index = 0;

            foreach (var element in list)
            {
                Assert.AreEqual(index, element);
                ++index;
            }
        }

        private GenericList<int> list;
    }
}
