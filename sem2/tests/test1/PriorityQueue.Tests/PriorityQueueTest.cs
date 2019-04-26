namespace PriorityQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using test1;

    [TestClass]
    public class PriorityQueueTest
    {
        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void IsNotEmptyTest()
        {
            queue.Enqueue("abc", 1);
            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void OneElementEnqueueAndDequeueTest()
        {
            queue.Enqueue("Test string", 1);
            Assert.AreEqual("Test string", queue.Dequeue());
        }

        [TestMethod]
        public void IsEmptyAfterDequeueingTest()
        {
            queue.Enqueue("Test string", 1);
            Assert.AreEqual("Test string", queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void ComplexEnqueueAndDequeueTest()
        {
            queue.Enqueue("Test string 3", 1);
            queue.Enqueue("Test string 2", 2);
            queue.Enqueue("Test string 1", 3);
            Assert.AreEqual("Test string 1", queue.Dequeue());
            Assert.AreEqual("Test string 2", queue.Dequeue());
            Assert.AreEqual("Test string 3", queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueAndDequeueInRandomOrderTest()
        {
            queue.Enqueue("Test string 3", 4);
            queue.Enqueue("Test string 4", 2);
            queue.Enqueue("Test string 2", 7);
            queue.Enqueue("Test string 1", 10);
            Assert.AreEqual("Test string 1", queue.Dequeue());
            Assert.AreEqual("Test string 2", queue.Dequeue());
            Assert.AreEqual("Test string 3", queue.Dequeue());
            Assert.AreEqual("Test string 4", queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueAndDequeueWithNegativeNumbersTest()
        {
            queue.Enqueue("String 1", 5);
            queue.Enqueue("String 3", -8);
            queue.Enqueue("String 2", 0);
            Assert.AreEqual("String 1", queue.Dequeue());
            Assert.AreEqual("String 2", queue.Dequeue());
            Assert.AreEqual("String 3", queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueAndDequeueWithTheSamePriorityTest()
        {
            queue.Enqueue("Something", 6);
            queue.Enqueue("Something 1", 2);
            queue.Enqueue("Something 2", 2);
            Assert.AreEqual("Something", queue.Dequeue());
            Assert.AreEqual("Something 1", queue.Dequeue());
            Assert.AreEqual("Something 2", queue.Dequeue());

            queue.Enqueue("Something 1", 7);
            queue.Enqueue("Something 2", 7);
            queue.Enqueue("Something", 0);
            Assert.AreEqual("Something 1", queue.Dequeue());
            Assert.AreEqual("Something 2", queue.Dequeue());
            Assert.AreEqual("Something", queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(QueueIsEmptyException))]
        public void DequeueFromEmptyQueueTest()
        {
            string temp = queue.Dequeue();
        }

        [TestMethod]
        public void EnqueueAndDequeueWithBigNumbersTest()
        {
            queue.Enqueue("String 1", 50000);
            queue.Enqueue("String 3", 0);
            queue.Enqueue("String 4", -623423);
            queue.Enqueue("String 2", 49999);
            Assert.AreEqual("String 1", queue.Dequeue());
            Assert.AreEqual("String 2", queue.Dequeue());
            Assert.AreEqual("String 3", queue.Dequeue());
            Assert.AreEqual("String 4", queue.Dequeue());
        }

        PriorityQueue queue;
    }
}
