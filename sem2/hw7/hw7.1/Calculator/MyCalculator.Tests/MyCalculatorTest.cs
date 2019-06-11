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
        public void NumberButtonClickTest()
        {
            Assert.AreEqual("9", calculator.NumberButtonClick("9", ""));
            Assert.AreEqual("95", calculator.NumberButtonClick("5", "9"));
            Assert.AreEqual("950", calculator.NumberButtonClick("0", "95"));
        }

        [TestMethod]
        public void OperationButtonClickTest()
        {
            var textBox = "988";
            var label = "";
            (label, textBox) = calculator.OperationButtonClick("-", label, textBox);
            Assert.AreEqual("988", textBox);
            Assert.AreEqual("988 - ", label);

            textBox = calculator.NumberButtonClick("8", textBox);
            Assert.AreEqual("8", textBox);

            (label, textBox) = calculator.OperationButtonClick("/", label, textBox);
            Assert.AreEqual("980", textBox);
            Assert.AreEqual("988 - 8 / ", label);
            textBox = calculator.NumberButtonClick("0", textBox);

            (label, textBox) = calculator.ResultButtonClick(label, textBox);
            Assert.AreEqual("Cannot divide by zero", textBox);
            Assert.AreEqual("", label);
        }

        [TestMethod]
        public void ResultButtonClickTest()
        {
            var textBox = "555";
            var label = "";
            (label, textBox) = calculator.OperationButtonClick("/", label, textBox);
            textBox = calculator.NumberButtonClick("5", textBox);

            (label, textBox) = calculator.ResultButtonClick(label, textBox);
            Assert.AreEqual("", label);
            Assert.AreEqual("111", textBox);

            (label, textBox) = calculator.OperationButtonClick("+", label, textBox);
            textBox = calculator.NumberButtonClick("9", textBox);
            (label, textBox) = calculator.ResultButtonClick(label, textBox);
            Assert.AreEqual("", label);
            Assert.AreEqual("120", textBox);

            (label, textBox) = calculator.ResultButtonClick(label, textBox);
            Assert.AreEqual("", label);
            Assert.AreEqual("120", textBox);

            (label, textBox) = calculator.OperationButtonClick("/", label, textBox);
            textBox = calculator.NumberButtonClick("0", textBox);
            (label, textBox) = calculator.ResultButtonClick(label, textBox);
            Assert.AreEqual("", label);
            Assert.AreEqual("Cannot divide by zero", textBox);
        }

        [TestMethod]
        public void CommaButtonClickTest()
        {
            var textBox = "0";
            textBox = calculator.NumberButtonClick("5", textBox);
            textBox = calculator.CommaButtonClick(textBox);
            Assert.AreEqual("5,", textBox);

            textBox = calculator.CommaButtonClick(textBox);
            Assert.AreEqual("5,", textBox);

            textBox = "34";
            calculator.TextBoxShouldBeCleared = true;
            textBox = calculator.CommaButtonClick(textBox);
            Assert.AreEqual("0,", textBox);
        }

        [TestMethod]
        public void BackspaceButtonClickTest()
        {
            var textBox = "0";
            textBox = calculator.BackspaceButtonClick(textBox);
            Assert.AreEqual("0", textBox);

            textBox = calculator.NumberButtonClick("5", textBox);
            textBox = calculator.NumberButtonClick("6", textBox);

            textBox = calculator.BackspaceButtonClick(textBox);
            Assert.AreEqual("5", textBox);
        }

        [TestMethod]
        public void ClearButtonClickTest()
        {
            var textBox = "8751";
            var label = "8751 / ";

            (label, textBox) = calculator.ClearButtonClick(label, textBox);
            Assert.AreEqual("", label);
            Assert.AreEqual("0", textBox);
        }

        [TestMethod]
        public void PlusMinusButtonClickTest()
        {
            var textBox = "8751";
            textBox = calculator.PlusMinusButtonClick(textBox);

            Assert.AreEqual("-8751", textBox);

            textBox = calculator.PlusMinusButtonClick(textBox);
            Assert.AreEqual("8751", textBox);
        }

        private Calculator calculator;
    }
}
