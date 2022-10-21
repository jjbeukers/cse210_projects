using System;
//using Unit04.Game.TerminalService;


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
            string prompt = "What is your guess? (a-z) ";
            response = TerminalService.ReadText(prompt);

        }
    }
}