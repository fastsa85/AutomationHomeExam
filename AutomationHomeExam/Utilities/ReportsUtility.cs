using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationHomeExam.Utilities
{
    public class ReportsUtility
    {        
        /// <summary>
        /// Initialize Report
        /// </summary>
        /// <param name="configuration">Report Configuration</param>
        /// <returns></returns>
        public static AventStack.ExtentReports.ExtentReports InitializeReport(IConfiguration configuration)
        {
            var reportPath = getReportsFolder(configuration);

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            AventStack.ExtentReports.ExtentReports extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            return extent;
        }

        /// <summary>
        /// Takes screenshot from web browser
        /// </summary>
        /// <param name="webDriver">Web Driver instance</param>
        /// <param name="configuration">Report Configuration</param>
        /// <returns>Relative path to created screenshot</returns>
        public static string TakeScreenshot(IWebDriver webDriver, IConfiguration configuration)
        {            
            Screenshot file = ((ITakesScreenshot)webDriver).GetScreenshot();

            string fileName = DateTime.UtcNow.Ticks.ToString() + ".png";
            string filePath = Path.Combine(getScreenshotsFolder(configuration), fileName);
            file.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return Path.GetRelativePath(getReportsFolder(configuration), filePath).Replace("..", "").Replace("\\","/").Trim('/');
        }

        /// <summary>
        /// Creates Screenshots folder where screenshots will be saved (overwrite if already exists)
        /// </summary>
        /// <param name="configuration">Report Configuration</param>
        public static void CreateScreenshotsfolder(IConfiguration configuration)
        {
            var path = getScreenshotsFolder(configuration);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
            }
            else
                Directory.CreateDirectory(path);
        }
 
        private static string getReportsFolder(IConfiguration configuration)
        {
            return Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()),
                Path.Combine(configuration["ReportPath"].Split("/")));
        }

        private static string getScreenshotsFolder(IConfiguration configuration)
        {
            return Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()),
                Path.Combine(configuration["ScreenshotsPath"].Split("/")));
        }
    }
}
