using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.SeleniumCore.Actions;
using UIAutomationApplicationLayer.Actions;

namespace UIAutomationApplicationLayer.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        private IWebElement FirstNameTextboxEle => driver.GetElement(By.Id("first-name"));
        private IWebElement LastNameTextboxEle => driver.GetElement(By.Id("last-name"));
        private IWebElement PostalCodeTextboxEle => driver.GetElement(By.Id("postal-code"));
        private IWebElement ContinueButtonEle => driver.GetElement(By.Id("continue"));

        private IWebElement SaucelabsBackpackInventoryItemEle => driver.GetElement(By.XPath("//div[@data-test='inventory-item']/div[contains(., 'Sauce Labs Backpack')]"));
        private IWebElement SaucelabsBackpackItemPriceEle => driver.GetElement(By.XPath("//div[@data-test='inventory-item']//div[@class='inventory_item_price']"));
        private IWebElement FinishButtonEle => driver.GetElement(By.Id("finish"));


        public void FillInformation(string firstName, string lastName, string postalCode)
        {
            FirstNameTextboxEle.EnterText(firstName);
            LastNameTextboxEle.EnterText(lastName);
            PostalCodeTextboxEle.EnterText(postalCode);
        }

        public void ClickContinueButton()
        {
            ContinueButtonEle.Click();
        }

        public bool IsSaucelabsBackpackItemVisible()
        {
            return SaucelabsBackpackInventoryItemEle.IsDisplayed();
        }

        public bool IsSaucelabsItemPriceAsExpected(string expectedPrice)
        {
            return SaucelabsBackpackItemPriceEle.GetText().Contains(expectedPrice);
        }

        public void clickFinishButton()
        {
            FinishButtonEle.Click();
        }
    }
}
