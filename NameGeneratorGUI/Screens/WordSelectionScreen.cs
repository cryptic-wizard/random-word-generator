using Gtk;
using System;
using System.Collections.Generic;
using System.Text;
using UI = Gtk.Builder.ObjectAttribute;
using NameGeneratorLibrary;

namespace NameGeneratorGUI
{
    class WordSelectionScreen : Screen
    {
        // Public actions
        public Action<RandomWordStory> WordsSelected;

        // UI elements
        [UI] private Table mainTable = new Table(10, 10, false);
        [UI] private Button continueButton = new Button("Continue");
        [UI] private List<ComboBox> wordSelectionBoxes = new List<ComboBox>();

        // Private members
        private WordGenerator wordGenerator = new WordGenerator();
        private RandomWordStory story;
        private bool selectionsMade = false;

        public WordSelectionScreen(string storyName) : base()
        {
            // Subscribe to events
            continueButton.Clicked += ContinueButton_Clicked;

            // Set default values
            continueButton.Sensitive = false;

            // Random word story variables
            story = RandomWordStory.ParseRandomWordStory(storyName);
            mainTable = new Table(2, (uint)story.randomWordsPartOfSpeech.Count, false);
            List<string> randomWords = new List<string>();
            ComboBox randomWordBox;
            uint index = 0;

            // Init word selection widgets and attach in heirarchy
            foreach (WordGenerator.PartOfSpeech partOfSpeech in story.randomWordsPartOfSpeech)
            {
                List<string> words = wordGenerator.GetWords(partOfSpeech, 8);
                words.Insert(0, '<' + partOfSpeech.ToString() + '>');
                randomWordBox = new ComboBox(words);
                randomWordBox.Changed += RandomWordBox_Changed;
                wordSelectionBoxes.Add(randomWordBox);
                mainTable.Attach(randomWordBox, index, (index + 1), 0, 1);
                index++;
            }

            mainTable.Attach(continueButton, 0, 9, 1, 2);
            Add(mainTable);
        }

        // Updates the continue button status and next screen parameters
        private void RandomWordBox_Changed(object sender, EventArgs e)
        {
            foreach (ComboBox randomWordBox in wordSelectionBoxes)
            {
                if (randomWordBox.Text == null || randomWordBox.Text.Contains('<') || randomWordBox.Text.Contains('>'))
                {
                    continueButton.Sensitive = false;
                    selectionsMade = false;
                    return;
                }
            }

            continueButton.Sensitive = true;
            selectionsMade = true;
        }

        // Tells the main window to continue to the story display screen
        private void ContinueButton_Clicked(object sender, EventArgs a)
        {
            if(selectionsMade && WordsSelected != null)
            {
                List<string> selections = new List<string>();

                foreach(ComboBox randomWordBox in wordSelectionBoxes)
                {
                    selections.Add(randomWordBox.Text);
                }

                story.randomWords = selections;
                WordsSelected(story);
            }
        }
    }
}
