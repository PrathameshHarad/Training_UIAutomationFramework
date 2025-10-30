using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationApplicationLayer.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

    }
}
