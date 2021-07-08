using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NameGeneratorLibrary
{
	public class NameGenerator
	{
		// Public Members
		public Language language;
		public WordType[] format;

		// Enums
		public enum Language
        {
			EN,
        }

		public enum WordType
        {
			adj,
			adv,
			noun,
        }

		// Constructors
		public NameGenerator(Language language = Language.EN)
        {
			this.language = language;
        }

		public string GetName(WordType[] format)
        {
			string toReturn = "";
			List<List<string>> names = new List<List<string>>();
			Random rnd = new Random();

			// Load word dictionaries
			foreach (WordType wordType in format)
			{
				names.Add(GetWords(wordType));
			}

			// Assign a word for each position in format
			for (int j = 0; j < format.Length; j++)
			{
				toReturn += names[j][rnd.Next(names[j].Count)];

				if (j < format.Length - 1)
				{
					toReturn += ' ';
				}
			}

			return toReturn;
		}

        public List<string> GetNames(WordType[] format, int quantity = 1)
        {
			List<string> toReturn = new List<string>();
			List<List<string>> names = new List<List<string>>();
			Random rnd = new Random();
			string temp;
			
			// Load word dictionaries
			foreach(WordType wordType in format)
            {
				names.Add(GetWords(wordType));
            }

			// Assign a word for each position in format for quantity
			for (int i = 0; i < quantity; i++)
			{
				temp = "";

				for(int j = 0; j < format.Length; j++)
				{
					temp += names[j][rnd.Next(names[j].Count)];

					if(j < format.Length - 1)
                    {
						temp += ' ';
                    }
				}

				toReturn.Add(temp);
			}

			return toReturn;
		}

		private List<string> GetWords(WordType wordType)
        {
			List<string> words = new List<string>();
			string resourceName = "NameGeneratorLibrary.LanguageFiles." + language.ToString() + '.' + wordType.ToString() + ".txt";

			try
			{
				Assembly assembly = GetType().Assembly;
				Stream stream = assembly.GetManifestResourceStream(resourceName);

				using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
				{
					string line = reader.ReadLine();

					while (line != null)
					{
						words.Add(line);
						//Console.WriteLine(line);
						line = reader.ReadLine();
					}

					reader.Close();
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Could not read file");
			}

			return words;
		}
	}
}
