using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Collections.Generic;

namespace NameGeneratorGUI
{
    class MainWindow : Window
    {
        [UI] private static Screen activeScreen;

        public MainWindow() : base("Random Word Story GUI")
        {
            // Subscribe to events
            DeleteEvent += MainWindow_OnDelete;
            KeyPressEvent += MainWindow_OnKeyPress;

            // Init initial screen
            StorySelectionScreen storySelectionScreen = new StorySelectionScreen();
            storySelectionScreen.StorySelected += StorySelectionScreen_OnStorySelected;
            activeScreen = storySelectionScreen;

            // Attach and display
            Add(activeScreen);
            Resize(400, 400);
        }

        #region WindowEvents

        private static void MainWindow_OnDelete(object sender, DeleteEventArgs args)
        {
            //appShutdown.Cancel();
            Application.Quit();
        }

        private static void MainWindow_OnKeyPress(object sender, KeyPressEventArgs args)
        {
            Gdk.Key k = args.Event.Key;
            Console.WriteLine(k);
        }

        #endregion

        #region ScreenEvents

        private void StorySelectionScreen_OnStorySelected(string storyName)
        {
            WordSelectionScreen wordSelectionScreen = new WordSelectionScreen(storyName);
            wordSelectionScreen.WordsSelected += WordSelectionScreen_OnWordsSelected;
            UpdateScreen(wordSelectionScreen);
        }

        private void WordSelectionScreen_OnWordsSelected(RandomWordStory randomWordStory)
        {
            StoryDisplayScreen storyDisplayScreen = new StoryDisplayScreen(randomWordStory);
            UpdateScreen(storyDisplayScreen);
        }

        #endregion

        private void UpdateScreen(Screen newScreen)
        {
            Remove(activeScreen);
            activeScreen = newScreen;
            Add(activeScreen);
            ShowAll();
        }
    }
}
