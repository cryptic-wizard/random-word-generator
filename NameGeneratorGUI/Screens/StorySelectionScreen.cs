using Gtk;
using System;
using System.Collections.Generic;
using System.Text;
using UI = Gtk.Builder.ObjectAttribute;
using NameGeneratorLibrary;

namespace NameGeneratorGUI
{
    class StorySelectionScreen : Screen
    {
        // Public actions
        public Action<string> StorySelected;

        // UI elements
        [UI] private Table mainTable = new Table(10, 10, false);
        [UI] private ComboBox storiesComboBox;
        [UI] private Button continueButton = new Button("Continue");

        // Private members
        private List<string> storyNames;
        private string storyName;

        public StorySelectionScreen() : base()
        {
            // Subscribe to events
            continueButton.Clicked += ContinueButton_Clicked;

            // Set default values
            continueButton.Sensitive = false;

            // Init widgets
            storyNames = RandomWordStory.GetStoryNames();
            storiesComboBox = new ComboBox(storyNames);
            storiesComboBox.Changed += StoriesComboBox_Changed;

            // Attach widgets in heirarchy
            mainTable.Attach(storiesComboBox, 0, 9, 0, 1);
            mainTable.Attach(continueButton, 0, 9, 1, 2);
            Add(mainTable);
        }

        // Updates the continue button status and next screen parameters
        private void StoriesComboBox_Changed(object sender, EventArgs e)
        {
            if (storiesComboBox.Text == null)
            {
                continueButton.Sensitive = false;
                storyName = null;
                return;
            }
            else
            {
                continueButton.Sensitive = true;
                storyName = storiesComboBox.Text;
            }
        }

        // Tells the main window to continue to the word selection screen
        private void ContinueButton_Clicked(object sender, EventArgs e)
        {
            if(StorySelected != null && storyName != null)
            {
                StorySelected(storyName);
            }
        }
    }
}
