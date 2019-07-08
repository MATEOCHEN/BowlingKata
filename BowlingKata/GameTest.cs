using System;
using NUnit.Framework;

namespace BowlingKata
{
    public class Tests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TestAllZeros()
        {
            ProcessRolling(20, 0);
            Assert.AreEqual(0, _game.GetScore());
        }

        [Test]
        public void TestAllOnes()
        {
            ProcessRolling(20, 1);
            Assert.AreEqual(20, _game.GetScore());
        }

        [Test]
        public void TestOneSpare()
        {
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(3);
            ProcessRolling(17, 0);

            Assert.AreEqual(16, _game.GetScore());
        }

        [Test]
        public void TestOneStrike()
        {
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(5);
            ProcessRolling(16, 0);

            Assert.AreEqual(26, _game.GetScore());
        }

        [Test]
        public void TestAllPerfectGame()
        {
            ProcessRolling(12, 10);
            Assert.AreEqual(300, _game.GetScore());
        }

        [Test]
        public void TestAllFives()
        {
            ProcessRolling(21, 5);
            Assert.AreEqual(150, _game.GetScore());
        }

        private void ProcessRolling(int rollCount, int pins)
        {
            for (var i = 0; i < rollCount; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}