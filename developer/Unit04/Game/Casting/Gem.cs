using System;

namespace Unit04.Game.Casting
{
    // Let's make up the gems.

    class Gem : Actor
    {
        private int _gem;
        private int _velocity;
    
        public Gem()
        {
            Random random = new Random();
            _velocity = random.Next(4, 10);
            _gem = 10;
        }
        // This will return a random velocity value for each gem.
        public int GetSpeed()
        {
            return _velocity;
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