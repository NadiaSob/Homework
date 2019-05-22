namespace MyCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using homework;

    [TestClass]
    public class MyCalculatorTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            Assert.AreEqual(228, Calculator.Calculate("+", 16.5, 211.5));
            Assert.AreEqual(0, Calculator.Calculate("+", 0, 0));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            Assert.AreEqual(7099.4, Calculator.Calculate("-", 7138, 38.6));
            Assert.AreEqual(7, Calculator.Calculate("-", 7, 0));
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            Assert.AreEqual(4000, Calculator.Calculate("*", 10, 400));
            Assert.AreEqual(0, Calculator.Calculate("*", 75.7, 0));
        }

        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(1, Calculator.Calculate("/", 10, 10));
            Assert.AreEqual(30, Calculator.Calculate("/", 210, 7));
        }

        [TestMethod]
        public void DivisionByZeroTest()
        {
            Assert.AreEqual(double.PositiveInfinity, Calculator.Calculate("/", 10, 0));
        }

        [TestMethod]
        public void GettingNegativeResultTest()
        {
            Assert.AreEqual(-33, Calculator.Calculate("-", 3, 36));
            Assert.AreEqual(-1, Calculator.Calculate("-", 0, 1));
        }

        [TestMethod]
        public void CalculationNegativeNumbersTest()
        {
            Assert.AreEqual(-29.9, Calculator.Calculate("+", 6.1, -36));
            Assert.AreEqual(45.7, Calculator.Calculate("-", -5, -50.7));
            Assert.AreEqual(5135, Calculator.Calculate("*", -5135, -1));
            Assert.AreEqual(7, Calculator.Calculate("/", -56, -8));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoOperationTest()
        {
            Calculator.Calculate("", 1, 1);
        }
    }
}
