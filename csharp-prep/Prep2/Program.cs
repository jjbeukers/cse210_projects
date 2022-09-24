using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 2");

            // I copied in my python code to just modify it to C# and the program didn't like
            // that at all.

            // Core Requirement 1: Ask the user for their percentage in the class. Then write a series 
            // of if/elif statements to print out the corresponding letter grade.

            Console.Write("What percentage do you have in the class? ");
            string user_input = Console.ReadLine();
            int percentage = int.Parse(user_input);

            if (percentage >= 90)
            {
                Console.WriteLine("You have an A! ");
            }
            if (percentage >= 80)
            {
                Console.WriteLine("You have a B.");
            }
            if (percentage >= 70)
            {
                Console.WriteLine("You have a C.");
            }
            if (percentage >= 60)
            {
                Console.WriteLine("You have a D.");
            }
            if (percentage <= 50)
            {
                Console.WriteLine("You have an F.");
            } 

            //  Core Requirement 2: Notify the user if they passed or failed the class 
            // assuming you must have at least 70% to pass the class.

            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations, you passed the class!");
            }
            else if (percentage < 70)
            {
                Console.WriteLine("I'm sorry, you did not pass. Don't give up! You can do this! ");
            }

            // Core Requirement 3: Don't include the print statements in the if/elif statements. 
            // Rather, use one print statement.

            string letter = "";

            if (percentage >= 90)
            {
                letter = "A";
            }
            if (percentage >=80)
            {
                letter = "B";
            }
            if (percentage >= 70)
            {
                letter = "C";
            }
            if (percentage >= 60)
            {
                letter = "D";
            }
            if (percentage < 60)
            {
                letter = "F";
            }

            //Console.Write($"Your final grade is {letter}");

            // Stretch: Print the grade with a corresponding +/-

            int ones = percentage / 10;
            string plus = "";

            if (ones > 7)
            {
                plus = "+";
            }
            if (ones < 3)
            {
                plus = "-";
            }
            else
            {
                plus = "";
            }
            Console.Write($"Your final grade is {letter}{plus}. ");

        }
    }
}
