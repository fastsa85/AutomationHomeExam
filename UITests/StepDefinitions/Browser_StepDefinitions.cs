using BoDi;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationHomeExam.StepDefinitions
{
    [Binding]
    public class Browser_StepDefinitions : BaseStepDefinitions
    {        
        private IWebDriver webDriver;

        public Browser_StepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {            
            webDriver = this.objectContainer.Resolve<IWebDriver>();
        }

        [Given(@"Go to ""(.*)""")]
        public void GoTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);            
        }
    }
}
