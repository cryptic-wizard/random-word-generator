using NameGeneratorLibrary;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;

namespace NameGeneratorTest.Steps
{
    [Binding]
    public sealed class NameGeneratorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private NameGenerator nameGenerator;
        private List<string> names;
        private string name;


        public NameGeneratorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            nameGenerator = new NameGenerator();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            names = null;
            name = null;
        }

        [When("I get a name")]
        public void WhenIGetAName()
        {
            NameGenerator.WordType[] format = { NameGenerator.WordType.noun };
            name = nameGenerator.GetName(format);
        }

        [When("I get (\\d+) names")]
        public void WhenIGetXNames(int quantity)
        {
            NameGenerator.WordType[] format = { NameGenerator.WordType.noun };
            names = nameGenerator.GetNames(format, quantity);
        }

        [Then("I have a name")]
        public void ThenIHaveAName()
        {
            Assert.IsNotNull(name, "name was null");
        }

        [Then("I have (\\d+) names")]
        public void ThenIHaveXNames(int quantity)
        {
            Assert.IsNotNull(names, "names was null");
            Assert.AreEqual(quantity, names.Count);
        }
    }
}
