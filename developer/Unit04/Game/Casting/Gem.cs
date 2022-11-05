namespace Unit04.Game.Casting
{
    // Let's make up the gems.

    class Gem : Actor
    {
        private int _gem;
    
        public Gem()
        {
            _gem = 10;
        }
        public int GetMessage()
        {
            return _gem;
        }
        public void SetMessage(int message)
        {
            _gem = message;
        }
    }
}