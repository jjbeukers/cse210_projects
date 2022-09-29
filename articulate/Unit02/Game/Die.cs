using System;


namespace Unit02.Game
{
    // TODO: Implement the Die class as follows...
    // 1) Add the class declaration. Use the following class comment.

        /// <summary>
        /// A small cube with a different number of spots on each of its six sides.
        /// 
        /// The responsibility of Die is to keep track of its currently rolled value and the points its
        /// worth.
        /// </summary> 
        // Jen's Comments: I need to create a new class called die. What is the syntax? Following the 
        // Template of the director code, it looks like you identify it first as public, then class
        // then followed by the name of the class, which here is going to be "die"
        public class Die
        {
            // Okay, we need to track the values of the dice rolled, and the corresponding number
            // of points for the round. What will that look like? We create global variables set
            // to zero first? I have to use points and value for my variables. That's what
            // is used in the director program
            public int value = 0; 
            public int points = 0;


    // 2) Create the class constructor. Use the following method comment.

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
            public Die()
            {

            }
        
    
    // 3) Create the Roll() method. Use the following method comment.
        
        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
            public void Roll()
            {
                Random random = new Random();
                value = random.Next(1, 7);

                // We need to tell the program how to score the dice.
                if (value == 1)
                {
                    points = 100;
                }
                else if (value == 5)
                {
                    points = 50;
                }
                else
                {
                    points = 0;
                }
            }
        }    
}