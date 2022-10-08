using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> cards = new List<Card>();
        bool _isPlaying = true;
        // A winning guess earns 100 points, a wrong guess loses 75 points.
        int win = 100;
        int loss = -75;
        // We start the game with 300 points. 
        int _totalScore = 300;

        int currentCard;
        int nextCard;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            Card card = new Card();
            cards.Add(card);   
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {

            // If this works, it should set my first card, and then I can
            // call this in my getUpdates() section. This should only
            // happen once since it isn't in the while loop.
            Card card = new Card();
            card.Draw();
            currentCard = card.value;
            string guess;

            while (_isPlaying)
            {
                guess = GetInputs();
                DoUpdates(guess);
                DoOutputs();
                currentCard = nextCard;
            }
        }

        /// <summary>
        /// Asks the user if they want to plsy.
        /// </summary>
        public string GetInputs()
        {
            
            // We're going to ask if the person would like to play
            Console.Write("Draw a card? [y/n] ");
            string cardDraw = Console.ReadLine();
            if (_isPlaying = (cardDraw == "y"))
            {
                // Now we will display the card 
            Console.WriteLine($"The card is {currentCard}");
            // We will get input for the user to guess if they think the
            // next card will be higher or lower. 
            Console.Write("Will the next card be higher or lower? [h/l] ");
            string guess = Console.ReadLine();

            return guess;
            }
            
            else
            {
                return "quit";
            }
            
            

        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates(string guess)
        {
            int score = 0;
            
            Card card = new Card();

            if (!_isPlaying)
            {
                return;
            }
            card.Draw();
            // Setting the next card to the draw value.
            nextCard = card.value;

            if (guess == "h")
            {
                if (currentCard < nextCard)
                {
                    score = win;
                    Console.WriteLine("You guessed correctly!");
                }    
                else
                {
                    score = loss;
                    Console.WriteLine("You lose! ");
                }
            }
            if (guess == "l")
            {
                if (currentCard < nextCard)
                {
                    score = loss;
                    Console.WriteLine("You lose! ");
                }
                else
                {
                    score = win;
                    Console.WriteLine("You guessed correctly!");
                }    
            }

            _totalScore += score;

            
        }

        /// <summary>
        /// Displays the card and the score. 
        /// </summary>
        public void DoOutputs()
        {
            if (!_isPlaying)
            {
                return;
            }

            Console.WriteLine($"The next card is: {nextCard}");
            Console.WriteLine($"Your score is: {_totalScore}\n");
            _isPlaying = (_totalScore > 0);
        }
    }
}


