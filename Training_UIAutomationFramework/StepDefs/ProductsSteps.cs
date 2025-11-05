using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using UIAutomationApplicationLayer.Pages;

namespace Training_UIAutomationFramework.StepDefs
{
    [Binding]
    public class ProductsSteps
    {
        private readonly IWebDriver driver;
        private readonly ProductsPage productsPage;
        private readonly CartPage cartPage;
        private readonly CheckoutPage checkoutPage;

        string saucelabsItemPrice;

        public ProductsSteps(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["WebDriver"];
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }


        [When("select Sauce labs backpack from inventory")]
        public void WhenSelectSauceLabsBackpackFromInventory()
        {
            saucelabsItemPrice = productsPage.GetSaucelabsBackpackItemPrice();
            productsPage.ClickSaucelabsBackpackAddToCartButton();
        }

        [When("navigate to cart page")]
        public void WhenNavigateToCartPage()
        {
            productsPage.ClickShoppingCartbadgeIcon();
        }

        [Then("verify saucelabs backpack price")]
        public void ThenVerifySaucelabsBackpackPrice()
        {
            Assert.IsTrue(cartPage.IsSaucelabsItemPriceAsExpected(saucelabsItemPrice), "Selected item price is different.");
        }

        [When("navigate to checkout page")]
        public void WhenNavigateToCheckoutPage()
        {
            cartPage.ClickCheckoutButton();
        }

        [When("fill the address details firstname as (.*) lastname as (.*) postalcode as (.*) and continue to next")]
        public void WhenFillTheAddressDetailsFirstnameAsPrathameshLastnameAsHaradPostalcodeAsAndContinueToNext(string firstName, string lastName, string postalCode)
        {
            checkoutPage.FillInformation(firstName, lastName, postalCode);
            checkoutPage.ClickContinueButton();
        }

        [Then("verify sacucelabs packpack item and price")]
        public void ThenVerifySacucelabsPackpackItemAndPrice()
        {
            Assert.IsTrue(checkoutPage.IsSaucelabsBackpackItemVisible(), "Saucelabs backback item not selected.");
            Assert.IsTrue(checkoutPage.IsSaucelabsItemPriceAsExpected(saucelabsItemPrice), "Selected item price is different.");
        }

        [Then("finish the order")]
        public void ThenFinishTheOrder()
        {
            checkoutPage.clickFinishButton();
        }


    }
}
