namespace MyCalculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using homework;

    [TestClass]
    public class MyCalculatorTest
    {
        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void AdditionTest()
        {
            Assert.AreEqual(228, calculator.Calculate("+", 16.5, 211.5));
            Assert.AreEqual(0, calculator.Calculate("+", 0, 0));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            Assert.AreEqual(7099.4, calculator.Calculate("-", 7138, 38.6));
            Assert.AreEqual(7, calculator.Calculate("-", 7, 0));
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            Assert.AreEqual(4000, calculator.Calculate("*", 10, 400));
            Assert.AreEqual(0, calculator.Calculate("*", 75.7, 0));
        }

        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(1, calculator.Calculate("/", 10, 10));
            Assert.AreEqual(30, calculator.Calculate("/", 210, 7));
        }

        [TestMethod]
        public void DivisionByZeroTest()
        {
            Assert.AreEqual(double.PositiveInfinity, calculator.Calculate("/", 10, 0));
        }

        [TestMethod]
        public void GettingNegativeResultTest()
        {
            Assert.AreEqual(-33, calculator.Calculate("-", 3, 36));
            Assert.AreEqual(-1, calculator.Calculate("-", 0, 1));
        }

        [TestMethod]
        public void CalculationNegativeNumbersTest()
        {
            Assert.AreEqual(-29.9, calculator.Calculate("+", 6.1, -36));
            Assert.AreEqual(45.7, calculator.Calculate("-", -5, -50.7));
            Assert.AreEqual(5135, calculator.Calculate("*", -5135, -1));
            Assert.AreEqual(7, calculator.Calculate("/", -56, -8));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoOperationTest()
        {
            calculator.Calculate("", 1, 1);
        }

        private Calculator calculator;
    }
}
