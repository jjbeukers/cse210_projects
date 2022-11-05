namespace Unit04.Game.Casting
{
    class ScoreBoard
    {
        private int _score;

        public ScoreBoard()
        {
             _score = 0;
        }
        public int GetScore()
        {
            return _score;
        }
        public void SetScore(int message)
        {
            _score = _score + message;
        }
    }
}