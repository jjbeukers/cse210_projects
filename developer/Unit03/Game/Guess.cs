using System;


namespace Unit03.Game
{
   
    public class Guess
    {
        public string response = "";
        TerminalService terminalService = new TerminalService();

        public Guess()
        {
            // This is the method that is run when it creates a new guess in the director class
        }
        public void getGuess()
        {
            string prompt = "What is your guess? (a-z) ";
            response = terminalService.ReadText(prompt);

        }
    }
}