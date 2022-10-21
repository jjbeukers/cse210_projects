//using System.Collections.Generic;
//using Unit04.Game.Guess;
//using Unit04.Game.Word;
//using Unit04.Game.TerminalService;


namespace Unit04.Game
{
     public class Director
    {
        private Word _word = new Word();
        private bool _isPlaying = true;
        private Guess _guess = new Guess();
        //private TerminalService _terminalService = new TerminalService();


        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            int _wrongGuesses = 0;
            // Call a function that draws the dashes for the word.
            // Call a function that draws the parachute man.
            while (_isPlaying)
            {
                GetInputs(); // Ask the user for a letter guess
                DoUpdates(); // Compare the letter to the letters in the word to see if there's a match
                DoOutputs(); // Call a function that draws the word with any correct guesses drawn
                // in and re-draws the parachute with the correct number of lines. 
            }
        }

        /// <summary>
        // Ask the user for a letter guess
        /// </summary>
        private void GetInputs()
        {
            guess.getGuess(); // Write this class to get a guess from the user
        }

        /// <summary>
        // Compare the letter guessed to the letters in the word to see if it's in there.
        // Also create an if/else statement to catch the number of incorrect guesses.
        // Update the parachute.
        /// </summary>
        private void DoUpdates()
        {
            int guessedRight = 0; // This should keep track of whether or not the guess was correct.
            // If it was correct, this will be greater than zero.
            // I guess this could be a boolean, too, but I like this because it works


           foreach (char l in guess.randomWord)
           {
                if (guess.response == l)
                {
                    outputWord[i] == guess.response; //Hopefully, this will replace just the letter with
                    // the correct guess. 
                    guessedRight = 1;
                } 
           }
           // If guessedRight is still equal to zero after it runs the for loop, you know the 
           // Letter was not a match and we need to count the number of incorrect guesses
           // and update the parachute accordingly.
            if (guessedRight == 0)
            {
                _wrongGuesses ++;
            } 
            for (int i = _wrongGuesses; i < 6; i++)
            {
                if (i == 0) 
                {
                    Console.WriteLine(" ___ ");
                }
                if (i == 1)
                {
                    Console.WriteLine("/___\\");
                }
                if (i == 2) 
                {
                    Console.WriteLine("\\   / ");
                }  
                if (i == 3) 
                {
                    Console.WriteLine(" \\ / ");
                }
                if (i == 4)
                {
                    Console.WriteLine("  0  ");
                } 
                if (i == 5)
                {
                    Console.WriteLine(" /|\\ ");
                    Console.WriteLine(" / \\ ");
                    Console.WriteLine(" ");
                    Console.WriteLine("^^^^^");
                }    
            }


        }

        /// <summary>
        /// 
        /// </summary>
        private void DoOutputs()
        {
           
            
            
            if (_hider.IsFound())
            {
                _isPlaying = false;
            }
            
        }
    }
}