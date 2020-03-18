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
    public class NavigationBar_StepDefinitions : BaseStepDefinitions
    {        
        private IWebDriver webDriver;
        private NavigationBar navigationBar;

        public NavigationBar_StepDefinitions(IObjectContainer objectContainer) : base (objectContainer)
        {            
            webDriver = this.objectContainer.Resolve<IWebDriver>();
            navigationBar = new NavigationBar(webDriver);
        }

        [When(@"Search for ""(.*)""")]
        public void SearchFor(string searchItem)
        {            
            navigationBar.SearchFor(searchItem); 
        }
    }
}
