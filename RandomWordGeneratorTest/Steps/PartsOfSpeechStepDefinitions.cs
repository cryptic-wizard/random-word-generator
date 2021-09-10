using NUnit.Framework;
using RandomWordGenerator;
using static RandomWordGenerator.WordGenerator;
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
        public void WhenICheckIfXIsY(string word, PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.myBool = wordGenerator.IsPartOfSpeech(word, partOfSpeech);
        }

        [When(@"I check if (.*) is a word")]
        public void WhenICheckIfXIsAWord(string word)
        {
            wordGeneratorFixture.myBool = wordGenerator.IsWord(word);
        }

        [When(@"I check if I have a word")]
        public void WhenICheckIfIHaveAWord()
        {
            wordGeneratorFixture.myBool = wordGenerator.IsWord(wordGeneratorFixture.word);
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
