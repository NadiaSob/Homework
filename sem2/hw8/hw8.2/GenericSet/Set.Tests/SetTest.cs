namespace Set.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using GenericSet;

    [TestClass]
    public class SetTest
    {
        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        [TestMethod]
        public void AddInAscendingOrderTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                Assert.IsTrue(set.Add(i));
            }

            var expected = 0;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                ++expected;
            }

            Assert.AreEqual(10, set.Count);
        }

        [TestMethod]
        public void AddInDescendingOrderTest()
        {
            for (var i = 110; i > 99; --i)
            {
                Assert.IsTrue(set.Add(i));
            }

            var expected = 100;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                ++expected;
            }

            Assert.AreEqual(11, set.Count);
        }

        [TestMethod]
        public void AddInRandomOrderTest()
        {
            Assert.IsTrue(set.Add(0));
            Assert.IsTrue(set.Add(-20));
            Assert.IsTrue(set.Add(10));
            Assert.IsTrue(set.Add(20));
            Assert.IsTrue(set.Add(-10));

            var expected = -20;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                expected += 10;
            }

            Assert.AreEqual(5, set.Count);
        }

        [TestMethod]
        public void AddTwoSameElementsTest()
        {
            Assert.IsTrue(set.Add(50));
            Assert.IsFalse(set.Add(50));

            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            for (var i = 55; i > 49; --i)
            {
                set.Add(i);
            }
            Assert.AreEqual(6, set.Count);

            Assert.IsTrue(set.Remove(55));

            var expected = 50;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                ++expected;
            }

            Assert.AreEqual(5, set.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (var i = 5; i < 11; ++i)
            {
                set.Add(i);
            }

            for (var j = 5; j < 11; ++j)
            {
                Assert.IsTrue(set.Contains(j));
            }

            Assert.IsFalse(set.Contains(11));
            Assert.IsFalse(set.Contains(12));
            Assert.IsFalse(set.Contains(100));
        }

        [TestMethod]
        public void ClearTest()
        {
            for (var i = 0; i < 6; ++i)
            {
                set.Add(i);
            }

            set.Clear();

            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void CopyToTest()
        {
            var array = new int[10];

            for (var i = 0; i < 5; ++i)
            {
                set.Add(i);
            }

            set.CopyTo(array, 5);

            for (var j = 0; j < 5; ++j)
            {
                Assert.AreEqual(0, array[j]);
            }

            var index = 5;
            foreach (var current in set)
            {
                Assert.AreEqual(current, array[index]);
                ++index;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToIncorrectPositionTest()
        {
            var array = new int[2];

            for (var i = 0; i < 3; ++i)
            {
                set.Add(i);
            }

            set.CopyTo(array, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToTooSmallArrayTest()
        {
            var array = new int[2];

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            set.CopyTo(array, 0);
        }

        [TestMethod]
        public void ExceptWithTest()
        {
            var array = new int[5] { 0, 2, 3, 5, 7 };

            for (var i = 0; i < 6; ++i)
            {
                set.Add(i);
            }

            set.ExceptWith(array);

            Assert.IsFalse(set.Contains(0));
            Assert.IsTrue(set.Contains(1));
            Assert.IsFalse(set.Contains(2));
            Assert.IsFalse(set.Contains(3));
            Assert.IsTrue(set.Contains(4));
            Assert.IsFalse(set.Contains(5));

            Assert.AreEqual(2, set.Count);
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            var array = new int[5] { 0, 2, 3, 5, 7 };

            for (var i = 0; i < 6; ++i)
            {
                set.Add(i);
            }

            set.IntersectWith(array);

            Assert.IsTrue(set.Contains(0));
            Assert.IsFalse(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
            Assert.IsFalse(set.Contains(4));
            Assert.IsTrue(set.Contains(5));

            Assert.AreEqual(4, set.Count);
        }

        [TestMethod]
        public void IsSubsetOfTest()
        {
            var properSupersetArray = new int[6] { -1, 0, 1, 2, 3, 4 };
            var supersetArray = new int[4] { 0, 1, 2, 3 };
            var notSupersetArray = new int[5] { -2, 0, 1, 4, 5 };

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.IsSubsetOf(properSupersetArray));
            Assert.IsTrue(set.IsSubsetOf(supersetArray));
            Assert.IsFalse(set.IsSubsetOf(notSupersetArray));
        }

        [TestMethod]
        public void IsProperSubsetOfTest()
        {
            var properSupersetArray = new int[6] { -1, 0, 1, 2, 3, 4 };
            var supersetArray = new int[4] { 0, 1, 2, 3 };
            var notSupersetArray = new int[5] { -2, 0, 1, 4, 5 };

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.IsProperSubsetOf(properSupersetArray));
            Assert.IsFalse(set.IsProperSubsetOf(supersetArray));
            Assert.IsFalse(set.IsProperSubsetOf(notSupersetArray));
        }

        [TestMethod]
        public void IsSupersetOfTest()
        {
            var properSubsetArray = new int[4] { 0, 1, 2, 3 };
            var subsetArray = new int[5] { 0, 1, 2, 3, 4 };
            var notSubsetArray = new int[5] { -2, 0, 1, 4, 5 };

            for (var i = 0; i < 5; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.IsSupersetOf(properSubsetArray));
            Assert.IsTrue(set.IsSupersetOf(subsetArray));
            Assert.IsFalse(set.IsSupersetOf(notSubsetArray));
        }

        [TestMethod]
        public void IsProperSupersetOfTest()
        {
            var properSubsetArray = new int[4] { 0, 1, 2, 3 };
            var subsetArray = new int[5] { 0, 1, 2, 3, 4 };
            var notSubsetArray = new int[5] { -2, 0, 1, 4, 5 };

            for (var i = 0; i < 5; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.IsProperSupersetOf(properSubsetArray));
            Assert.IsFalse(set.IsProperSupersetOf(subsetArray));
            Assert.IsFalse(set.IsProperSupersetOf(notSubsetArray));
        }

        [TestMethod]
        public void OverlapsTest()
        {
            var overlappedArray = new int[4] { -1, 0, 1, 2 };
            var notOverlappedArray = new int[4] { 4, 5, 6, 7 };

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.Overlaps(overlappedArray));
            Assert.IsFalse(set.Overlaps(notOverlappedArray));
        }

        [TestMethod]
        public void SetEqualsTest()
        {
            var equalArray = new int[4] { 0, 1, 2, 3 };
            var notEqualArray = new int[4] { 4, 5, 6, 7 };

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            Assert.IsTrue(set.SetEquals(equalArray));
            Assert.IsFalse(set.SetEquals(notEqualArray));
        }

        [TestMethod]
        public void SymmetricExceptWithTest()
        {
            var array = new int[4] { -1, -2, 4, 5 };

            for (var i = -2; i < 4; ++i)
            {
                set.Add(i);
            }

            set.SymmetricExceptWith(array);

            var expected = 0;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                ++expected;
            }

            Assert.AreEqual(6, set.Count);
        }

        [TestMethod]
        public void UnionWithTest()
        {
            var array = new int[5] { -1, -2, 3, 4, 5 };

            for (var i = 0; i < 4; ++i)
            {
                set.Add(i);
            }

            set.UnionWith(array);

            var expected = -2;
            foreach (var current in set)
            {
                Assert.AreEqual(expected, current);
                ++expected;
            }

            Assert.AreEqual(8, set.Count);
        }

        private ISet<int> set;
    }
}
