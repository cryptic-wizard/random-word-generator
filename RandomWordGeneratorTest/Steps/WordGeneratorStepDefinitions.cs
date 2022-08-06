using NUnit.Framework;
using CrypticWizard.RandomWordGenerator;
using static CrypticWizard.RandomWordGenerator.WordGenerator;
using TechTalk.SpecFlow;

namespace CrypticWizard.RandomWordGeneratorTest.Steps
{
    [Binding]
    public sealed class WordGeneratorStepDefinitions
    {
        private readonly WordGenerator wordGenerator;
        private readonly WordGeneratorFixture wordGeneratorFixture;

        public WordGeneratorStepDefinitions(WordGenerator wordGenerator, WordGeneratorFixture wordGeneratorFixture)
        {
            this.wordGenerator = wordGenerator;
            this.wordGeneratorFixture = wordGeneratorFixture;
        }

        #region ScenarioSteps

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //wordGenerator = new WordGenerator();
            //wordGeneratorFixture = new WordGeneratorFixture();
        }

        [AfterScenario]
        public static void AfterScenario()
        {

        }

        #endregion

        #region GivenSteps

        [Given(@"I set the language to (.*)")]
        public void GivenISetTheLanguageToX(Languages language)
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

        [When("I get a '(.*)'")]
        public void WhenIGetAWord(PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.word = wordGenerator.GetWord(partOfSpeech);
        }

        [When("I get (\\d+) words")]
        public void WhenIGetXWords(int quantity)
        {
            wordGeneratorFixture.words = wordGenerator.GetWords(quantity);
        }

        [When("I get (\\d+) '(.*)'")]
        public void WhenIGetXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.words = wordGenerator.GetWords(partOfSpeech, quantity);
        }

        [When(@"I get the list of (.*)")]
        public void WhenIGetTheListOfWords(PartOfSpeech partOfSpeech)
        {
            wordGeneratorFixture.words = wordGenerator.GetAllWords(partOfSpeech);
        }

        #endregion

        #region ThenSteps

        [Then("I have a (.*)")]
        public void ThenIHaveAWord(PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(wordGeneratorFixture.word);
            Assert.True(wordGenerator.IsPartOfSpeech(wordGeneratorFixture.word, partOfSpeech), "Word = " + wordGeneratorFixture.word.ToString());
        }

        [Then("I have (\\d+) '(.*)'")]
        public void ThenIHaveXWords(int quantity, PartOfSpeech partOfSpeech)
        {
            Assert.IsNotNull(wordGeneratorFixture.words);
            Assert.AreEqual(quantity, wordGeneratorFixture.words.Count);

            foreach(string word in wordGeneratorFixture.words)
            {
                Assert.True(wordGenerator.IsPartOfSpeech(word, partOfSpeech), "Word = " + word.ToString());
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

        [Then(@"I have a word")]
        public void ThenIHaveAWord()
        {
            Assert.IsNotNull(wordGeneratorFixture.word);
        }

        [Then(@"I do not have a word")]
        public void ThenIDoNotHaveAWord()
        {
            Assert.IsNull(wordGeneratorFixture.word);
        }

        [Then(@"I have words")]
        public void ThenIHaveWords()
        {
            Assert.IsNotNull(wordGeneratorFixture.words);
        }

        [Then(@"I do not have words")]
        public void ThenIDoNotHaveWords()
        {
            Assert.IsNull(wordGeneratorFixture.words);
        }

        #endregion
    }
}
