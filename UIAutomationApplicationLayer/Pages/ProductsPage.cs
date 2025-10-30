using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationApplicationLayer.Actions;

namespace UIAutomationApplicationLayer.Pages
{
    public class ProductsPage : BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        // Elements
        private IWebElement ProductSortContanerSelect => driver.GetElement(By.CssSelector("[data-test='product-sort-container']"));
        private List<IWebElement> InventoryItemPriceTextsEle => driver.GetElements(By.CssSelector("[data-test='inventory-item-price']"));


        // Actions
        public void SelectPriceAsLowToHigh(string sortBy)
        {
            ProductSortContanerSelect.SelectDropdownByText(sortBy);
        }
    }
}
