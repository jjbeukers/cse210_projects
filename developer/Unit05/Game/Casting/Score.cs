using System;


namespace Unit05.Game.Casting
{
    public class Score : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._points += points;
            SetText($"Score: {this._points}");
        }
    }
}