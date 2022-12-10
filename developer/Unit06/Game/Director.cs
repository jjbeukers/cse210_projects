using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using Unit04.Game;

namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        ScoreBoard scoreboard = new ScoreBoard();

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = _keyboardService.GetDirection();
            robot.SetVelocity(velocity);     

        
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> gems = cast.GetActors("gems");
            List<Actor> mazes = cast.GetActors("mazes");

        
            // banner.SetText("Score: ");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Gem gem in gems)
            {
                Point temp = new Point(0, gem.GetSpeed());

                gem.SetVelocity(temp);
                gem.MoveNext(maxX, maxY);

                // There's an issue here with the velocity and y position of the gem. The statement
                // needs to be re-written so that it will "catch" the gem if the x position is equal
                // and the y position is within a certain margin.

                if (robot.GetPosition().GetX().Equals(gem.GetPosition().GetX()) && robot.GetPosition().GetY() < gem.GetPosition().GetY())    
                {
                    int message = gem.GetMessage();
                    scoreboard.SetScore(message);
                    banner.SetText("Score: " + scoreboard.GetScore().ToString()); 
                    cast.RemoveActor("gems", gem);
                    cast = Unit04.Program.CreateArtifact(cast,1);
                }
                // I had to do maxY-11 because if it was just maxY it wouldn't catch before
                // looping to the top again.
                else if (gem.GetPosition().GetY() > maxY-11 )
                {
                    cast.RemoveActor("gems", gem);

                    cast = Unit04.Program.CreateArtifact(cast,1);
                }
            
            }
            foreach (Maze maze in mazes)
            {
                Point temp = new Point(0, maze.GetSpeed());

                maze.SetVelocity(temp);
                maze.MoveNext(maxX, maxY);

                if (robot.GetPosition().GetX().Equals(maze.GetPosition().GetX()) && robot.GetPosition().GetY() < maze.GetPosition().GetY())
                {
                    int message = maze.GetMessage();
                    scoreboard.SetScore(message);
                    banner.SetText("Score: " + scoreboard.GetScore().ToString()); 
                    cast.RemoveActor("mazes", maze);
                    cast = Unit04.Program.CreateArtifact(cast,1);
                }
                
                else if (maze.GetPosition().GetY() > maxY-14 )
                {
                    cast.RemoveActor("mazes", maze);
                    cast = Unit04.Program.CreateArtifact(cast,1);
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }
    }
}