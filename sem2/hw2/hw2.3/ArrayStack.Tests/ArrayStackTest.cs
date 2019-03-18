namespace ArrayStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw2._3;

    [TestClass]
    public class ArrayStackTest
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new ArrayStack();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void PushTest()
        {
            stack.Push(10);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void TwoElementsPopTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackTest()
        {
            stack.Pop();
        }

        private ArrayStack stack;
    }
}
