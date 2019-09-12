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
using UnitTestNDBProject.TestDataAccess;
using OpenQA.Selenium.Interactions;
using UnitTestNDBProject.Page;



namespace UnitTestNDBProject.Base
{

    [TestFixture]
    public class BaseTestClass
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IWebDriver driver { get; set; }
        public BasePageClass _BasePageClass { get; set; }
        public HomePage _HomePage { get; set; }
        public ScreenshotUtil _ScreenshotUtil { get; set; }
        public LoginPage _LoginPage { get; set; }        
        public EnterNewCustomerPage _EnterNewCustomerPage { get; set; }
        public QuotePage _QuotePage { get; set; }
        public PaymentPage _PaymentPage { get; set; }
        public OrderPage _OrderPage { get; set; }
        public SearchPage _SearchPage { get; set; }
        public MeasurementAndInstallationPage _MeasurementAndInstallationPage { get; set; }

        public NotePage _NotePage { get; set; }

        public QuickConfig _QuickConfig  { get; set; }

        /// <summary>
        /// This method would be called before execution of each class
        /// </summary>
        [OneTimeSetUp]

        public void BeforeClassInitialization()
        {
            if (ConfigurationManager.AppSettings["Browser"] == "Chrome")
            {
                var co = new ChromeOptions();
                co.AddArgument("no-sandbox");
                //co.AddArgument("--window-size=1920,1080");
                //co.AddArgument("--disable-gpu");
                //co.AddArgument("--disable-extensions");
                //co.AddArgument("--start-maximized");
                //co.AddArgument("--headless");
                driver = new ChromeDriver(co);
              
            }
            else if (ConfigurationManager.AppSettings["Browser"] == "Firefox")
            {
                driver = new FirefoxDriver();
            }

            _ScreenshotUtil = new ScreenshotUtil(driver);
            _LoginPage = new LoginPage(driver);
            _BasePageClass = new BasePageClass(driver);
            _HomePage = new HomePage(driver);            
            _EnterNewCustomerPage = new EnterNewCustomerPage(driver);
            _QuotePage = new QuotePage(driver);
            _PaymentPage = new PaymentPage(driver);
            _OrderPage = new OrderPage(driver);
            _SearchPage = new SearchPage(driver);
            _QuickConfig = new QuickConfig(driver);
            _NotePage = new NotePage(driver);
            _MeasurementAndInstallationPage = new MeasurementAndInstallationPage(driver);
            _BasePageClass.OpenURL();
            _logger.Info($" :Successfully executed the BeforeClassInitialization() method for {this.GetType().Name}");
        }

        /// <summary>
        /// This method would be called after execution of each class
        /// </summary>
        [OneTimeTearDown]
        public void AfterClassCloseDriver()
        {
           driver.Quit();

            _logger.Info($" :Successfully executed the AfterClassCloseDriver() method for {this.GetType().Name}");
        }


    }
}
