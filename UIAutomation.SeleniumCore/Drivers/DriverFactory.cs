using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace UIAutomationApplicationLayer.Drivers
{
    public class DriverFactory
    {

        public IWebDriver InitDriver()
        {
            var browser = ConfigurationManager.AppSettings["Browser"];
            switch (browser.ToLower())
            {
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    return new ChromeDriver();
            }
        }
    }
}
