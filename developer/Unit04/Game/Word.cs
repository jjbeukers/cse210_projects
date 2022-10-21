using System;


namespace Unit04.Game
{
    // To begin with, I just want one word here that I know rather than having it generate a random
    // word. That way I can more easily troubleshoot. Once the program is working, I will make a 
    // list of words and have the program randomly select one word. 
    public class Word
    {
        private Word()
        {
            Random random new Random();
            List<string> wordDictionary = new List<string> {"temple"};
            int index = random.Next(wordDictionary.Count);
            string randomWord = wordDictionary[index];
            string outputWord;

        }
    }
}