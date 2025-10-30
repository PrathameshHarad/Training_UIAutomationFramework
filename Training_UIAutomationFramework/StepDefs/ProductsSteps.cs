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

        public ProductsSteps(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["WebDriver"];
            productsPage = new ProductsPage(driver);
        }


        [When("I filter price as low to high as (.*)")]
        public void WhenIFilterPriceAsLowToHighAs (string sortBy)
        {
            productsPage.SelectPriceAsLowToHigh(sortBy);
        }

        [Then("I results should be sorted to price low to high")]
        public void ThenIResultsShouldBeSortedToPriceLowToHigh()
        {
            
        }

    }
}
