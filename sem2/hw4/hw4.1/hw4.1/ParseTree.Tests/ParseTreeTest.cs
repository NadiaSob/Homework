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
            Assert.AreEqual(3, parseTree.Result());
        }

        [TestMethod]
        public void SubtractionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(- -10 -350)");
            Assert.AreEqual(340, parseTree.Result());
        }

        [TestMethod]
        public void AdditionTest()
        {
            parseTree = new ParseTree("(+ 8 5)");
            Assert.AreEqual(13, parseTree.Result());
        }

        [TestMethod]
        public void AdditionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(+ -400 -20)");
            Assert.AreEqual(-420, parseTree.Result());
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            parseTree = new ParseTree("(* 6 7)");
            Assert.AreEqual(42, parseTree.Result());
        }

        [TestMethod]
        public void MultiplicationOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(* -30 -12)");
            Assert.AreEqual(360, parseTree.Result());
        }

        [TestMethod]
        public void DivisionTest()
        {
            parseTree = new ParseTree("(/ 8 2)");
            Assert.AreEqual(4, parseTree.Result());
        }

        [TestMethod]
        public void DivisionOfNegativeNumbersTest()
        {
            parseTree = new ParseTree("(/ -760 -10)");
            Assert.AreEqual(76, parseTree.Result());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            parseTree = new ParseTree("(/ 5467 0)");
            parseTree.Result();
        }

        [TestMethod]
        public void ComplexExpressionTest()
        {
            parseTree = new ParseTree("(/ (- (+ 7 3) (* 2 3)) 2)");
            Assert.AreEqual(2, parseTree.Result());

            parseTree = new ParseTree("(* (+ (/ (- 38 8) 10) 497) 2)");
            Assert.AreEqual(1000, parseTree.Result());
        }

        [TestMethod]
        public void ExpressionWithNoSpacesAfterAndBeforeBracketsTest()
        {
            parseTree = new ParseTree("(*(+(/(- 38 8)10)497)2)");
            Assert.AreEqual(1000, parseTree.Result());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IncorrectInputTest()
        {
            parseTree = new ParseTree("2+2");
            parseTree.Result();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoInputTest()
        {
            parseTree = new ParseTree("");
            parseTree.Result();
        }

        private ParseTree parseTree;
    }
}
