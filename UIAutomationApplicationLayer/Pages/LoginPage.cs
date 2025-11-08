using OpenQA.Selenium;
using UIAutomation.SeleniumCore.Actions;
using UIAutomationApplicationLayer.Actions;

namespace UIAutomationApplicationLayer.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement UsernameTextBoxEle => driver.GetElement(By.Id("user-name"));
        private IWebElement PasswordTextBoxEle => driver.GetElement(By.Id("password"));
        private IWebElement LoginButtonEle => driver.GetElement(By.Id("login-button"));
        private IWebElement AppLogoEle => driver.GetElement(By.CssSelector("[class='app_logo']"));

        public void EnterUsernameField(string username)
        {
            UsernameTextBoxEle.EnterText(username);
        }

        public void EnterPasswordField(string password)
        {
            PasswordTextBoxEle.EnterText(password);
        }

        public void ClickLoginButton()
        {
            LoginButtonEle.ClickUsingJS(driver);
        }
      
        public bool IsAppLogoDisplayed()
        {
            return AppLogoEle.IsDisplayed();
        }
    }
}
