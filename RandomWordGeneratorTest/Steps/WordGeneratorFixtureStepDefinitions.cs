using NUnit.Framework;
using RandomWordGenerator;
using static RandomWordGenerator.WordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using BoDi;

namespace RandomWordGeneratorTest.Steps
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
