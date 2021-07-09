﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace NameGeneratorLibrary
{
	public class WordGenerator
	{
		// Public Members
		public Language language;
		public PartOfSpeech partOfSpeech;

		// Enums
		public enum Language
        {
			EN,
        }

		public enum PartOfSpeech
        {
			adj,
			adv,
			noun,
        }

		// Constructors
		public WordGenerator(Language language = Language.EN)
        {
			this.language = language;
        }

		public PartOfSpeech? GetPartOfSpeech(string word)
        {
			List<string> words;

			foreach(PartOfSpeech partOfSpeech in Enum.GetValues(typeof(PartOfSpeech)).Cast<PartOfSpeech>().ToList())
            {
				words = GetWordList(partOfSpeech);

				if(words.Contains(word))
                {
					return partOfSpeech;
                }
            }

			return null;
        }

		public string GetWord(PartOfSpeech partOfSpeech)
        {
			Random rnd = new Random();
			List<string> words = GetWordList(partOfSpeech);
			string toReturn = words[rnd.Next(words.Count)];

			return toReturn;
		}

        public List<string> GetWords(PartOfSpeech partOfSpeech, int quantity)
        {
			List<string> toReturn = new List<string>();
			Random rnd = new Random();
			List<string> words = GetWordList(partOfSpeech);

			for(int i = 0; i < quantity; i++)
            {
				toReturn.Add(words[rnd.Next(words.Count)]);
            }

			return toReturn;
		}

		private List<string> GetWordList(PartOfSpeech partOfSpeech)
        {
			List<string> words = new List<string>();
			string resourceName = "NameGeneratorLibrary.LanguageFiles." + language.ToString() + '.' + partOfSpeech.ToString() + ".txt";

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
