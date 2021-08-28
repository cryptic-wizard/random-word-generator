using NUnit.Framework;
using RandomWordGenerator;
using static RandomWordGenerator.WordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RandomWordGeneratorTest.Steps
{
    [Binding]
    public sealed class WordGeneratorStepDefinitions
    {
        private WordGenerator wordGenerator;
        private WordGeneratorFixture wordGeneratorFixture;

        public WordGeneratorStepDefinitions(WordGenerator wordGenerator, WordGeneratorFixture wordGeneratorFixture)
        {
            this.wordGenerator = wordGenerator;
            this.wordGeneratorFixture = wordGeneratorFixture;
        }

        #region ScenarioSteps

        [BeforeScenario]
        public void BeforeScenario()
        {
            //wordGenerator = new WordGenerator();
            //wordGeneratorFixture = new WordGeneratorFixture();
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }

        #endregion

        #region GivenSteps

        [Given(@"I set the part of speech to (.*)")]
        public void GivenISetThePartOfSpeechToX(PartOfSpeech partOfSpeech)
        {
            wordGenerator.partOfSpeech = partOfSpeech;
        }

        [Given(@"I set the language to (.*)")]
        public void GivenISetTheLanguageToX(Language language)
        {
            wordGenerator.SetLanguage(language);
        }

        #endregion

        #region WhenSteps

        [When("I get a word")]
        public void WhenIGetAWord()
        {
            wordGeneratorFixture.word = wordGenerator.GetWord();
        }

        [When("I get a (.*)")]
        public void WhenIGetAWord(PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.word = wordGenerator.GetWord(partOfSpeech);
        }

        [When("I get (\\d+) words")]
        public void WhenIGetXWords(int quantity)
        {
            wordGeneratorFixture.words = wordGenerator.GetWords(quantity);
        }

        [When("I get (\\d+) (.*)")]
        public void WhenIGetXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.words = wordGenerator.GetWords(partOfSpeech, quantity);
        }

        [When(@"I get the list of (.*)")]
        public void WhenIGetTheListOfWords(PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.words = wordGenerator.GetWordList(partOfSpeech);
        }

        #endregion

        #region ThenSteps

        [Then("I have a (.*)")]
        public void ThenIHaveAWord(PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(wordGeneratorFixture.word);
            wordGeneratorFixture.partsOfSpeech = wordGenerator.GetPartsOfSpeech(wordGeneratorFixture.word);
            Assert.Contains(partOfSpeech, wordGeneratorFixture.partsOfSpeech);
        }

        [Then("I have (\\d+) (.*)")]
        public void ThenIHaveXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(wordGeneratorFixture.words);
            Assert.AreEqual(quantity, wordGeneratorFixture.words.Count);

            foreach(string word in wordGeneratorFixture.words)
            {
                Assert.Contains(partOfSpeech, wordGenerator.GetPartsOfSpeech(word), "Word = " + word.ToString());
            }
        }

        [Then(@"the list has no duplicates")]
        public void ThenTheListHasNoDuplicates()
        {
            Assert.IsNotNull(wordGeneratorFixture.words);
            int count;

            foreach (string word in wordGeneratorFixture.words)
            {
                count = 0;

                foreach (string s in wordGeneratorFixture.words)
                {
                    if (s == word)
                    {
                        count++;
                    }
                }

                Assert.AreEqual(1, count, "Word = " + word.ToString());
            }
        }

        [Then(@"I do not have a word")]
        public void ThenIDoNotHaveAWord()
        {
            Assert.IsNull(wordGeneratorFixture.word);
        }

        [Then(@"I do not have words")]
        public void ThenIDoNotHaveWords()
        {
            Assert.IsNull(wordGeneratorFixture.words);
        }

        #endregion
    }
}
