using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationHomeExam.WebDriver
{
    /// <summary>
    /// Web Driver Extensions methods
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Clicks web element using java script execution
        /// </summary>
        /// <param name="webDriver">Web Driver instance</param>
        /// <param name="element">Web Element to be clicked</param>
        public static void ClickUsingJavaScript(this IWebDriver webDriver, IWebElement element)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)webDriver);            
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}
