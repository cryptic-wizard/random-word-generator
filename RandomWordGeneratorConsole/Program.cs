using System;
using System.Collections.Generic;
using RandomWordGenerator;
using static RandomWordGenerator.WordGenerator;

namespace RandomWordGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WordGenerator wordGenerator = new WordGenerator();

            List<string> adv = wordGenerator.GetWords(PartOfSpeech.adv, 10);
            List<string> adj = wordGenerator.GetWords(PartOfSpeech.adj, 10);
            List<string> noun = wordGenerator.GetWords(PartOfSpeech.noun, 10);

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(adv[i] + ' ' + adj[i] + ' ' + noun[i]);
            }
        }
    }
}