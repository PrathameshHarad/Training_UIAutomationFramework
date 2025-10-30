using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UIAutomation.SeleniumCore.Extensions
{
    public static class MouseKeyboardExtensions
    {
        public static void HoverElement(this IWebDriver driver, IWebElement element)
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);
            action.MoveToElement(element);
        }
    }
}
