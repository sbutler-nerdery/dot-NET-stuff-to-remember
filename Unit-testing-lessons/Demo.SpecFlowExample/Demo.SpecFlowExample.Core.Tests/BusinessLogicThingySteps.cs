using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Demo.SpecFlowExample.Core.Tests
{
    [Binding]
    public class BusinessLogicThingySteps
    {
        [Given]
        public void Given_I_have_the_string_P0(string p0)
        {
            ScenarioContext.Current.Add("input", p0);
        }
        
        [When]
        public void When_I_enforce_uppercase_rules()
        {
            var logic = new BusinessLogicThingy();
            var output = logic.EnforceUppercaseRules(ScenarioContext.Current["input"].ToString());
            ScenarioContext.Current.Add("output", output);
        }
        
        [Then]
        public void Then_the_result_should_be_P0_on_the_screen(string p0)
        {
            Assert.AreEqual(p0, ScenarioContext.Current["output"]);
        }
    }
}
