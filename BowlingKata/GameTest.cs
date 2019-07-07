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
            for (var i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }
            Assert.AreEqual(0, _game.GetScore());
        }
    }
}