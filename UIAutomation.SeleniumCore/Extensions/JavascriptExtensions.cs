using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.SeleniumCore.Actions
{
    public static class JavascriptExtensions
    {
        public static void ClickUsingJS(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public static void EnterTextUsingJS(this IWebElement element, string value, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].value='{value}';", element);
        }

    }
}
