using System;
using System.Collections.Generic;
using NameGeneratorLibrary;

namespace NameGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            NameGenerator nameGenerator = new NameGenerator();
            NameGenerator.WordType[] format = { NameGenerator.WordType.adv, NameGenerator.WordType.adj, NameGenerator.WordType.noun };
            List<string> names = nameGenerator.GetNames(format, 10);
            string name = nameGenerator.GetName(format);

            foreach(string s in names)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(name);
        }
    }
}
