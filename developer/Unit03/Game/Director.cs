//using system;
using System.Collections.Generic;
using System.Globalization;

//
namespace Unit03.Game
{
     public class Director
    {
        Word word = new Word();
        private bool _isPlaying = true;
        private Guess guess = new Guess();
        private TerminalService terminalService = new TerminalService();
        int wrongGuesses = 0;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            wrongGuesses = 0;
          
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            char[] outputWord = new char[word.randomWord.Length*2];
            outputWord = word.Blanks();
            string temp = string.Concat(outputWord);
            // Call a function that draws the dashes for the word.
             terminalService.WriteText(temp);
            // Call a function that draws the parachute man.
            while (_isPlaying)
            {
                
                GetInputs(); // Ask the user for a letter guess
                outputWord=DoUpdates(outputWord); // Compare the letter to the letters in the word to see if there's a match
                
                //outputWord=DoOutputs(outputWord); // Call a function that draws the word with any correct guesses drawn
                // in and re-draws the parachute with the correct number of lines. 
                temp = string.Concat(outputWord);
                terminalService.WriteText(temp);
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
        private char[] DoUpdates(char[] outputWord)
        {
            int guessedRight = 0; // This should keep track of whether or not the guess was correct.
            // If it was correct, this will be greater than zero.
            // I guess this could be a boolean, too, but I like this because it works
            int index = 0;
            bool win = true; // Assume you win unless at least one letter doesn't match up.

           foreach (char l in word.randomWord)
           {
                string temp = l.ToString(); // you can't use the == operator to compare strings and 
                // characters. so this variable "temp" changes the character to a string. 
                
                if (guess.response == temp)
                {
                    outputWord[index] = guess.response[0]; //Hopefully, this will replace just the letter with
                    // the correct guess. 
                    guessedRight = 1;
                    
                } 
                if (l != outputWord[index])
                {
                    win = false;
                }
                index=index+2;
           }
           if (win == true)
           {
                _isPlaying = false;
                terminalService.WriteText("Congratulations, you win!");
           }
           // If guessedRight is still equal to zero after it runs the for loop, you know the 
           // Letter was not a match and we need to count the number of incorrect guesses
           // and update the parachute accordingly.
            if (guessedRight == 0)
            {
                wrongGuesses ++;
            } 
            if (wrongGuesses == 4)
            {
                _isPlaying = false;
                terminalService.WriteText("You lose!");
            }
            for (int i = wrongGuesses; i < 6; i++)
            {
                if (i == 0) 
                {
                    terminalService.WriteText(" ___ ");
                }
                if (i == 1)
                {
                    terminalService.WriteText("/___\\");
                }
                if (i == 2) 
                {
                    terminalService.WriteText("\\   / ");
                }  
                if (i == 3) 
                {
                    terminalService.WriteText(" \\ / ");
                }
                if (i == 4)
                {
                    if (wrongGuesses==4)
                    {
                        terminalService.WriteText("  x  ");
                    }
                    else
                    {
                        terminalService.WriteText("  0  ");
                    }
                } 
                if (i == 5)
                {
                    terminalService.WriteText(" /|\\ ");
                    terminalService.WriteText(" / \\ ");
                    terminalService.WriteText(" ");
                    terminalService.WriteText("^^^^^");
                }    
            }

            return outputWord;
        }

        /// <summary>
        /// 
        /// </summary>
        private void DoOutputs()
        {
           
            
            
            //if (_hider.IsFound())
            //{
            //    _isPlaying = false;
            //}
            
        }
    }
}