using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomationHomeExam.WebDriver;

namespace AutomationHomeExam.PageObjects
{
    class SearchResultsPage : BasePage
    {
        private const string SEARCH_RESULT_BY_TITLE_XPATH = "//div[@data-asin][.//span[contains(text(), '{0}')]]";
        private const string SEARCH_RESULT_LINK = ".//a[@class = 'a-link-normal']";        
        
        public IWebElement buttonNext => webDriver.FindElement(By.CssSelector("li.a-last"));

        public SearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <summary>
        /// Clicks Search Result item from list. Uses pagination if no such item on current page.
        /// </summary>
        /// <param name="title">Search result to click (Product title)</param>
        public void ClickSearchResult(string title)
        {
            var isClicked = false;
            while (!isClicked && IsButtonNextEnabled())
            {
                var searchResult = getSearchResult(title);
                if (searchResult != null)
                {                    
                    IWebElement element = searchResult.FindElement(By.XPath(SEARCH_RESULT_LINK));
                    webDriver.ClickUsingJavaScript(element);
                    isClicked = true;
                }
                else
                {
                    ClickNext();
                }
            }
        }

        /// <summary>
        /// Clicks button Next in pagination
        /// </summary>
        public void ClickNext()
        {
            buttonNext?.Click();
        }

        /// <summary>
        /// Define if button Next is enabled in pagination
        /// </summary>
        /// <returns></returns>
        public bool IsButtonNextEnabled()
        {
            return !buttonNext.GetAttribute("class").Contains("disabled");
        }

        private IWebElement getSearchResult(string title)
        {
            return webDriver.FindElements(By.XPath(String.Format(SEARCH_RESULT_BY_TITLE_XPATH, title))).FirstOrDefault();
        }
    }
}
