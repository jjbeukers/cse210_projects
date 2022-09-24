using System;

namespace Prep1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is prep 1");

            Console.Write("What is your first name? ");
            string first = Console.ReadLine();

            Console.Write("What is your last name? ");
            string last = Console.ReadLine();

            Console.WriteLine($"Your name is {last}, {first} {last}");
        }
    }
}
