using System;
using System.Collections.Generic;


namespace Unit03.Game
{
    // To begin with, I just want one word here that I know rather than having it generate a random
    // word. That way I can more easily troubleshoot. Once the program is working, I will make a 
    // list of words and have the program randomly select one word. 
    public class Word
    {
        public char[] outputWord = " ";
        public string randomWord = " ";

        public Word()
        {
            Random random = new Random();
            List<string> wordDictionary = new List<string> {"temple"};
            int index = random.Next(wordDictionary.Count);
            randomWord = wordDictionary[index];
            outputWord = new char[randomWord.Length];
            
            //loop placing a '_' in every space of the word?
            for (int i = 0; i<randomWord.Length-1; i++)
            {
               outputWord[i] = '_';     
            }
        }
    }
}