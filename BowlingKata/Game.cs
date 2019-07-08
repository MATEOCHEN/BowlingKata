namespace BowlingKata
{
    internal class Game
    {
        private int _score;
        private int _frame;
        private readonly int[] _scoreBox = new int[21];

        public void Roll(int pins)
        {
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
        }

        public int GetScore()
        {
            return _score;
        }
    }
}