using CrypticWizard.RandomWordGenerator;
using TechTalk.SpecFlow;
using BoDi;

namespace CrypticWizard.RandomWordGeneratorTest.Steps
{
    [Binding]
    public class WordGeneratorFixtureStepDefinitions
    {
        private readonly IObjectContainer objectContainer;

        public WordGeneratorFixtureStepDefinitions(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        #region ScenarioSteps

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Create global instances of WordGenerator and WordGeneratorFixture for the Scenario
            objectContainer.RegisterInstanceAs(new WordGenerator());
            objectContainer.RegisterInstanceAs(new WordGeneratorFixture());
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }

        #endregion
    }
}
