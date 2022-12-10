using System;

namespace Unit04.Game.Casting
{
    // Let's make up the maze.

    class Maze : Actor
    {
        private int _maze;
        private int _velocity;
       
        public Maze()
        {
            //Random random = new Random();
            //There should be a constant called "inital starting velocity" which we can then set 
            // velocity equal to.
            _velocity = 2;
            _maze = -10;
        }

        public int GetSpeed()
        {
            return _velocity;
        }

        public void SetSpeed(int speed)
        {
            _velocity = speed;
        }

        public int GetMessage()
        {
            return _maze;
        }
        public void SetMessage(int message)
        {
            _maze = message;
        }
    }
}