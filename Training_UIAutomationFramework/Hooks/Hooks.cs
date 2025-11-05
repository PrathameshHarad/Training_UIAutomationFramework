using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Configuration;
using UIAutomation.SeleniumCore.Utils;
using UIAutomationApplicationLayer.Drivers;

namespace Training_UIAutomationFramework.Hooks
{


    [Binding]
    public sealed class Hooks
    {
        private IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        private static ExtentTest extentTest;

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
            extentTest = ExtentManager.CreateTest(scenarioContext.ScenarioInfo.Title);
            scenarioContext["extentTest"] = extentTest;
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Url"]);
        }

        [AfterStep]
        public void AfterEachStep()
        {
            var test = (ExtentTest)scenarioContext["extentTest"];

            if (scenarioContext.TestError != null)
            {
                test.Fail(scenarioContext.StepContext.StepInfo.Text);
                test.Fail(scenarioContext.TestError.Message);

                // Take screenshot if failure
                var driver = (IWebDriver)scenarioContext["WebDriver"];
                string screenshotPath = ScreenshotUtil.TakeScreenshot(driver, "FailedStep");
                test.AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                test.Pass(scenarioContext.StepContext.StepInfo.Text);
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {       
            if (driver != null)
            {
                driver.Quit();
            }
            ExtentManager.FlushReport();
        }
    }
}