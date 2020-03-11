using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationHomeExam.PageObjects
{
    class ProductDetailsPage : BasePage
    {
        private const string COLOR_OPTION_BY_COLOR_NAME = "div[id=variation_color_name] li[title*={0} i]";

        /// <summary>
        /// Button 'Buy Now'
        /// </summary>
        public IWebElement buttonBuyNow => webDriver.FindElement(By.Id("buy-now-button"));

        public ProductDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <summary>
        /// Clicks on color option 
        /// </summary>
        /// <param name="color">Color to select (case insencetive)</param>
        public void ClickColorOption(string color)
        {
            getColorOptionByName(color).Click();
        }

        private IWebElement getColorOptionByName(string color)
        {
            return webDriver.FindElement(By.CssSelector(String.Format(COLOR_OPTION_BY_COLOR_NAME, color)));
        }
    }
}
