using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutomationHomeExam.WebDriver
{   
    /// <summary>
    /// Web Driver Factory
    /// </summary>
    public class WebDriverFactory
    {
        /// <summary>
        /// Creates instance of Web Driver using Web Driver Configuration 
        /// </summary>
        /// <param name="configuration">Web Driver Configuration</param>
        /// <returns>INew instance of Selenium Web Driver</returns>
        public IWebDriver CreateWebDriver(IConfiguration configuration)
        {
            IWebDriver webDriverToReturn;            

            var webDriverToUse = configuration["WebDriverToUse"];

            switch (webDriverToUse)
            {                
                case "Chrome":                    
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument($"--user-agent={configuration["UserAgent"]}");                    
                    chromeOptions.AddArguments(configuration.GetSection("Arguments").Get<List<string>>());                    
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

                    if (configuration.GetSection("UseRemote").Get<bool>())
                    {
                        webDriverToReturn = new RemoteWebDriver(configuration.GetSection("RemoteURI").Get<Uri>(), chromeOptions);                        
                    }
                    else
                        webDriverToReturn = new ChromeDriver(Directory.GetCurrentDirectory(),chromeOptions); 
                    break;

                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();                    
                    firefoxOptions.SetPreference("general.useragent.override", $"{configuration["UserAgent"]}");
                    firefoxOptions.AddArguments(configuration.GetSection("Arguments").Get<List<string>>());
                    firefoxOptions.PageLoadStrategy = PageLoadStrategy.Eager;

                    if (configuration.GetSection("UseRemote").Get<bool>())
                    {
                        webDriverToReturn = new RemoteWebDriver(configuration.GetSection("RemoteURI").Get<Uri>(), firefoxOptions);
                    }
                    else                        
                        webDriverToReturn = new FirefoxDriver(Directory.GetCurrentDirectory(), firefoxOptions);                   
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
           
            webDriverToReturn.Manage().Window.Maximize();
            var timeouts = webDriverToReturn.Manage().Timeouts();

            timeouts.ImplicitWait = TimeSpan.FromSeconds(configuration.GetSection("ImplicitlyWait").Get<int>());
            timeouts.PageLoad = TimeSpan.FromSeconds(configuration.GetSection("PageLoadTimeout").Get<int>());

            return webDriverToReturn;            
        }  
    }
}
