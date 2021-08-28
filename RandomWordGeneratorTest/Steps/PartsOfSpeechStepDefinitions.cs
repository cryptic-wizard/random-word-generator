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
    public sealed class PartsOfSpeechStepDefinitions
    {
        private WordGenerator wordGenerator;
        private WordGeneratorFixture wordGeneratorFixture;

        public PartsOfSpeechStepDefinitions(WordGenerator wordGenerator, WordGeneratorFixture wordGeneratorFixture)
        {
            this.wordGenerator = wordGenerator;
            this.wordGeneratorFixture = wordGeneratorFixture;
        }

        #region GivenSteps

        #endregion

        #region WhenSteps

        [When(@"I get the parts of speech of (.*)")]
        public void WhenIGetThePartsOfSpeechOfX(string word)
        {
            wordGeneratorFixture.partsOfSpeech = wordGenerator.GetPartsOfSpeech(word);
        }

        [When(@"I check if (.*) is (.*)")]
        public void WhenICheckIfTallIsAdj(string word, PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.myBool = wordGenerator.IsPartOfSpeech(word, partOfSpeech);
        }

        #endregion

        #region ThenSteps

        [Then(@"the parts of speech contains (.*)")]
        public void ThenThePartsOfSpeechContainsX(PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(wordGeneratorFixture.partsOfSpeech);
            Assert.Contains(partOfSpeech, wordGeneratorFixture.partsOfSpeech);
        }

        [Then(@"the return value is (.*)")]
        public void ThenTheReturnValueIsTrue(bool value)
        {
            Assert.IsNotNull(wordGeneratorFixture.myBool);
            Assert.AreEqual(value, wordGeneratorFixture.myBool);
        }

        #endregion
    }
}
