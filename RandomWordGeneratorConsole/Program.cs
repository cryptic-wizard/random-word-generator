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

            List<string> adv = wordGenerator.GetWords(WordGenerator.PartOfSpeech.adv, 10);
            List<string> adj = wordGenerator.GetWords(WordGenerator.PartOfSpeech.adj, 10);
            List<string> noun = wordGenerator.GetWords(WordGenerator.PartOfSpeech.noun, 10);

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(adv[i] + ' ' + adj[i] + ' ' + noun[i]);
            }
        }
    }
}