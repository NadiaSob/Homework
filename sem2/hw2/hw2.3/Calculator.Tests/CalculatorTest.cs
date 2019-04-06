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
            listStack = new ListStack();
            arrayStack = new ArrayStack();
        }

        public void AdditionTest(IStack stack)
        {
            calculator = new Calculator("16 212 +");
            Assert.AreEqual(228, calculator.Calculate(stack));
            calculator = new Calculator("0 0 +");
            Assert.AreEqual(0, calculator.Calculate(stack));
        }

        [TestMethod]
        public void AdditionUsingListStackTest()
        {
            AdditionTest(listStack);
        }

        [TestMethod]
        public void AdditionUsingArrayStackTest()
        {
            AdditionTest(arrayStack);
        }

        public void SubtractionTest(IStack stack)
        {
            calculator = new Calculator("7138 38 -");
            Assert.AreEqual(7100, calculator.Calculate(stack));
            calculator = new Calculator("7 0 -");
            Assert.AreEqual(7, calculator.Calculate(stack));
        }

        [TestMethod]
        public void SubtractionUsingListStackTest()
        {
            SubtractionTest(listStack);
        }

        [TestMethod]
        public void SubtractionUsingArrayStackTest()
        {
            SubtractionTest(arrayStack);
        }

        public void MultiplicationTest(IStack stack)
        {
            calculator = new Calculator("10 400 *");
            Assert.AreEqual(4000, calculator.Calculate(stack));
            calculator = new Calculator("75 0 *");
            Assert.AreEqual(0, calculator.Calculate(stack));
        }

        [TestMethod]
        public void MultiplicationUsingListStackTest()
        {
            MultiplicationTest(listStack);
        }

        [TestMethod]
        public void MultiplicationUsingArrayStackTest()
        {
            MultiplicationTest(arrayStack);
        }

        public void DivisionTest(IStack stack)
        {
            calculator = new Calculator("10 10 /");
            Assert.AreEqual(1, calculator.Calculate(stack));
            calculator = new Calculator("210 7 /");
            Assert.AreEqual(30, calculator.Calculate(stack));
        }

        [TestMethod]
        public void DivisionUsingListStackTest()
        {
            DivisionTest(listStack);
        }

        [TestMethod]
        public void DivisionUsingArrayStackTest()
        {
            DivisionTest(arrayStack);
        }

        public void DivisionByZeroTest(IStack stack)
        {
            calculator = new Calculator("58 0 /");
            var temp = calculator.Calculate(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroUsingListStackTest()
        {
            DivisionByZeroTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroUsingArrayStackTest()
        {
            DivisionByZeroTest(arrayStack);
        }

        public void GettingNegativeResultTest(IStack stack)
        {
            calculator = new Calculator("3 36 -");
            Assert.AreEqual(-33, calculator.Calculate(stack));
            calculator = new Calculator("0 1 -");
            Assert.AreEqual(-1, calculator.Calculate(stack));
        }

        [TestMethod]
        public void GettingNegativeResultUsingListStackTest()
        {
            GettingNegativeResultTest(listStack);
        }

        [TestMethod]
        public void GettingNegativeResultUsingArrayStackTest()
        {
            GettingNegativeResultTest(arrayStack);
        }

        public void CalculationNegativeNumbersTest(IStack stack)
        {
            calculator = new Calculator("6 -36 +");
            Assert.AreEqual(-30, calculator.Calculate(stack));
            calculator = new Calculator("-55 -5 -");
            Assert.AreEqual(-50, calculator.Calculate(stack));
            calculator = new Calculator("-5135 -1 *");
            Assert.AreEqual(5135, calculator.Calculate(stack));
            calculator = new Calculator("-56 -8 /");
            Assert.AreEqual(7, calculator.Calculate(stack));
        }

        [TestMethod]
        public void CalculationNegativeNumbersUsingListStackTest()
        {
            CalculationNegativeNumbersTest(listStack);
        }

        [TestMethod]
        public void CalculationNegativeNumbersUsingArrayStackTest()
        {
            CalculationNegativeNumbersTest(arrayStack);
        }

        public void ComplexExpressionTest(IStack stack)
        {
            calculator = new Calculator("9 6 - 2 1 + * 3 /");
            Assert.AreEqual(3, calculator.Calculate(stack));

            calculator = new Calculator("35 12 * 830 -411 1234 + - /");
            Assert.AreEqual(60, calculator.Calculate(stack));
        }

        [TestMethod]
        public void ComplexExpressionUsingListStackTest()
        {
            ComplexExpressionTest(listStack);
        }

        [TestMethod]
        public void ComplexExpressionUsingArrayStackTest()
        {
            ComplexExpressionTest(arrayStack);
        }

        public void ExpressionWithNoOperationsTest(IStack stack)
        {
            calculator = new Calculator("123456");
            Assert.AreEqual(123456, calculator.Calculate(stack));
        }

        [TestMethod]
        public void ExpressionWithNoOperationsUsingListStackTest()
        {
            ExpressionWithNoOperationsTest(listStack);
        }

        [TestMethod]
        public void ExpressionWithNoOperationsUsingArrayStackTest()
        {
            ExpressionWithNoOperationsTest(arrayStack);
        }

        public void ExpressionWithSeveralSpacesTest(IStack stack)
        {
            calculator = new Calculator("9  6 -    2    1 + * 3  /");
            var temp = calculator.Calculate(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithSeveralSpacesUsingListStackTest()
        {
            ExpressionWithSeveralSpacesTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithSeveralSpacesUsingArrayStackTest()
        {
            ExpressionWithSeveralSpacesTest(arrayStack);
        }

        public void ExpressionWithNoSpacesTest(IStack stack)
        {
            calculator = new Calculator("96-21+*3/");
            var temp = calculator.Calculate(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoSpacesUsingListStackTest()
        {
            ExpressionWithNoSpacesTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithNoSpacesUsingArrayStackTest()
        {
            ExpressionWithNoSpacesTest(arrayStack);
        }

        public void ExpressionWithWrongSymbolsTest(IStack stack)
        {
            calculator = new Calculator("IWantToCalculateTwoPlusTwo");
            var temp = calculator.Calculate(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWrongSymbolsUsingListStackTest()
        {
            ExpressionWithWrongSymbolsTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ExpressionWithWrongSymbolsUsingArrayStackTest()
        {
            ExpressionWithWrongSymbolsTest(arrayStack);
        }

        public void NoInputTest(IStack stack)
        {
            calculator = new Calculator("");
            var temp = calculator.Calculate(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputUsingListStackTest()
        {
            NoInputTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputUsingArrayStackTest()
        {
            NoInputTest(arrayStack);
        }

        private Calculator calculator;
        private IStack listStack;
        private IStack arrayStack;
    }
}
