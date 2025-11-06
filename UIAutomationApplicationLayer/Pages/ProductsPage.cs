using OpenQA.Selenium;
using System.Threading;
using UIAutomation.SeleniumCore.Actions;
using UIAutomationApplicationLayer.Actions;

namespace UIAutomationApplicationLayer.Pages
{
    public class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        // Elements
        private IWebElement SauceLabsBackpackPriceEle => driver.GetElement(By.XPath("//div[@class='inventory_item']/div[contains(., 'Sauce Labs Backpack')]/..//div[@class='inventory_item_price']"));
        private IWebElement SauceLabsBackpackAddToCartButtonEle => driver.GetElement(By.XPath("//div[@class='inventory_item']/div[contains(., 'Sauce Labs Backpack')]/..//button[@id='add-to-cart-sauce-labs-backpack']"));

        private IWebElement ShoppingCartbadgeIconEle => driver.GetElement(By.CssSelector("[data-test='shopping-cart-badge']"));

        // Actions
        public void ClickSaucelabsBackpackAddToCartButton()
        {
            SauceLabsBackpackAddToCartButtonEle.Click();
        }

        public string GetSaucelabsBackpackItemPrice()
        {
            return SauceLabsBackpackPriceEle.GetText();
        }

        public void ClickShoppingCartbadgeIcon()
        {
            ShoppingCartbadgeIconEle.Click();
        }

    }
}
