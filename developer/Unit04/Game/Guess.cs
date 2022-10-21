using System;


namespace Unit04.Game
{
   
    public class Guess
    {
        public Guess()
        {
            // This is the method that is run when it creates a new guess in the director class
        }
        public string getGuess()
        {
            prompt = "What is your guess? (a-z) ";
            response = TerminalService.ReadText(prompt);

        }
    }
