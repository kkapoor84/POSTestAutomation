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
using UnitTestNDBProject.Base;

[SetUpFixture]
public class GlobalSetup
{
    public static ExtentReports extent;
    public static ExtentReports report;
    public static ExtentHtmlReporter htmlReporter;
    public static ExtentTest test;
    public BrowserType browser;
    public static IWebDriver driver;
    public enum BrowserType
    {
        Chrome, Firefox, IE
    }

    

    [OneTimeSetUp]
    public void BeforeSuit()
    {
        htmlReporter = new ExtentHtmlReporter(@"D:\Automation\POS\NDBPOS-AUTOMATION\UnitTestNDBProject\UnitTestNDBProject\Report\EReport.html");
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "Test Report | POS";
        htmlReporter.Config.ReportName = "POS Test Report | POS";
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        //if (browser == BrowserType.Chrome)
        //{
        //    driver = new ChromeDriver();
        //}
        //else if (browser == BrowserType.Firefox)
        //{
        //    driver = new FirefoxDriver();
        //}

        //Initialization();
        //OpenURL();
       // ScreenshotUtil.SaveScreenShot("firstfile");
    }

    [OneTimeTearDown]
    public void AfterSuit()
    {
        //PropertiesCollection.driver.Quit();
        extent.Flush();
        //driver.Quit();
    }
}

namespace UnitTestNDBProject.Base
{
    public enum BrowserType
    {
        Chrome, Firefox, IE
    }

    [TestFixture]
    public class BaseTestClass
    {
        public static IWebDriver driver;
        public BrowserType browser;
        public LoginPage LP;
        public EnterNewCustomerPage newCustomer;
        public SearchPage SP;
        public BasePageClass BPC;

        public BaseTestClass(BrowserType brows)
        {
            browser = brows;
        }

        [OneTimeSetUp]
        public void BeforeClassInitialization()
        {
            if (browser == BrowserType.Chrome)
            {
                driver = new ChromeDriver();
            }
            else if (browser == BrowserType.Firefox)
            {
                driver = new FirefoxDriver();
            }

            LP = new LoginPage(driver);
            SP = new SearchPage(driver);
            BPC = new BasePageClass(driver);
            newCustomer = new EnterNewCustomerPage(driver);
            BPC.OpenURL();

        }


        [OneTimeTearDown]
        public void AfterClassCLoseDriver()
        {
            driver.Quit();
        }


    }
}
