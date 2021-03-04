using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA.Framework.Base
{

    public class WebDriverContext
    {
        private readonly IObjectContainer _objectContainer;
        public IWebDriver Driver { get; set; }

        public WebDriverContext(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            Driver = new ChromeDriver();

            _objectContainer.RegisterInstanceAs(Driver);
        }

    }
}
