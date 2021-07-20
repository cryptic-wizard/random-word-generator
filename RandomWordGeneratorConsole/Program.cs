using System;
using System.Collections.Generic;
using RandomWordGenerator;

namespace RandomWordGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WordGenerator wordGenerator = new WordGenerator();
            WordGenerator.PartOfSpeech partOfSpeech = WordGenerator.PartOfSpeech.noun;
            List<string> words = wordGenerator.GetWords(partOfSpeech, 10);
            string word = wordGenerator.GetWord(partOfSpeech);

            foreach(string s in words)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(word);
        }
    }
}