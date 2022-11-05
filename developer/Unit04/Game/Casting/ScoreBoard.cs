namespace Unit04.Game.Casting
{
    class Scoreboard
    {
        private int _score;

        public Scoreboard()
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