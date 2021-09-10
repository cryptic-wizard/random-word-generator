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
		public Language language { get; private set; }

		// Private Members
		private static Random rnd = new Random();
		private List<PartOfSpeech> partsOfSpeech;
		private Dictionary<PartOfSpeech, List<string>> wordDictionary;

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
		public WordGenerator(Language language = Language.EN)
        {
			this.language = language;
			partsOfSpeech = Enum.GetValues(typeof(PartOfSpeech)).Cast<PartOfSpeech>().ToList();
			wordDictionary = new Dictionary<PartOfSpeech, List<string>>();

			foreach (PartOfSpeech partOfSpeech in partsOfSpeech)
			{
				wordDictionary.Add(partOfSpeech, LoadWords(partOfSpeech));
			}
        }

		/// <summary>
		/// Set Language and reload dictionaries if preload is set
		/// </summary>
		/// <param name="language"></param>
		public void SetLanguage(Language language)
        {
			this.language = language;
			wordDictionary.Clear();

			foreach (PartOfSpeech partOfSpeech in partsOfSpeech)
			{
				wordDictionary.Add(partOfSpeech, LoadWords(partOfSpeech));
			}
		}

		/// <summary>
		/// Gets a list of possible parts of speech of a word
		/// </summary>
		/// <param name="word"> </param>
		/// <returns> a list of parts of speech or null if word not found </returns>
		public List<PartOfSpeech> GetPartsOfSpeech(string word)
        {
			List<PartOfSpeech> partsOfSpeechFound = new List<PartOfSpeech>();

			foreach(PartOfSpeech partOfSpeech in wordDictionary.Keys)
            {
				if(wordDictionary[partOfSpeech].BinarySearch(word) >= 0)
                {
					partsOfSpeechFound.Add(partOfSpeech);
                }
            }

			if(partsOfSpeechFound.Count != 0)
            {
				return partsOfSpeechFound;
            }
			else
            {
				return null;
			}
        }

		/// <summary>
		/// Gets a word with any part of speech
		/// </summary>
		/// <returns> a word </returns>
		public string GetWord()
        {
			int totalWords = 0;

			foreach(PartOfSpeech partOfSpeech in wordDictionary.Keys)
            {
				totalWords += wordDictionary[partOfSpeech].Count;
            }

			int randomNumber = rnd.Next(totalWords);

			foreach (PartOfSpeech partOfSpeech in wordDictionary.Keys)
			{
				if(randomNumber > wordDictionary[partOfSpeech].Count)
                {
					randomNumber -= wordDictionary[partOfSpeech].Count;
				}
				else
                {
					return wordDictionary[partOfSpeech].ElementAt(randomNumber);
                }
			}

			return null;
		}

		/// <summary>
		/// Gets a word with a specified part of speech
		/// </summary>
		/// <param name="partOfSpeech"></param>
		/// <returns> a word </returns>
		public string GetWord(PartOfSpeech partOfSpeech)
        {
			return wordDictionary[partOfSpeech][rnd.Next(wordDictionary[partOfSpeech].Count)];
		}

		/// <summary>
		/// Gets a list of words with any part of speech
		/// </summary>
		/// <param name="quantity"> number of words to return </param>
		/// <returns> words </returns>
		public List<string> GetWords(int quantity)
		{
			List<string> words = new List<string>();
			List<string> wordList = new List<string>();
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
			// Prevent returning more words than exist in the list
			if (quantity >= wordDictionary[partOfSpeech].Count)
			{
				return wordDictionary[partOfSpeech];
			}
			else if(quantity > wordDictionary[partOfSpeech].Count/2)
            {
				List<string> words = wordDictionary[partOfSpeech];

				for (int i = wordDictionary[partOfSpeech].Count; i > quantity; i--)
                {
					words.RemoveAt(rnd.Next(words.Count));
                }

				return words;
            }
			else
            {
				List<string> wordList = wordDictionary[partOfSpeech];
				List<string> words = new List<string>();
				int randomNumber;

				for (int i = 0; i < quantity; i++)
				{
					randomNumber = rnd.Next(wordList.Count);
					words.Add(wordList[randomNumber]);
					wordList.RemoveAt(randomNumber);
				}

				return words;
			}
		}

		public string GetPattern(List<PartOfSpeech> partsOfSpeech, char delimiter)
        {
			string pattern = "";

			for(int i = 0; i < partsOfSpeech.Count; i++)
            {
				pattern += GetWord(partsOfSpeech[i]);

				if(i != (partsOfSpeech.Count - 1))
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

					if (j != (partsOfSpeech.Count - 1))
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
		public List<string> LoadWords(PartOfSpeech partOfSpeech)
        {
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
			if(wordDictionary[partOfSpeech].BinarySearch(word) < 0)
            {
				return false;
            }
			else
            {
				return true;
            }
        }

		/// <summary>
		/// Check if a word is in the dictionary
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public bool IsWord(string word)
        {
			foreach(PartOfSpeech partOfSpeech in wordDictionary.Keys)
			{
				if (wordDictionary[partOfSpeech].BinarySearch(word) >= 0)
				{
					return true;
				}
			}

			return false;
        }
	}
}
