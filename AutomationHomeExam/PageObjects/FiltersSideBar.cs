using OpenQA.Selenium;
using System;

namespace AutomationHomeExam.PageObjects
{
    public class FiltersSideBar : BasePage
    {
        private const string FILTERS_BY_SECTION_AND_NAME_XPATH = "//*[text()='{0}']/ancestor::div/following-sibling::ul[1]//li[.//*[text()='{1}']]//i";

        public FiltersSideBar(IWebDriver webDriver) : base(webDriver)
        {
        }   
        
        /// <summary>
        /// Checks filter in specified Filters section
        /// </summary>
        /// <param name="sectionTitle">Filters section title</param>
        /// <param name="filter">Filter name to select</param>
        public void CheckFilter(string sectionTitle, string filter)
        {
            getCheckboxFilter(sectionTitle, filter).Click();
        }

        private IWebElement getCheckboxFilter(string sectionTilte, string filter)
        {
            return webDriver.FindElement(By.XPath(String.Format(FILTERS_BY_SECTION_AND_NAME_XPATH, sectionTilte, filter)));
        }
    }    
}
