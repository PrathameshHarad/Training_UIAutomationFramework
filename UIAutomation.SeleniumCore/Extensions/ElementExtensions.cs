using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UIAutomationApplicationLayer.Actions
{
    public static class ElementExtensions
    {
        public static IWebElement GetElement(this IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static List<IWebElement> GetElements(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            return driver.FindElements(locator).ToList();
        }


        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }

        public static bool IsDisplayed(this IWebElement element)
        {
           return  element.Displayed;
        }

        public static void SelectDropdownByText(this IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void WaitForElementVisible(this IWebDriver driver, By locator, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementVisible(this IWebDriver driver, IWebElement element, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(
                _ =>
                {
                    try
                    {
                        return element.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    
                    }
                );
        }

    }
}
