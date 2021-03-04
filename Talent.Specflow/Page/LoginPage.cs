using OpenQA.Selenium;
using QA.Framework.Helper.Excel;
using System.Linq;
using QA.Framework.Extension;

namespace Talent.Specflow.Page
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;

        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        private IWebElement EmailTxt
        => Driver.WaitForElement(By.Id("email"));
        private IWebElement PasswordTxt
            => Driver.WaitForElement(By.Id("password"));
        private IWebElement LoginBtn
          => Driver.WaitForElement(By.CssSelector("button[type='submit']"));
        private IWebElement RememberMeCheckbox
            => Driver.WaitForElement(By.XPath("//input[@type='checkbox']"));
        private IWebElement ForgotPasswordBtn
            => Driver.WaitForElement(By.XPath("//a[@href]/span[text()='Forgot your password?']"));
        private IWebElement LoginAsTalentTab
            => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Demo as Talent')]"));
        private IWebElement LoginAsEmployerTab
            => Driver.WaitForElement(By.XPath("//div[@role = 'tab' and text() = 'Login as Employer']"));

        public void LoginWebsite(string role)
        {
            var value = ExcelHelper.ReadDataByKey(role, "username");
            var dataList = ExcelHelper.GetDataSet(role);

            EmailTxt.SendKeys(dataList.DataSet.Where(x => x.ColumnName == "username").FirstOrDefault().ColumnValue);
            PasswordTxt.SendKeys(dataList.DataSet.Where(x => x.ColumnName == "password").FirstOrDefault().ColumnValue);
            LoginBtn.Click();
        }
    }
}
