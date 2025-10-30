using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Configuration;
using UIAutomationApplicationLayer.Drivers;

namespace Training_UIAutomationFramework.Hooks
{


    [Binding]
    public sealed class Hooks
    {
        private IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            var factory = new DriverFactory();
            driver = factory.InitDriver();
            scenarioContext["WebDriver"] = driver;
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Url"]);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}