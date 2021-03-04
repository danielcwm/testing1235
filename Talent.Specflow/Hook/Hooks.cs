using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using QA.Framework.Base;
using TechTalk.SpecFlow;
using SpecflowFeature = AventStack.ExtentReports.Gherkin.Model;

namespace Talent.Specflow.Hook
{
    [Binding]
    public sealed class Hooks
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer objectContainer)
        {
            // init framework 
            var init = new FrameworkHook();
            init.InitialSetup(objectContainer);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = ExtendReportContext.ExtendReport.CreateTest<SpecflowFeature.Feature>(featureContext.FeatureInfo.Title); //name of feature file
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("http://localhost:5034/");
            _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title); //name of scenario
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            switch (stepType)
            {
                case "Given":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);

                    }
                    else
                    {
                        _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                case "When":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                case "Then":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                case "And":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;

                default:
                    break;
            }

        }

        [AfterTestRun]
        public static void AfterTestRun(IWebDriver driver)
        {
            driver.Close();
            ExtendReportContext.ExtendReport.Flush();
        }
    }
}
