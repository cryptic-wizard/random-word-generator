using RandomWordGenerator;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using static RandomWordGenerator.WordGenerator;

namespace RandomWordGeneratorTest.Steps
{
    [Binding]
    public sealed class WordGeneratorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly ScenarioContext _scenarioContext;

        // Scenario Context Variables
        private WordGenerator wordGenerator;
        private List<string> words;
        private string word;
        private List<PartOfSpeech> partsOfSpeech;
        private bool myBool;

        public WordGeneratorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region ScenarioSteps

        [BeforeScenario]
        public void BeforeScenario()
        {
            wordGenerator = new WordGenerator();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            words = null;
            word = null;
            partsOfSpeech = null;
            wordGenerator.partOfSpeech = null;
        }

        #endregion

        #region GivenSteps

        [Given(@"I set the part of speech to (.*)")]
        public void GivenISetThePartOfSpeechToX(PartOfSpeech partOfSpeech)
        {
            wordGenerator.partOfSpeech = partOfSpeech;
        }

        #endregion

        #region WhenSteps

        [When("I get a word")]
        public void WhenIGetAWord()
        {
            word = wordGenerator.GetWord();
        }

        [When("I get a (.*)")]
        public void WhenIGetAWord(PartOfSpeech partOfSpeech)
        {
            word = wordGenerator.GetWord(partOfSpeech);
        }

        [When("I get (\\d+) words")]
        public void WhenIGetXWords(int quantity)
        {
            words = wordGenerator.GetWords(quantity);
        }

        [When("I get (\\d+) (.*)")]
        public void WhenIGetXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            words = wordGenerator.GetWords(partOfSpeech, quantity);
        }

        [When(@"I get the parts of speech of (.*)")]
        public void WhenIGetThePartsOfSpeechOfX(string word)
        {
            partsOfSpeech = wordGenerator.GetPartsOfSpeech(word);
        }

        [When(@"I get the list of (.*)")]
        public void WhenIGetTheListOfWords(PartOfSpeech partOfSpeech)
        {
            words = wordGenerator.GetWordList(partOfSpeech);
        }

        [When(@"I check if (.*) is (.*)")]
        public void WhenICheckIfTallIsAdj(string word, PartOfSpeech partOfSpeech)
        {
            myBool = wordGenerator.IsPartOfSpeech(word, partOfSpeech);
        }

        #endregion

        #region ThenSteps

        [Then("I have a (.*)")]
        public void ThenIHaveAWord(PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(word);
            partsOfSpeech = wordGenerator.GetPartsOfSpeech(word);
            Assert.Contains(partOfSpeech, partsOfSpeech);
        }

        [Then("I have (\\d+) (.*)")]
        public void ThenIHaveXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(words);
            Assert.AreEqual(quantity, words.Count);

            foreach(string word in words)
            {
                Assert.Contains(partOfSpeech, wordGenerator.GetPartsOfSpeech(word), "Word = " + word.ToString());
            }
        }

        [Then(@"the list has no duplicates")]
        public void ThenTheListHasNoDuplicates()
        {
            Assert.IsNotNull(words);
            int count;

            foreach (string word in words)
            {
                count = 0;

                foreach (string s in words)
                {
                    if (s == word)
                    {
                        count++;
                    }
                }

                Assert.AreEqual(1, count, "Word = " + word.ToString());
            }
        }

        [Then(@"the parts of speech contains (.*)")]
        public void ThenThePartsOfSpeechContainsX(PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(partsOfSpeech);
            Assert.Contains(partOfSpeech, partsOfSpeech);
        }

        [Then(@"I do not have a word")]
        public void ThenIDoNotHaveAWord()
        {
            Assert.IsNull(word);
        }

        [Then(@"I do not have words")]
        public void ThenIDoNotHaveWords()
        {
            Assert.IsNull(words);
        }

        [Then(@"the return value is (.*)")]
        public void ThenTheReturnValueIsTrue(bool value)
        {
            Assert.IsNotNull(myBool);
            Assert.AreEqual(value, myBool);
        }

        #endregion
    }
}
