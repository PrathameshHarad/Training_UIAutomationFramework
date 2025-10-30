using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.SeleniumCore.Actions
{
    public static class AlertActions
    {
        public static void AcceptAlert(this IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
