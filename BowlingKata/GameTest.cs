using System;
using NUnit.Framework;

namespace BowlingKata
{
    internal class Game
    {
        private int _score;
        private int _frame;
        private readonly int[] _scoreBox = new int[21];
        private int count = 1;

        public void Roll(int pins)
        {
            if (count == 12)
            {
                _frame += 0;
            }
            _score += pins;
            _scoreBox[_frame] = pins;

            if (IsStrike())
            {
                _score += StrikeBonus();
            }
            else if (IsSpare())
            {
                _score += SpareBonus();
            }

            NextFrame(pins);
        }

        private int SpareBonus()
        {
            return _scoreBox[_frame];
        }

        private int StrikeBonus()
        {
            if ((_scoreBox[_frame - 1] == 0 || _scoreBox[_frame] == 0) && _frame <= 18)
            {
                return 20;
            }

            if (IsFinal())
            {
                return _scoreBox[_frame];
            }
            return _scoreBox[_frame - 1] + _scoreBox[_frame];
        }

        private bool IsFinal()
        {
            return _frame > 18;
        }

        private bool IsStrike()
        {
            if (_frame >= 3)
            {
                return _scoreBox[_frame - 2] == 10 || _scoreBox[_frame - 3] == 10;
            }

            return false;
        }

        private bool IsSpare()
        {
            if ((_frame % 2 == 0 && _frame != 0) &&
                (_scoreBox[_frame - 2] != 0 && _scoreBox[_frame - 1] != 0))
            {
                return _scoreBox[_frame - 1] + _scoreBox[_frame - 2] == 10;
            }
            return false;
        }

        public void NextFrame(int pins)
        {
            if (pins == 10 && _frame < 18)
            {
                _frame += 2;
            }
            else
            {
                _frame++;
            }

            count++;
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

        private void ProcessRolling(int rollCount, int pins)
        {
            for (var i = 0; i < rollCount; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}