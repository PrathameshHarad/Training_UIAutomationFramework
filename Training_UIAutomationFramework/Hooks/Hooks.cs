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
        private readonly ScenarioContext scenarioContext; //limited to single scenario
        private readonly FeatureContext featureContext; //shared with all scenario
        private static ExtentTest extentTest;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var factory = new DriverFactory();
            driver = factory.InitDriver();
            scenarioContext["WebDriver"] = driver;
            //featureContext["Browser"] = ConfigurationManager.AppSettings["Browser"];
            extentTest = ExtentManager.CreateTest(scenarioContext.ScenarioInfo.Title);
            scenarioContext["extentTest"] = extentTest;
            driver.Manage().Window.Maximize();
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


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Runs once before the whole test run begins. Must be static.
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Runs once after the whole test run ends. Must be static.
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Runs before a feature starts. Must be static. Tag filtering possible.
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //Runs after a feature ends. Tag filtering possible.
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            //Runs before each scenario block.
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            //Runs after each scenario block.
        }

        [BeforeStep]
        public void BeforeStep()
        {
            //Runs just before each individual step.
        }

        [BeforeStep(Order =2)]
        public void BeforeStep2()
        {

        }

        [BeforeStep("@product", Order =1)]
        public void ProductBefireStep()
        {
            // for prduct tag scenarios
        }
    }
}