// Jen Beukers
// 9/22/22
// CSE 210
// Tic-Tac_Toe Assignment

using System;
using System.Collections.Generic;

namespace SandboxProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayGreeting();
            List<string> board = NewBoard();

            // Shall we always start with the same player? 
            string CurrentPlayer = "X";
            

            while (!GameOver(board))
            {
                DisplayBoard(board);

                int squareChoice = GetUserChoice(CurrentPlayer);
                UpdateBoard(board, CurrentPlayer, squareChoice);

                CurrentPlayer = CurrentTurn(CurrentPlayer);
            }
            // Should I display my winner message here in the main function? Or in the
            // WhoWon function? How do I get the program to recognize who won? The outline 
            //just says "Good game, thanks for playing. Let's try that with a {current player}
            // inside the statement. That didn't work. Let's go generic and go to sleep.
            //if (CurrentPlayer == "X")
            //{
            //    winner = "O";
            //}

            //Console.WriteLine($"Congratulations, {winner}! You won! ");
            Console.WriteLine("Good game! Thanks for playing!");
        }

            // While loop. Loop for the back and forth between X and O until
            // Someone wins.
            // Create a GameOver function:
            // Inside this function have a Winner function and a tie function.

                // If the player was X, switch it to O.
                // If the player was O, switch it to X.
                // Maybe a function in the while loop?
                // And another function to see if there is a winner.
            
        // How to store the board? A list (of strings) with 9 things in it.
        // Add the numbers in, then when the user makes a play,
        // Change the numbers to the appropriate mark.

        // Function to determine whose turn it is.
        static void DisplayBoard(List<string> board)
        {
            // Lists are a zero based index. Stard with zero
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("- + - + -");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("- + - + -");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");       
        }

        static void UpdateBoard(List<string>board, string CurrentPlayer, int squareChoice)
        {
            int boardIndex = squareChoice - 1;
            board[boardIndex] = CurrentPlayer;
        }

        static string CurrentTurn(string CurrentPlayer)
        {
            string nextTurn = "X";
            if (CurrentPlayer == "X")
            {
                nextTurn = "O";
            }

            return nextTurn;
        }

        static bool GameOver(List<string> board)
        {
            // Nest 2 functions in here. One determines if there is a winner,
            // One determines if it's a tie.
            // Boolean variable. Does C# assume it's false? 
            bool GameOver = false;
            
            //This condition will be false, unless someone has won. So now we nest the WhoWon function
            // In here to let it know when the game is over. 

            if (WhoWon(board, "X")||WhoWon(board, "Y"))
            {
                GameOver = true;
            }
            
            return GameOver;
        }

        static bool WhoWon(List<string>board, string player)
        {
            // Here, we need to write out all of the winning possibilities so 
            // it checks for a win.
            
            bool WhoWon = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                ||(board[3] == player && board[4] == player && board[5] == player)
                ||(board[6] == player && board[7] == player && board[8] == player)
                ||(board[0] == player && board[3] == player && board[6] == player)
                ||(board[1] == player && board[4] == player && board[7] == player)
                ||(board[2] == player && board[5] == player && board[8] == player)
                ||(board[0] == player && board[4] == player && board[8] == player)
                ||(board[2] == player && board[4] == player && board[6] == player)
            )
            {
                WhoWon = true;
            }
            return WhoWon;
        }
        static int GetUserChoice(string CurrentPlayer)
        {
            Console.Write($"{CurrentPlayer}'s Turn to chose a square (1-9). ");
            int squareChoice = int.Parse(Console.ReadLine());

            return squareChoice;
        }

        static List<string> NewBoard()
        {
            List<string> board = new List<string>();
            // This should be a loop. Look at this later.
            board.Add("1");
            board.Add("2");
            board.Add("3");
            board.Add("4");
            board.Add("5");
            board.Add("6");
            board.Add("7");
            board.Add("8");
            board.Add("9");

            return board;
        }

        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to the Tic-Tac-Toe game! ");
        }
    }
}
