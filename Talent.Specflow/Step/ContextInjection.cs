using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Talent.Specflow.Step
{
    [Binding]
    public class ContextInjection
    {
        private int firstNum;
        private int secondNum;
        private int sum;
        private readonly ScenarioContext _scenarioContext;

        public ContextInjection(ScenarioContext scenariocontext)
        {
            _scenarioContext = scenariocontext;
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int first)
        {
            firstNum = first;

            // set
            _scenarioContext["firstNum"] = first;
            _scenarioContext.Add("FirstNumber", first);

            // get
            var value = (int)_scenarioContext["firstNum"];
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int second)
        {
            secondNum = second;
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            sum = firstNum + secondNum;
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int total)
        {
            if (!sum.Equals(total)) throw new Exception();
        }

    }
}
