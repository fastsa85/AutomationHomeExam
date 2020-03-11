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
    public class FiltersSideBar_StepDefinitions : BaseStepDefinitions
    {
        private IWebDriver webDriver;
        private FiltersSideBar filtersSdieBar;

        public FiltersSideBar_StepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            webDriver = this.objectContainer.Resolve<IWebDriver>();
            filtersSdieBar = new FiltersSideBar(webDriver);
        }

        [When(@"In the sidebar under ""(.*)"" check the ""(.*)""")]
        public void InTheSidebarUnderSectionTitleCheckTheFilter(string sectionTitle, string filter)
        {            
            filtersSdieBar.CheckFilter(sectionTitle, filter);            
        }

    }
}
