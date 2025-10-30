using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationApplicationLayer.Drivers
{
    public class DriverFactory
    {
        private IWebDriver driver;

        public IWebDriver InitDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
