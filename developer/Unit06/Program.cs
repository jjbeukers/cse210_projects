using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = " Maze Runner";
        private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 10 ;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the robot
            Actor robot = new Actor();
            robot.SetText("0");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, 300 ));
            cast.AddActor("robot", robot);

            int path = 1;
            Random random = new Random();
            // COLS = 60, so the path can be created anywhere on the screen, but three short of 60 
            // because you don't want the path (which is 3 spaces wide) to run off the screen.
            path = random.Next(1, 57);

            cast = CreateArtifact(cast, path);

            // load the messages
            //List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();
               // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast, path);

            // test comment
        }

    // create the artifacts
        public static Cast CreateArtifact(Cast cast, int path)
        {
            Random random = new Random();
            for (int i = 0; i < COLS; i++)
            {
                //string text = ((char)random.Next(33, 126)).ToString();
                //string message = messages[i];

                // This is so we will jump over the path and no stones will be placed there. 
                if (i == path)
                {
                    i = i+3;
                }

                //int x = random.Next(1, COLS);
                int y = 1;
                Point position = new Point(i, y);
                position = position.Scale(CELL_SIZE);

                // Let's make the maze brown.
                Color color = new Color(160, 50, 0);

                // We'll keep the gems and stones in the for loop, and now we just 
                // have to create one or the other, not both.

                
                //Gem gem = new Gem();
                //gem.SetText("*");
                //gem.SetFontSize(FONT_SIZE);
                //gem.SetColor(color);
                //gem.SetPosition(position);
                //gem.SetMessage(10);
                //cast.AddActor("gems", gem);
                               
                Maze maze = new Maze();
                maze.SetText("#");
                maze.SetFontSize(FONT_SIZE);
                maze.SetColor(color);
                maze.SetPosition(position);
                maze.SetMessage(-10);
                cast.AddActor("mazes", maze);

                    
                
            }

            return cast;        
        }
    }
}