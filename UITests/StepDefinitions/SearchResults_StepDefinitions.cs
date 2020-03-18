using AutomationHomeExam.PageObjects;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationHomeExam.StepDefinitions
{
    [Binding]
    class SearchResults_StepDefinitions : BaseStepDefinitions
    {
        private IWebDriver webDriver;
        private SearchResultsPage searchResults;

        public SearchResults_StepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            webDriver = this.objectContainer.Resolve<IWebDriver>();
            searchResults = new SearchResultsPage(webDriver);
        }

        [When(@"Click ""(.*)""")]
        public void Click(string searchResultTitle)
        {
            searchResults.ClickSearchResult(searchResultTitle);
        }
    }
}
