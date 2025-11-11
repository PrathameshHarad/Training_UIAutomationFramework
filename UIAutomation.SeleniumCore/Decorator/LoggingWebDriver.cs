using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.SeleniumCore.Decorator
{
    public class LoggingWebDriver : WebDriverDecorator
    {
        public LoggingWebDriver(IWebDriver driver) : base(driver)
        {
        }

        public override IWebElement FindElement(By by)
        {
            Console.WriteLine($"[LOG] Finding element: {by}");
            try
            {
                var element = base.FindElement(by);
                Console.WriteLine($"[LOG] Element found: {by}");
                return element;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"[ERROR] Element not found: {by}");
                throw;
            }
        }

        public override void Quit()
        {
            Console.WriteLine("[Log] Quitting browser");
            driver.Quit();
        }
    }
}
