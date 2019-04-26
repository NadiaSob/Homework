namespace Functions.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw6._1;

    [TestClass]
    public class FunctionsTest
    {
        [TestInitialize]
        public void Initialize()
        {
            functions = new Functions();
            list = new List<int>();
            newList = new List<int>();
        }

        [TestMethod]
        public void MapAdditionTest()
        {
            list.Add(1);
            list.Add(10);
            list.Add(100);

            newList = functions.Map(list, x => x + 100);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] + 100, newList[i]);
            }
        }

        [TestMethod]
        public void MapAdditionOfNegativeNumbersTest()
        {
            list.Add(-10);
            list.Add(20);
            list.Add(-300);

            newList = functions.Map(list, x => x + 15);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] + 15, newList[i]);
            }
        }

        [TestMethod]
        public void MapAdditionOfZeroTest()
        {
            list.Add(2);
            list.Add(10);
            list.Add(2463);

            newList = functions.Map(list, x => x + 0);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i], newList[i]);
            }
        }

        [TestMethod]
        public void MapSubtractionTest()
        {
            list.Add(200);
            list.Add(450);
            list.Add(3467);

            newList = functions.Map(list, x => x - 200);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] - 200, newList[i]);
            }
        }

        [TestMethod]
        public void MapSubtractionOfNegativeNumbersTest()
        {
            list.Add(-200);
            list.Add(10);
            list.Add(0);

            newList = functions.Map(list, x => x - 200);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] - 200, newList[i]);
            }
        }

        [TestMethod]
        public void MapSubtractionOfZeroTest()
        {
            list.Add(123);
            list.Add(4567);
            list.Add(89);

            newList = functions.Map(list, x => x - 0);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i], newList[i]);
            }
        }

        [TestMethod]
        public void MapMultiplicationTest()
        {
            list.Add(1);
            list.Add(20);
            list.Add(300);

            newList = functions.Map(list, x => x * 25);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] * 25, newList[i]);
            }
        }

        [TestMethod]
        public void MapMultiplicationOfNegativeNumbersTest()
        {
            list.Add(-1);
            list.Add(20);
            list.Add(-300);

            newList = functions.Map(list, x => x * (-10));

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] * (-10), newList[i]);
            }
        }

        [TestMethod]
        public void MapMultiplicationOfZeroTest()
        {
            list.Add(21);
            list.Add(222);
            list.Add(-50);

            newList = functions.Map(list, x => x * 0);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(0, newList[i]);
            }
        }

        [TestMethod]
        public void MapDivisionTest()
        {
            list.Add(4);
            list.Add(400);
            list.Add(240);

            newList = functions.Map(list, x => x / 4);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] / 4, newList[i]);
            }
        }

        [TestMethod]
        public void MapDivisionOfNegativeNumbersTest()
        {
            list.Add(-10);
            list.Add(-200);
            list.Add(-34560);

            newList = functions.Map(list, x => x / (-10));

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] / (-10), newList[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void MapDivisionByZeroTest()
        {
            list.Add(10);

            newList = functions.Map(list, x => x / 0);
        }

        [TestMethod]
        public void MapCalculationOfRemainderTest()
        {
            list.Add(206);
            list.Add(100);
            list.Add(34675);

            newList = functions.Map(list, x => x % 100);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] % 100, newList[i]);
            }
        }

        [TestMethod]
        public void MapComplexFunctionTest()
        {
            list.Add(10);
            list.Add(2);
            list.Add(1688);

            newList = functions.Map(list, x => x / 2 * 15 + 400 - 1);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i] / 2 * 15 + 400 - 1, newList[i]);
            }
        }

        [TestMethod]
        public void FilterEvenNumbersTest()
        {
            list.Add(1);
            list.Add(10);
            list.Add(100);

            newList = functions.Filter(list, x => x % 2 == 0);

            Assert.AreEqual(10, newList[0]);
            Assert.AreEqual(100, newList[1]);
        }

        [TestMethod]
        public void FilterZerosTest()
        {
            list.Add(124);
            list.Add(0);
            list.Add(1026);
            list.Add(0);

            newList = functions.Filter(list, x => x == 0);

            Assert.AreEqual(0, newList[0]);
            Assert.AreEqual(0, newList[1]);
        }

        [TestMethod]
        public void FilterPositiveNumbersTest()
        {
            list.Add(124);
            list.Add(-134);
            list.Add(0);
            list.Add(77);

            newList = functions.Filter(list, x => x > 0);

            Assert.AreEqual(124, newList[0]);
            Assert.AreEqual(77, newList[1]);
        }

        [TestMethod]
        public void FilterEveryNumberTest()
        {
            list.Add(55);
            list.Add(1256);
            list.Add(-88);
            list.Add(10);

            newList = functions.Filter(list, x => true);

            for (var i = 0; i < newList.Count; ++i)
            {
                Assert.AreEqual(list[i], newList[i]);
            }
        }

        [TestMethod]
        public void FoldAdditionTest()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);

            var testValue = functions.Fold(list, 100, (acc, elem) => acc + elem);

            Assert.AreEqual(160, testValue);
        }

        [TestMethod]
        public void FoldSubtractionTest()
        {
            list.Add(1243);
            list.Add(667);
            list.Add(0);

            var testValue = functions.Fold(list, 50000, (acc, elem) => acc - elem);

            Assert.AreEqual(48090, testValue);
        }

        [TestMethod]
        public void FoldMultiplicationTest()
        {
            list.Add(10);
            list.Add(22);
            list.Add(-3);

            var testValue = functions.Fold(list, 1, (acc, elem) => acc * elem);

            Assert.AreEqual(-660, testValue);
        }

        [TestMethod]
        public void FoldDivisionTest()
        {
            list.Add(-2);
            list.Add(5);
            list.Add(-1000);

            var testValue = functions.Fold(list, 10000, (acc, elem) => acc / elem);

            Assert.AreEqual(1, testValue);
        }

        [TestMethod]
        public void FoldComplexFunctionTest()
        {
            list.Add(1005);
            list.Add(7);
            list.Add(658);

            var testValue = functions.Fold(list, 5, (acc, elem) => acc * 5 - (elem % 10));

            Assert.AreEqual(457, testValue);
        }

        private Functions functions;
        private List<int> list;
        private List<int> newList;
    }
}
