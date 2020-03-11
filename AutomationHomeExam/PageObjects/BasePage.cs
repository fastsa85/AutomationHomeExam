using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationHomeExam.PageObjects
{
    public abstract class BasePage
    {        
        protected IWebDriver webDriver;

        protected BasePage(IWebDriver webDriver) => this.webDriver = webDriver;
    }
}
