using NUnit.Framework;
using static UnitTestNDBProject.Base.BasePageClass;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestNDBProject.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using UnitTestNDBProject.Pages;
using System.Configuration;
using System.IO;
using NLog;

[SetUpFixture]
public class GlobalSetup
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    public static ExtentReports extent;
    public static ExtentReports report;
    public static ExtentHtmlReporter htmlReporter;
    public static ExtentTest test;


    /// <summary>
    /// This method would be called before all the class execution
    /// </summary>
    [OneTimeSetUp]
    public void BeforeSuit()
    {
        LogManager.Configuration.Variables["logdirectory"] = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\logs\\NdbPOS";
        //"Environment.CurrentDirectory" Can be used//
        string FilePath = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\Report\\EReport.html";
        htmlReporter = new ExtentHtmlReporter(FilePath);
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "Test Report | Khushboo Kapoor";
        htmlReporter.Config.ReportName = "KK Test Report | Khushboo Kapoor";
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        _logger.Info(" :Successfully executed the BeforeSuit() method of " + this.GetType().Name);

    }

    /// <summary>
    /// This method would be called after execution of all the classes
    /// </summary>
    [OneTimeTearDown]
    public void AfterSuit()
    {
        extent.Flush();
        _logger.Info(" :Successfully executed the AfterSuit() method of " + this.GetType().Name);
    }
}

namespace UnitTestNDBProject.Base
{

    [TestFixture]
    public class BaseTestClass
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IWebDriver driver { get; set; }
        public SearchPage SearchPage_ { get; set; }
        public BasePageClass BasePageClass_ { get; set; }
        public HomePage HomePage_ { get; set; }
        public ScreenshotUtil ScreenshotUtil_ { get; set; }
        public LoginPage LoginPage_ { get; set; }


        /// <summary>
        /// This method would be called before execution of each class
        /// </summary>
        [OneTimeSetUp]

        public void BeforeClassInitialization()
        {
            if (ConfigurationManager.AppSettings["Browser"] == "Chrome")
            {
                driver = new ChromeDriver();
            }
            else if (ConfigurationManager.AppSettings["Browser"] == "Firefox")
            {
                driver = new FirefoxDriver();
            }

            LoginPage_ = new LoginPage(driver);
            SearchPage_ = new SearchPage(driver);
            BasePageClass_ = new BasePageClass(driver);
            HomePage_ = new HomePage(driver);
            ScreenshotUtil_ = new ScreenshotUtil(driver);

            ScreenshotUtil_.SaveScreenShot($"Failed Test{this.GetType().Name}");
            BasePageClass_.OpenURL();

            _logger.Info($" :Successfully executed the BeforeClassInitialization() method for {this.GetType().Name}");

        }

        /// <summary>
        /// This method would be called after execution of each class
        /// </summary>
        [OneTimeTearDown]
        public void AfterClassCLoseDriver()
        {
            driver.Quit();

            _logger.Info($" :Successfully executed the AfterClassCLoseDriver() method for {this.GetType().Name}");
        }


    }
}
