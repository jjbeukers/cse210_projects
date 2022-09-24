using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 4");
            List<int> numbers = new List<int>();
            int userInput = -1;
            while (userInput != 0)
            {
                Console.Write("Enter a list of numbers. Type 0 when finished. ");
                string userNumber = Console.ReadLine();
                userInput = int.Parse(userNumber);

                // How to add input to the list? Syntax = list name.add(variable)
                numbers.Add(userInput);
            }

            // Now to calculate the sum, average, and max
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum of the numbers in the list is {sum}");

            float average = sum / numbers.Count;
            Console.WriteLine($"The average of the list of numbers is {average}");

            // DOesn't appear to be a built in "max" function.
            //int maxNumber = Max.Math(numbers);

            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The largest number is {max}"); 
        }
    }
}
