using AutomationHomeExam.Utilities;
using AutomationHomeExam.WebDriver;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationHomeExam.StepDefinitions
{
    [Binding]
    class Hooks : BaseStepDefinitions
    {
        private static IConfiguration configuration;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        public Hooks(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [BeforeTestRun]
        public static void BeforeTestRunSetup()
        {
            InitializeConfiguration();
            InitializeReport();
        }

        [BeforeFeature]
        public static void BeforeFeatureSetup()
        {              
            feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioSetup()
        {
            InitializeWebDriver();

            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);            
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            InsertReportSteprs();

            var driver = objectContainer.Resolve<IWebDriver>();            
        }

        [AfterScenario]
        public void TearDownWebDriver()
        {
            var webDriver = objectContainer.Resolve<IWebDriver>();

            webDriver.Quit();
            webDriver.Dispose();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {            
            extent.Flush();
        }

        private static void InitializeConfiguration()
        {
            configuration = ConfigurationUtility.InitializeConfiguration();            
        }
       
        private static void InitializeReport()
        {            
            var reportConfig = configuration.GetSection("ReportConfiguration");
            extent = ReportsUtility.InitializeReport(reportConfig);
            ReportsUtility.CreateScreenshotsfolder(reportConfig);
        }       

        private void InitializeWebDriver()
        {            
            var webDriver = new WebDriverFactory().CreateWebDriver(configuration.GetSection("WebDriverConfiguration"));
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);

        }

        private void InsertReportSteprs()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {                
                var webDriver = objectContainer.Resolve<IWebDriver>();
                string screenshot = ReportsUtility.TakeScreenshot(webDriver, configuration.GetSection("ReportConfiguration"));

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.ToString(), 
                        MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.ToString(),
                        MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.ToString(),
                        MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());               
                                
            }
        }
    }
}
