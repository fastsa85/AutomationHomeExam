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
    class ProductDetails_StepDefinitions : BaseStepDefinitions
    {
        private IWebDriver webDriver;
        private ProductDetailsPage productDetailsPage;

        public ProductDetails_StepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            webDriver = this.objectContainer.Resolve<IWebDriver>();
            productDetailsPage = new ProductDetailsPage(webDriver);
        }

        [When(@"Choose color: ""(.*)""")]
        public void ChooseColor(string color)
        {
            productDetailsPage.ClickColorOption(color);            
        }

        [When(@"Click the ""Buy Now"" button")]
        public void ClickTheBuyNowButton()
        {
            productDetailsPage.buttonBuyNow.Click();
        }
    }
}
