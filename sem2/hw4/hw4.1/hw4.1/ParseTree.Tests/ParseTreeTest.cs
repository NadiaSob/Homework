namespace ParseTree.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw4._1;

    [TestClass]
    public class ParseTreeTest
    {
        [TestMethod]
        public void SubtractionTest()
        {
            parseTree = new ParseTree("(- 8 5)");
            Assert.AreEqual(parseTree.Result(), 3);
        }

        [TestMethod]
        public void SubtractionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(- -10 -350)");
            Assert.AreEqual(parseTree.Result(), 340);
        }

        [TestMethod]
        public void AdditionTest()
        {
            parseTree = new ParseTree("(+ 8 5)");
            Assert.AreEqual(parseTree.Result(), 13);
        }

        [TestMethod]
        public void AdditionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(+ -400 -20)");
            Assert.AreEqual(parseTree.Result(), -420);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            parseTree = new ParseTree("(* 6 7)");
            Assert.AreEqual(parseTree.Result(), 42);
        }

        [TestMethod]
        public void MultiplicationOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(* -30 -12)");
            Assert.AreEqual(parseTree.Result(), 360);
        }

        [TestMethod]
        public void DivisionTest()
        {
            parseTree = new ParseTree("(/ 8 2)");
            Assert.AreEqual(parseTree.Result(), 4);
        }

        [TestMethod]
        public void DivisionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(/ -760 -10)");
            Assert.AreEqual(parseTree.Result(), 76);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            parseTree = new ParseTree("(/ 5467 0)");
            int temp = parseTree.Result();
        }

        [TestMethod]
        public void ComplexExpressionTest()
        {
            parseTree = new ParseTree("(/ (- (+ 7 3) (* 2 3)) 2)");
            Assert.AreEqual(parseTree.Result(), 2);

            parseTree = new ParseTree("(* (+ (/ (- 38 8) 10) 497) 2)");
            Assert.AreEqual(parseTree.Result(), 1000);
        }

        [TestMethod]
        public void ExpressionWithNoSpacesAfterAndBeforeBracketsTest()
        {
            parseTree = new ParseTree("(*(+(/(- 38 8)10)497)2)");
            Assert.AreEqual(parseTree.Result(), 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IncorrectInputTest()
        {
            parseTree = new ParseTree("2+2");
            int temp = parseTree.Result();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputTest()
        {
            parseTree = new ParseTree("");
            int temp = parseTree.Result();
        }

        private ParseTree parseTree;
    }
}
