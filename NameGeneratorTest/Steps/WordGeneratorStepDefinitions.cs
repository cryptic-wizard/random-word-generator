using NameGeneratorLibrary;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace NameGeneratorTest.Steps
{
    [Binding]
    public sealed class WordGeneratorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private WordGenerator wordGenerator;
        private List<string> words;
        private string word;
        private WordGenerator.PartOfSpeech? partOfSpeech;


        public WordGeneratorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

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
            partOfSpeech = null;
        }

        #region WhenSteps

        [When("I get a (.*)")]
        public void WhenIGetAWord(WordGenerator.PartOfSpeech partOfSpeech)
        {
            word = wordGenerator.GetWord(partOfSpeech);
        }

        [When("I get (\\d+) (.*)")]
        public void WhenIGetXWords(int quantity, WordGenerator.PartOfSpeech partOfSpeech)
        {
            words = wordGenerator.GetWords(partOfSpeech, quantity);
        }

        [When(@"I get the part of speech of (.*)")]
        public void WhenIGetThePartOfSpeechOfX(string word)
        {
            partOfSpeech = wordGenerator.GetPartOfSpeech(word);
        }

        #endregion

        #region ThenSteps

        [Then("I have a (.*)")]
        public void ThenIHaveAWord(WordGenerator.PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(word);
            this.partOfSpeech = wordGenerator.GetPartOfSpeech(word);
            Assert.AreEqual(partOfSpeech, this.partOfSpeech);
        }

        [Then("I have (\\d+) (.*)")]
        public void ThenIHaveXWords(int quantity, WordGenerator.PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(words);
            Assert.AreEqual(quantity, words.Count);

            foreach(string word in words)
            {
                Assert.AreEqual(partOfSpeech, wordGenerator.GetPartOfSpeech(word));
            }
        }

        [Then(@"the part of speech is (.*)")]
        public void ThenThePartOfSpeechIsX(WordGenerator.PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(this.partOfSpeech);
            Assert.AreEqual(partOfSpeech, this.partOfSpeech);
        }

        #endregion
    }
}
