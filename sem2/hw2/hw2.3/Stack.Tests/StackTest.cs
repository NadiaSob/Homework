namespace Stack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw2._3;

    [TestClass]
    public class StackTest
    {
        [TestInitialize]
        public void Initialize()
        {
            listStack = new ListStack();
            arrayStack = new ArrayStack();
        }

        public void IsEmptyTest(IStack stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyUsingListStackTest()
        {
            IsEmptyTest(listStack);
        }

        [TestMethod]
        public void IsEmptyUsingArrayStackTest()
        {
            IsEmptyTest(arrayStack);
        }

        public void PushTest(IStack stack)
        {
            stack.Push(10);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void PushUsingListStackTest()
        {
            PushTest(listStack);
        }

        [TestMethod]
        public void PushUsingArrayStackTest()
        {
            PushTest(arrayStack);
        }

        public void PopTest(IStack stack)
        {
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void PopUsingListStackTest()
        {
            PopTest(listStack);
        }

        [TestMethod]
        public void PopUsingArrayStackTest()
        {
            PopTest(arrayStack);
        }

        public void TwoElementsPopTest(IStack stack)
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void TwoElementsPopUsingListStackTest()
        {
            TwoElementsPopTest(listStack);
        }

        [TestMethod]
        public void TwoElementsPopUsingArrayStackTest()
        {
            TwoElementsPopTest(arrayStack);
        }

        public void PopFromEmptyStackTest(IStack stack)
        {
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackUsingListStackTest()
        {
            PopFromEmptyStackTest(listStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackUsingArrayStackTest()
        {
            PopFromEmptyStackTest(arrayStack);
        }

        private ListStack listStack;
        private ArrayStack arrayStack;
    }
}
