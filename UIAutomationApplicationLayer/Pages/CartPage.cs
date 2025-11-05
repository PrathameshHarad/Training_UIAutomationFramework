using OpenQA.Selenium;
using UIAutomationApplicationLayer.Actions;

namespace UIAutomationApplicationLayer.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private IWebElement SaucelabsBackpackPriceEle => driver.GetElement(By.XPath("//div[@class='cart_item_label']//a[contains(., 'Sauce Labs Backpack')]/..//div[@class='inventory_item_price']"));
        private IWebElement CheckoutButtonEle => driver.GetElement(By.Id("checkout"));

        public string GetSaucelabsBackpackItemPrice()
        {
            return SaucelabsBackpackPriceEle.GetText();
        }

        public void ClickCheckoutButton()
        {
            CheckoutButtonEle.Click();
        }

        public bool IsSaucelabsItemPriceAsExpected(string expectedPrice)
        {
            return SaucelabsBackpackPriceEle.GetText().Contains(expectedPrice);
        }

    }
}
