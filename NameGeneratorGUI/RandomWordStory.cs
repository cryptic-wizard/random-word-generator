using Gtk;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NameGeneratorLibrary;
using System.IO;

namespace NameGeneratorGUI
{
    class RandomWordStory
    {
        // Public Members
        public List<WordGenerator.PartOfSpeech> randomWordsPartOfSpeech;
        public List<string> randomWords;
        public string text;
        public string name { get; private set; }

        // Private Members


        public RandomWordStory(List<WordGenerator.PartOfSpeech> randomWordsPartOfSpeech, string text)
        {
            this.randomWordsPartOfSpeech = randomWordsPartOfSpeech;
            this.text = text;
        }

        /// <summary>
        /// Gets a list of story names in the stories folder
        /// </summary>
        /// <returns> story names </returns>
        public static List<string> GetStoryNames()
        {
            List<string> storyNames = new List<string>();
            string[] storyFileNames = Directory.GetFiles("../../../Stories", "*.txt");

            foreach(string storyFileName in storyFileNames)
            {
                string storyName = storyFileName.Split('\\').Last();
                storyName = storyName.Substring(0, (storyName.Length - 4));
                storyNames.Add(storyName);
            }

            return storyNames;
        }

        /// <summary>
        /// Gets a story object 
        /// </summary>
        /// <param name="storyName"> - file name of the story </param>
        /// <returns> a story object </returns>
        public static RandomWordStory ParseRandomWordStory(string storyName)
        {
            RandomWordStory story = null;
            WordGenerator.PartOfSpeech partOfSpeech;
            string randomWordText;
            string storyText;

            string[] storyFileNames = Directory.GetFiles("../../../Stories", "*.txt");

            foreach (string storyFileName in storyFileNames)
            {
                string storyFile = storyFileName.Split('\\').Last();
                storyFile = storyFile.Substring(0, (storyFile.Length - 4));

                if (storyFile != storyName)
                {
                    continue;
                }

                storyText = File.ReadAllText(storyFileName);
                List<WordGenerator.PartOfSpeech> partsOfSpeech = new List<WordGenerator.PartOfSpeech>();
                List<int> startIndex = new List<int>();
                List<int> stopIndex = new List<int>();

                // Get Index of start and stop characters '<', '>'
                for (int i = 0; i < storyText.Length; i++)
                {
                    if (storyText[i] == '<')
                    {
                        startIndex.Add(i + 1);
                    }
                    else if (storyText[i] == '>')
                    {
                        stopIndex.Add(i);
                    }
                }

                if (startIndex.Count != stopIndex.Count)
                {
                    throw new FormatException();
                }

                // Parse parts of speech into random word story
                for (int i = 0; i < startIndex.Count; i++)
                {
                    randomWordText = storyText.Substring(startIndex[i], (stopIndex[i] - startIndex[i]));
                    partOfSpeech = (WordGenerator.PartOfSpeech)Enum.Parse(typeof(WordGenerator.PartOfSpeech), randomWordText);
                    partsOfSpeech.Add(partOfSpeech);
                }

                story = new RandomWordStory(partsOfSpeech, storyText);
            }

            return story;
        }

        /// <summary>
        /// Gets a list of story objects in the stories folder
        /// </summary>
        /// <returns> a list of stories </returns>
        public static List<RandomWordStory> ParseRandomWordStories()
        {
            List<RandomWordStory> toReturn = new List<RandomWordStory>();
            RandomWordStory randomWordStory;
            WordGenerator.PartOfSpeech partOfSpeech;
            string randomWordText;
            string story;
            string[] stories = Directory.GetFiles("../../../Stories", "*.txt");

            foreach (string fileName in stories)
            {
                story = File.ReadAllText(fileName);
                List<WordGenerator.PartOfSpeech> partsOfSpeech = new List<WordGenerator.PartOfSpeech>();
                List<int> startIndex = new List<int>();
                List<int> stopIndex = new List<int>();

                // Get Index of start and stop characters '<', '>'
                for (int i = 0; i < story.Length; i++)
                {
                    if(story[i] == '<')
                    {
                        startIndex.Add(i + 1);
                    }
                    else if (story[i] == '>')
                    {
                        stopIndex.Add(i);
                    }
                }

                if(startIndex.Count != stopIndex.Count)
                {
                    throw new FormatException();
                }

                // Parse parts of speech into random word story
                for(int i = 0; i < startIndex.Count; i++)
                {
                    randomWordText = story.Substring(startIndex[i], (stopIndex[i] - startIndex[i]));
                    partOfSpeech = (WordGenerator.PartOfSpeech)Enum.Parse(typeof(WordGenerator.PartOfSpeech), randomWordText);
                    partsOfSpeech.Add(partOfSpeech);
                }

                randomWordStory = new RandomWordStory(partsOfSpeech, story);
                toReturn.Add(randomWordStory);
            }

            return toReturn;
        }
    }
}
