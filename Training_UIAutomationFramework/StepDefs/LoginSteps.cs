using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.IO;
using UIAutomationApplicationLayer.Pages;

namespace Training_UIAutomationFramework
{
    [Binding]
    public class GithubLoginStepDefinitions
    {
        private readonly IWebDriver driver;
        private static readonly ILog log = LogManager.GetLogger(typeof(GithubLoginStepDefinitions));
        private readonly LoginPage loginPage;
        private readonly ProductsPage productsPage;

        public GithubLoginStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["WebDriver"];
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
        }

        [Given("I enter username as (.*)")]
        public void WhenIEnterUsernameAs(string username)
        {
            log.Info($"Entering username {username}.");
            loginPage.EnterUsernameField(username);
        }

        [Given("I enter password as (.*)")]
        public void WhenIEnterPasswordAs(string password)
        {
            log.Info($"Entering password {password}.");
            loginPage.EnterPasswordField(password);
        }

        [When("I click login")]
        public void WhenIClickLogin()
        {
            log.Info("Clicking on Login button.");
            loginPage.ClickLoginButton();
        }

        [Then("I should be logged in with proper user")]
        public void ThenIShouldBeLoggedInWithProperUser()
        {
            Assert.IsTrue(loginPage.IsAppLogoDisplayed(), "User is not able to log in with given credentials.");
        }

        [Given("I log in to website using username as (.*) and password as (.*)")]
        public void GivenILogInToWebsiteUsingUsernameAndPassword(string username, string password)
        {
            loginPage.EnterUsernameField(username);
            loginPage.EnterPasswordField(password);
            loginPage.ClickLoginButton();
            Assert.IsTrue(loginPage.IsAppLogoDisplayed(), "User is not able to log in with given credentials.");
        }
    }
}
