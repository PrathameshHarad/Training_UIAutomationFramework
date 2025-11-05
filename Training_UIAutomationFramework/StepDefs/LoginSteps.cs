using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.IO;
using UIAutomation.SeleniumCore.Utils;
using UIAutomationApplicationLayer.Pages;

namespace Training_UIAutomationFramework
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["WebDriver"];
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            loginPage = new LoginPage(driver);
        }

        [Given("I enter username as (.*)")]
        public void WhenIEnterUsernameAs(string username)
        {
            Logger.Info($"Entering username {username}.");
            loginPage.EnterUsernameField(username);
        }

        [Given("I enter password as (.*)")]
        public void WhenIEnterPasswordAs(string password)
        {
            Logger.Info($"Entering password {password}.");
            loginPage.EnterPasswordField(password);
        }

        [When("I click login")]
        public void WhenIClickLogin()
        {
            Logger.Info("Clicking on Login button.");
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
