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
    public sealed class PatternsStepDefinitions
    {
        private WordGenerator wordGenerator;
        private WordGeneratorFixture wordGeneratorFixture;

        public PatternsStepDefinitions(WordGenerator wordGenerator, WordGeneratorFixture wordGeneratorFixture)
        {
            this.wordGenerator = wordGenerator;
            this.wordGeneratorFixture = wordGeneratorFixture;
        }

        #region GivenSteps

        [Given(@"I set the delimiter to (.*)")]
        public void GivenISetThePartOfSpeechToX(char delimiter)
        {
            wordGeneratorFixture.delimiter = delimiter;
        }

        [Given(@"I set the pattern to (.*),(.*),(.*)")]
        public void GivenISetThePatternToPattern(PartOfSpeech partOfSpeech0, PartOfSpeech partOfSpeech1, PartOfSpeech partOfSpeech2)
        {
            wordGeneratorFixture.pattern = new List<PartOfSpeech>();
            wordGeneratorFixture.pattern.Add(partOfSpeech0);
            wordGeneratorFixture.pattern.Add(partOfSpeech1);
            wordGeneratorFixture.pattern.Add(partOfSpeech2);
        }

        #endregion

        #region WhenSteps

        [When(@"I get a pattern")]
        public void WhenIGetAPattern()
        {
            wordGeneratorFixture.word = wordGenerator.GetPattern(wordGeneratorFixture.pattern, wordGeneratorFixture.delimiter);
        }

        [When("I get (\\d+) patterns")]
        public void WhenIGetXPatterns(int quantity)
        {
            wordGeneratorFixture.words = wordGenerator.GetPatterns(wordGeneratorFixture.pattern, quantity, wordGeneratorFixture.delimiter);
        }

        #endregion

        #region ThenSteps

        [Then("I have one pattern with (\\d+) words and (.*) delimiter")]
        public void ThenIHaveOnePatternWithXWords(int wordsInPattern, char delimiter)
        {
            Assert.IsNotNull(wordGeneratorFixture.word);
            string[] split = wordGeneratorFixture.word.Split(delimiter);
            Assert.AreEqual(wordsInPattern, split.Length);
        }

        [Then("I have (\\d+) patterns with (\\d+) words and (.*) delimiter")]
        public void ThenIHaveXPatternsWithYWords(int quantity, int wordsInPattern, char delimiter)
        {
            Assert.IsNotNull(wordGeneratorFixture.words);
            Assert.AreEqual(quantity, wordGeneratorFixture.words.Count);

            string[] split;

            foreach (string word in wordGeneratorFixture.words)
            {
                split = word.Split(delimiter);
                Assert.AreEqual(wordsInPattern, split.Length);
            }
        }

        #endregion
    }
}
