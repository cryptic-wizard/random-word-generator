using System;
using System.Collections.Generic;
using CrypticWizard.RandomWordGenerator;
using static CrypticWizard.RandomWordGenerator.WordGenerator;

namespace CrypticWizard.RandomWordGeneratorConsole
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

            Console.WriteLine();

            List<PartOfSpeech> pattern = new List<PartOfSpeech>();
            pattern.Add(PartOfSpeech.adv);
            pattern.Add(PartOfSpeech.adj);
            pattern.Add(PartOfSpeech.noun);

            List<string> patterns = wordGenerator.GetPatterns(pattern, ' ', 10);

            foreach(string s in patterns)
            {
                Console.WriteLine(s);
            }

            wordGenerator = new WordGenerator(seed:123456);
            wordGenerator.SetSeed(654321);
        }
    }
}