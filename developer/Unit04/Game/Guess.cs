using System;


namespace Unit04.Game
{
   
    public class Guess
    {
        string response = "";

        public Guess()
        {
            // This is the method that is run when it creates a new guess in the director class
        }
        public void getGuess()
        {
            prompt = "What is your guess? (a-z) ";
            response = TerminalService.ReadText(prompt);

        }
    }
}