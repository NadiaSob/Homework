namespace Calculator.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw2._3;

    [TestClass]
    public class CalculatorTest
    {
        [TestInitialize]
        public void Initialize()
        {
            string tempExpression = "";
            calculator = new Calculator(tempExpression);
            listStack = new ListStack();
            arrayStack = new ArrayStack();
        }

        [TestMethod]
        public void AdditionUsingListStackTest()
        {
            calculator.Expression = "2 2 +";
            Assert.AreEqual(4, calculator.Calculation(listStack));
            calculator.Expression = "16 212 +";
            Assert.AreEqual(228, calculator.Calculation(listStack));
            calculator.Expression = "0 0 +";
            Assert.AreEqual(0, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void AdditionUsingArrayStackTest()
        {
            calculator.Expression = "2 2 +";
            Assert.AreEqual(4, calculator.Calculation(arrayStack));
            calculator.Expression = "16 212 +";
            Assert.AreEqual(228, calculator.Calculation(arrayStack));
            calculator.Expression = "0 0 +";
            Assert.AreEqual(0, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void SubtractionUsingListStackTest()
        {
            calculator.Expression = "4 1 -";
            Assert.AreEqual(3, calculator.Calculation(listStack));
            calculator.Expression = "7138 38 -";
            Assert.AreEqual(7100, calculator.Calculation(listStack));
            calculator.Expression = "7 0 -";
            Assert.AreEqual(7, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void SubtractionUsingArrayStackTest()
        {
            calculator.Expression = "4 1 -";
            Assert.AreEqual(3, calculator.Calculation(arrayStack));
            calculator.Expression = "7138 38 -";
            Assert.AreEqual(7100, calculator.Calculation(arrayStack));
            calculator.Expression = "7 0 -";
            Assert.AreEqual(7, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void MultiplicationUsingListStackTest()
        {
            calculator.Expression = "5 5 *";
            Assert.AreEqual(25, calculator.Calculation(listStack));
            calculator.Expression = "10 400 *";
            Assert.AreEqual(4000, calculator.Calculation(listStack));
            calculator.Expression = "75 0 *";
            Assert.AreEqual(0, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void MultiplicationUsingArrayStackTest()
        {
            calculator.Expression = "5 5 *";
            Assert.AreEqual(25, calculator.Calculation(arrayStack));
            calculator.Expression = "10 400 *";
            Assert.AreEqual(4000, calculator.Calculation(arrayStack));
            calculator.Expression = "75 0 *";
            Assert.AreEqual(0, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void DivisionUsingListStackTest()
        {
            calculator.Expression = "8 4 /";
            Assert.AreEqual(2, calculator.Calculation(listStack));
            calculator.Expression = "10 10 /";
            Assert.AreEqual(1, calculator.Calculation(listStack));
            calculator.Expression = "210 7 /";
            Assert.AreEqual(30, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void DivisionUsingArrayStackTest()
        {
            calculator.Expression = "8 4 /";
            Assert.AreEqual(2, calculator.Calculation(arrayStack));
            calculator.Expression = "10 10 /";
            Assert.AreEqual(1, calculator.Calculation(arrayStack));
            calculator.Expression = "210 7 /";
            Assert.AreEqual(30, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroUsingListStackTest()
        {
            calculator.Expression = "58 0 /";
            var temp = calculator.Calculation(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroUsingArrayStackTest()
        {
            calculator.Expression = "58 0 /";
            var temp = calculator.Calculation(arrayStack);
        }

        [TestMethod]
        public void GettingNegativeResultUsingListStackTest()
        {
            calculator.Expression = "3 36 -";
            Assert.AreEqual(-33, calculator.Calculation(listStack));
            calculator.Expression = "0 1 -";
            Assert.AreEqual(-1, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void GettingNegativeResultUsingArrayStackTest()
        {
            calculator.Expression = "3 36 -";
            Assert.AreEqual(-33, calculator.Calculation(arrayStack));
            calculator.Expression = "0 1 -";
            Assert.AreEqual(-1, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void CalculationNegativeNumbersUsingListStackTest()
        {
            calculator.Expression = "6 -36 +";
            Assert.AreEqual(-30, calculator.Calculation(listStack));
            calculator.Expression = "-55 -5 -";
            Assert.AreEqual(-50, calculator.Calculation(listStack));
            calculator.Expression = "-5135 -1 *";
            Assert.AreEqual(5135, calculator.Calculation(listStack));
            calculator.Expression = "-56 -8 /";
            Assert.AreEqual(7, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void CalculationNegativeNumbersUsingArrayStackTest()
        {
            calculator.Expression = "6 -36 +";
            Assert.AreEqual(-30, calculator.Calculation(arrayStack));
            calculator.Expression = "-55 -5 -";
            Assert.AreEqual(-50, calculator.Calculation(arrayStack));
            calculator.Expression = "-5135 -1 *";
            Assert.AreEqual(5135, calculator.Calculation(arrayStack));
            calculator.Expression = "-56 -8 /";
            Assert.AreEqual(7, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void ComplexExpressionUsingListStackTest()
        {
            calculator.Expression = "9 6 - 2 1 + * 3 /";
            Assert.AreEqual(3, calculator.Calculation(listStack));

            calculator.Expression = "35 12 * 830 -411 1234 + - /";
            Assert.AreEqual(60, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void ComplexExpressionUsingArrayStackTest()
        {
            calculator.Expression = "9 6 - 2 1 + * 3 /";
            Assert.AreEqual(3, calculator.Calculation(arrayStack));

            calculator.Expression = "35 12 * 830 -411 1234 + - /";
            Assert.AreEqual(60, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        public void ExpressionWithNoOperationsUsingListStackTest()
        {
            calculator.Expression = "123456";
            Assert.AreEqual(123456, calculator.Calculation(listStack));
        }

        [TestMethod]
        public void ExpressionWithNoOperationsUsingArrayStackTest()
        {
            calculator.Expression = "123456";
            Assert.AreEqual(123456, calculator.Calculation(arrayStack));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithSeveralSpacesUsingListStackTest()
        {
            calculator.Expression = "9  6 -    2    1 + * 3  /";
            var temp = calculator.Calculation(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithSeveralSpacesUsingArrayStackTest()
        {
            calculator.Expression = "9  6 -    2    1 + * 3  /";
            var temp = calculator.Calculation(arrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoSpacesUsingListStackTest()
        {
            calculator.Expression = "96-21+*3/";
            var temp = calculator.Calculation(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoSpacesUsingArrayStackTest()
        {
            calculator.Expression = "96-21+*3/";
            var temp = calculator.Calculation(arrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWrongSymbolsUsingListStackTest()
        {
            calculator.Expression = "IWantToCalculateTwoPlusTwo";
            var temp = calculator.Calculation(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWrongSymbolsUsingArrayStackTest()
        {
            calculator.Expression = "IWantToCalculateTwoPlusTwo";
            var temp = calculator.Calculation(arrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputUsingListStackTest()
        {
            calculator.Expression = "";
            var temp = calculator.Calculation(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputUsingArrayStackTest()
        {
            calculator.Expression = "";
            var temp = calculator.Calculation(arrayStack);
        }

        private Calculator calculator;
        private ListStack listStack;
        private ArrayStack arrayStack;
    }
}
