using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace QA.Framework.Extension
{
   public static class WebDriverExtension
    {
        /// <summary>
        ///  commiting.....
        /// </summary>
        /// <param name="driver">dirver</param>
        /// <param name="ele"></param>
        /// <param name="timeOutinSeconds"></param>       
        /// <returns></returns>
        public static IWebElement WaitForElement(this IWebDriver driver, By ele, int timeOutinSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(x => x.FindElement(ele));
            }
            catch (Exception e)
            {
                // pass error to report
                throw;
            }
        }
    }
}
