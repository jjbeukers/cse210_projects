using System;
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
        private bool _isPlaying = true; 
        int _count = 0;
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
        public void StartGame(Cast cast,double path)
        {
            double weight = 2.5;
            _videoService.OpenWindow();
            while (_isPlaying)
            { 

                //weight the direction of the path so it veers further
                if (path<10)
                {
                    weight = 1.1;
                }
                else if (path>50)
                {
                    weight = 0.9;
                }
                Random random = new Random();
                double pathChange = 0;
                int direction = random.Next(1, 300);

                if (direction < 100 / weight)
                {
                    pathChange = -0.26;
                }
                else if(direction > 300 / weight)
                {
                    pathChange = 0.26;
                }
                else
                {
                    pathChange = 0;
                }
            
                path = path + pathChange;
                
                GetInputs(cast);
                DoUpdates(cast,path);
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
        private void DoUpdates(Cast cast, double path)
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
                    //cast = Unit04.Program.CreateArtifact(cast,1);
                }
                // I had to do maxY-11 because if it was just maxY it wouldn't catch before
                // looping to the top again.
                else if (gem.GetPosition().GetY() > maxY-11 )
                {
                    cast.RemoveActor("gems", gem);

                    //cast = Unit04.Program.CreateArtifact(cast,1);
                }
            
            }
            foreach (Maze maze in mazes)
            {
                Point temp = new Point(0, maze.GetSpeed());

                maze.SetVelocity(temp);
                maze.MoveNext(maxX, maxY);

                if ((maze.GetPosition().GetX()) < robot.GetPosition().GetX() + 8 && (maze.GetPosition().GetX()) > robot.GetPosition().GetX() - 8 
                && robot.GetPosition().GetY() - 8 < (maze.GetPosition().GetY()) && robot.GetPosition().GetY() + 8 > (maze.GetPosition().GetY()))
                {
                    _isPlaying = false;
                    banner.SetText("You lose! Better luck next time! "); 
                }
                
                else if (maze.GetPosition().GetY() > maxY-14 )
                {
                    cast.RemoveActor("mazes", maze);
                }

                
            }
            // Add a new line each time the maze shifts down.
            // How many "move nexts" in a row? 
            // Create a counter and when the count = 16 we are going to call
            // the CreateArtifact method.
            
            _count++ ;
            if (_count == 8)
            {
                cast = Unit04.Program.CreateArtifact(cast,(int)path);
                _count = 0;
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