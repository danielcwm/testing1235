using OpenQA.Selenium;
using Talent.Specflow.Page;
using TechTalk.SpecFlow;

namespace Talent.Specflow.Step
{
    [Binding]
    public class LoginStep
    {
        private readonly IWebDriver Driver;

        public LoginStep(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        [Given(@"I login as recruiter")]
        public void GivenILoginAsRecruiter()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.LoginWebsite("recruiter");
        }

    }
}
