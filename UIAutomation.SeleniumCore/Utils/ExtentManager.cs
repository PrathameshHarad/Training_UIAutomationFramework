using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace UIAutomation.SeleniumCore.Utils
{
    public class ExtentManager
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        public static ExtentReports GetExtent()
        {
            if (extentReports == null)
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "TestReport.html");
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

                var htmlReporter = new ExtentHtmlReporter(reportPath);
                htmlReporter.Config.DocumentTitle = "Automation Test Report";
                htmlReporter.Config.ReportName = "SauceDemo Regression Report";
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

                extentReports = new ExtentReports();
                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }

        public static ExtentTest CreateTest(string testName)
        {
            extentTest = GetExtent().CreateTest(testName);
            return extentTest;
        }

        public static ExtentTest GetTest()
        {
            return extentTest;
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
