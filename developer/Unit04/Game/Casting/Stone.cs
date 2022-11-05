namespace Unit04.Game.Casting
{
    // Let's make up the stones.

    class Stone : Actor
    {
        private int _stone;
    
        public Stone()
        {
            _stone = -10;
        }
        public int GetMessage()
        {
            return _stone;
        }
        public void SetMessage(int message)
        {
            _stone = message;
        }
    }
}