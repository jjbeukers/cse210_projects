using System;

namespace Unit04.Game.Casting
{
    // Let's make up the stones.

    class Stone : Actor
    {
        private int _stone;
        private int _velocity;
       
        public Stone()
        {
            Random random = new Random();
            _velocity = random.Next(4, 10);
            _stone = -10;
        }

        public int GetSpeed()
        {
            return _velocity;
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