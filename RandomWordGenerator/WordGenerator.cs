using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace RandomWordGenerator
{
	public class WordGenerator
	{
		// Public Members
		public PartOfSpeech? partOfSpeech;
		public Language language;

		// Private Members
		private static Random rnd = new Random();
		private bool preload = false;
		private List<string> adj;
		private List<string> adv;
		private List<string> art;
		private List<string> noun;
		private List<string> verb = new List<string>();

		// Enums
		public enum Language
        {
			EN,
        }

		public enum PartOfSpeech
        {
			adj,
			adv,
			art,
			noun,
			verb,
        }

		// Constructors
		/// <summary>
		/// Creates a new WordGenerator instance
		/// </summary>
		/// <param name="language"></param>
		/// <param name="preload"> Set to false in memory-constrained applications </param>
		public WordGenerator(Language language = Language.EN, bool preload = true)
        {
			this.language = language;

			if(preload)
            {
				adj = GetWordList(PartOfSpeech.adj);
				adv = GetWordList(PartOfSpeech.adv);
				art = GetWordList(PartOfSpeech.art);
				noun = GetWordList(PartOfSpeech.noun);
				verb = GetWordList(PartOfSpeech.verb);
				this.preload = true;
			}
        }

		/// <summary>
		/// Set Language and reload dictionaries if preload is set
		/// </summary>
		/// <param name="language"></param>
		public void SetLanguage(Language language)
        {
			this.language = language;

			if (preload)
			{
				preload = false;
				adj = GetWordList(PartOfSpeech.adj);
				adv = GetWordList(PartOfSpeech.adv);
				art = GetWordList(PartOfSpeech.art);
				noun = GetWordList(PartOfSpeech.noun);
				verb = GetWordList(PartOfSpeech.verb);
				preload = true;
			}
		}

		/// <summary>
		/// Gets a list of possible parts of speech of a word
		/// </summary>
		/// <param name="word"> </param>
		/// <returns> a list of parts of speech or null if word not found </returns>
		public List<PartOfSpeech> GetPartsOfSpeech(string word)
        {
			List<string> words;
			List<PartOfSpeech> partsOfSpeech = new List<PartOfSpeech>();

			foreach(PartOfSpeech partOfSpeech in Enum.GetValues(typeof(PartOfSpeech)).Cast<PartOfSpeech>().ToList())
            {
				words = GetWordList(partOfSpeech);

				if(words.Contains(word))
                {
					partsOfSpeech.Add(partOfSpeech);
                }
            }

			if(partsOfSpeech.Count != 0)
            {
				return partsOfSpeech;
            }
			else
            {
				return null;
			}
        }

		/// <summary>
		/// Gets a word with the field member part of speech
		/// </summary>
		/// <returns> a word or null if this.partOfSpeech is null </returns>
		public string GetWord()
        {
			if(partOfSpeech == null)
            {
				return null;
            }

			List<string> words = GetWordList((PartOfSpeech)partOfSpeech);
			string toReturn = words[rnd.Next(words.Count)];

			return toReturn;
		}

		/// <summary>
		/// Gets a word with a specified part of speech
		/// </summary>
		/// <param name="partOfSpeech"></param>
		/// <returns> a word </returns>
		public string GetWord(PartOfSpeech partOfSpeech)
        {
			List<string> words = GetWordList(partOfSpeech);
			string toReturn = words[rnd.Next(words.Count)];

			return toReturn;
		}

		/// <summary>
		/// Gets a list of words with this.partOfSpeech
		/// </summary>
		/// <param name="quantity"> number of words to return </param>
		/// <returns> words or null if this.partOfSpeech is null </returns>
		public List<string> GetWords(int quantity)
		{
			if (partOfSpeech == null)
			{
				return null;
			}

			List<string> words = new List<string>();
			List<string> wordList = GetWordList((PartOfSpeech)partOfSpeech);
			string word;
			bool duplicate;

			if(quantity >= wordList.Count)
            {
				foreach(string s in wordList)
                {
					words.Add(s);
                }
            }
			else
            {
				for (int i = 0; i < quantity; i++)
				{
					word = wordList[rnd.Next(wordList.Count)];
					duplicate = false;

					foreach(string s in words)
                    {
						char[] a = s.ToCharArray();
						char[] b = word.ToCharArray();

						if(a.Length != b.Length)
                        {
							duplicate = false;
                        }
						else
                        {
							duplicate = true;

							for(int j = 0; j < a.Length; j++)
                            {
								if (a[j] != b[j])
								{
									duplicate = false;
								}
							}

						}

                    }
					if(duplicate)
                    {
						Console.WriteLine("Duplicate = " + word);
						i--;
                    }
					else
                    {
						words.Add(wordList[rnd.Next(wordList.Count)]);
					}
				}
			}

			return words;
		}

		/// <summary>
		/// Gets a list of words with the specified part of speech
		/// </summary>
		/// <param name="partOfSpeech"></param>
		/// <param name="quantity"> number of words to return </param>
		/// <returns> words </returns>
		public List<string> GetWords(PartOfSpeech partOfSpeech, int quantity)
        {
            List<string> wordList = GetWordList(partOfSpeech);
			List<string> words = wordList;

			// Prevent returning more words than exist in the list
			if (quantity >= wordList.Count)
			{
				return words;
			}
			else
            {
				// Remove words until the correct amount remains
				// faster than randomly guessing indexes
				// guaranteed to be in alphabetical order
				for(int i = wordList.Count; i > quantity; i--)
                {
					words.RemoveAt(rnd.Next(words.Count));
                }
            }

			return words;
		}

		public string GetPattern(List<PartOfSpeech> partsOfSpeech, char delimiter)
        {
			string pattern = "";

			for(int i = 0; i < partsOfSpeech.Count; i++)
            {
				pattern += GetWord(partsOfSpeech[i]);

				if(i != partsOfSpeech.Count - 1)
                {
					pattern += delimiter;
                }
			}

			return pattern;
        }

		public List<string> GetPatterns(List<PartOfSpeech> partsOfSpeech, int quantity, char delimiter)
        {
			List<string> patterns = new List<string>();
			string pattern;

			for(int i = 0; i < quantity; i++)
            {
				pattern = "";

				for (int j = 0; j < partsOfSpeech.Count; j++)
				{
					pattern += GetWord(partsOfSpeech[j]);

					if (j != partsOfSpeech.Count - 1)
					{
						pattern += delimiter;
					}
				}

				patterns.Add(pattern);
			}

			return patterns;
        }

		/// <summary>
		/// Reads a word list with the specified part of speech from embedded resources
		/// </summary>
		/// <param name="partOfSpeech"></param>
		/// <returns> a list of all words with the specified part of speech </returns>
		public List<string> GetWordList(PartOfSpeech partOfSpeech)
        {
			if (preload)
			{
				if (partOfSpeech == PartOfSpeech.adj)
				{
					return adj;
				}
				else if (partOfSpeech == PartOfSpeech.adv)
				{
					return adv;
				}
				else if (partOfSpeech == PartOfSpeech.art)
				{
					return art;
				}
				else if (partOfSpeech == PartOfSpeech.noun)
				{
					return noun;
				}
				else if (partOfSpeech == PartOfSpeech.verb)
				{
					return verb;
				}
			}

			List<string> words = new List<string>();
			
			try
			{
				Assembly assembly = GetType().Assembly;
				string assemblyName = assembly.FullName.Split(',').First();
				string resourceName = assemblyName + ".LanguageFiles." + language.ToString() + '.' + partOfSpeech.ToString() + ".txt";
				Stream stream = assembly.GetManifestResourceStream(resourceName);

				using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
				{
					string line = reader.ReadLine();

					while (line != null)
					{
						words.Add(line);
						line = reader.ReadLine();
					}

					reader.Close();
				}
			}
			catch (Exception)
			{
				Console.WriteLine("ERROR - Could not read file");
			}

			return words;
		}

		/// <summary>
		/// Check if word is a specific part of speech
		/// </summary>
		/// <param name="word"></param>
		/// <param name="partOfSpeech"></param>
		/// <returns> true if word is the part of speech </returns>
		public bool IsPartOfSpeech(string word, PartOfSpeech partOfSpeech)
        {
			List<PartOfSpeech> partsOfSpeech = GetPartsOfSpeech(word);

			if(partsOfSpeech.Contains(partOfSpeech))
            {
				return true;
            }
			else
            {
				return false;
            }
        }
	}
}
