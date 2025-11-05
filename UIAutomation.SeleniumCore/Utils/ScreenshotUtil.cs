using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.SeleniumCore.Utils
{
    public class ScreenshotUtil
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();

            // Create timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Path to save
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, screenshotName + "_" + timestamp + ".png");

            screenshot.SaveAsFile(filePath);
            Console.WriteLine("Screenshot saved at: " + filePath);
            return filePath;
        }
    }
}
