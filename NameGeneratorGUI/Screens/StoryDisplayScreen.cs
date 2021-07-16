using Gtk;
using System;
using System.Collections.Generic;
using System.Text;
using UI = Gtk.Builder.ObjectAttribute;

namespace NameGeneratorGUI
{
    class StoryDisplayScreen : Screen
    {
        // UI elements
        [UI] private Table mainTable = new Table(10, 10, false);
        [UI] private Label label1 = new Label("Hello world label");

        // Private members
        private RandomWordStory randomWordStory;

        public StoryDisplayScreen(RandomWordStory randomWordStory) : base()
        {
            // Set default values
            this.randomWordStory = randomWordStory;
            ReplaceWordsInText();

            // Init widgets and attach in heirarchy
            label1.Text = randomWordStory.text;
            mainTable.Attach(label1, 0, 9, 0, 9);
            Add(mainTable);
        }

        // Replaces the random word fields with the selected words
        private void ReplaceWordsInText()
        {
            if(randomWordStory.randomWords.Count != randomWordStory.randomWordsPartOfSpeech.Count)
            {
                throw new FormatException();
            }

            string newText = "";
            int startIndex = -1;
            int stopIndex = -1;
            int wordIndex = 0;

            for(int i = 0; i < randomWordStory.text.Length; i++)
            {
                if(randomWordStory.text[i] == '<')
                {
                    startIndex = i;
                }
                else if(randomWordStory.text[i] == '>')
                {
                    stopIndex = i;
                }

                if (startIndex == -1 && stopIndex == -1)
                {
                    newText += randomWordStory.text[i];
                }
                else if (startIndex != -1 && stopIndex == -1)
                {
                    continue;
                }
                else
                {
                    newText += randomWordStory.randomWords[wordIndex];
                    wordIndex++;
                    startIndex = -1;
                    stopIndex = -1;
                }
            }

            randomWordStory.text = newText;
        }
    }
}
