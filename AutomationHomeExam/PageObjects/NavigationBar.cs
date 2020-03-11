using OpenQA.Selenium;

namespace AutomationHomeExam.PageObjects
{
    /// <summary>
    /// Represents Navigation Bar on top of page
    /// </summary>
    public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver webDriver) : base (webDriver)
        {            
        }

        /// <summary>
        /// Input Search text field 
        /// </summary>
        public IWebElement inputSearchText => webDriver.FindElement(By.Id("twotabsearchtextbox"));

        /// <summary>
        /// Button Submit Search (button with 'Loupe' icon)
        /// </summary>
        public IWebElement buttonSearchSubmit => webDriver.FindElement(By.CssSelector(".nav-input"));
        
        /// <summary>
        /// Execute search by specified search 
        /// </summary>
        /// <param name="searchItem">What to search</param>
        public void SearchFor(string searchItem)
        {
            inputSearchText.Clear();
            inputSearchText.SendKeys(searchItem);
            buttonSearchSubmit.Click();
        }
    }
}
