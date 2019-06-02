namespace Game.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using hw6._2;

    [TestClass]
    public class GameTest
    {
        [TestInitialize]
        public void Initialize()
        {
            testGame = new Game("..\\..\\TestMap.txt");
        }

        [TestMethod]
        public void OnUpTest()
        {
            testGame.OnUp(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual('@', testGame.Map[1][2]);
        }

        [TestMethod]
        public void OnDownTest()
        {
            testGame.OnDown(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual('@', testGame.Map[3][2]);
        }

        [TestMethod]
        public void OnRightTest()
        {
            testGame.OnRight(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual('@', testGame.Map[2][3]);
        }

        [TestMethod]
        public void OnLeftTest()
        {
            testGame.OnLeft(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual('@', testGame.Map[2][1]);
        }

        [TestMethod]
        public void OnUpOutOfMapTest()
        {
            testGame.OnUp(this, EventArgs.Empty);
            testGame.OnUp(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual(' ', testGame.Map[1][2]);
            Assert.AreEqual('@', testGame.Map[0][2]);

            testGame.OnUp(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[1][2]);
            Assert.AreEqual('@', testGame.Map[0][2]);
        }

        [TestMethod]
        public void OnDownOutOfMapTest()
        {
            testGame.OnDown(this, EventArgs.Empty);
            testGame.OnDown(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual(' ', testGame.Map[3][2]);
            Assert.AreEqual('@', testGame.Map[4][2]);

            testGame.OnDown(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[3][2]);
            Assert.AreEqual('@', testGame.Map[4][2]);
        }

        [TestMethod]
        public void OnRightOutOfMapTest()
        {
            testGame.OnRight(this, EventArgs.Empty);
            testGame.OnRight(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual(' ', testGame.Map[2][3]);
            Assert.AreEqual('@', testGame.Map[2][4]);

            testGame.OnRight(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][3]);
            Assert.AreEqual('@', testGame.Map[2][4]);
        }

        [TestMethod]
        public void OnLeftOutOfMapTest()
        {
            testGame.OnLeft(this, EventArgs.Empty);
            testGame.OnLeft(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][2]);
            Assert.AreEqual(' ', testGame.Map[2][1]);
            Assert.AreEqual('@', testGame.Map[2][0]);

            testGame.OnLeft(this, EventArgs.Empty);
            Assert.AreEqual(' ', testGame.Map[2][1]);
            Assert.AreEqual('@', testGame.Map[2][0]);
        }

        [TestMethod]
        [ExpectedException(typeof(CrashingIntoWallException))]
        public void OnUpIntoWallTest()
        {
            testGame.OnRight(this, EventArgs.Empty);
            testGame.OnUp(this, EventArgs.Empty);
            testGame.OnUp(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(CrashingIntoWallException))]
        public void OnDownIntoWallTest()
        {
            testGame.OnRight(this, EventArgs.Empty);
            testGame.OnDown(this, EventArgs.Empty);
            testGame.OnDown(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(CrashingIntoWallException))]
        public void OnRightIntoWallTest()
        {
            testGame.OnUp(this, EventArgs.Empty);
            testGame.OnRight(this, EventArgs.Empty);
            testGame.OnRight(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(CrashingIntoWallException))]
        public void OnLeftIntoWallTest()
        {
            testGame.OnUp(this, EventArgs.Empty);
            testGame.OnLeft(this, EventArgs.Empty);
            testGame.OnLeft(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidSymbolsMapTest() => new Game("..\\..\\InvalidSymbolsMap.txt");

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TwoCharactersMapTest() => new Game("..\\..\\TwoCharactersMap.txt");

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void NoCharacterMapTest() => new Game("..\\..\\NoCharacterMap.txt");

        private Game testGame;
    }
}
