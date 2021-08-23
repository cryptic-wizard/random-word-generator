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
            List<string> adj = wordGenerator.GetWords(WordGenerator.PartOfSpeech.adj, 10);
            List<string> adj2 = wordGenerator.GetWords(WordGenerator.PartOfSpeech.adj, 10);
            List<string> noun = wordGenerator.GetWords(WordGenerator.PartOfSpeech.noun, 10);

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(adj[i] + ' ' + adj2[i] + ' ' + noun[i]);
            }
        }
    }
}