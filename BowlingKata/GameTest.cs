using NUnit.Framework;

namespace BowlingKata
{
    internal class Game
    {
        private int _score;

        public void Roll(int pins)
        {
            _score += pins;
        }

        public int GetScore()
        {
            return _score;
        }
    }

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

        private void ProcessRolling(int rollCount, int pins)
        {
            for (var i = 0; i < rollCount; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}