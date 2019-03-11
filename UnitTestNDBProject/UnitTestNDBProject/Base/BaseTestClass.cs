﻿using NUnit.Framework;
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

[SetUpFixture]
public class GlobalSetup
{
    public static ExtentReports extent;
    public static ExtentReports report;
    public static ExtentHtmlReporter htmlReporter;
    public static ExtentTest test;


    [OneTimeSetUp]
    public void BeforeSuit()
    {
        htmlReporter = new ExtentHtmlReporter(@"D:\NDBPOS-AUTOMATION-ST\UnitTestNDBProject\UnitTestNDBProject\Report\EReport.html");
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "Test Report | Khushboo Kapoor";
        htmlReporter.Config.ReportName = "KK Test Report | Khushboo Kapoor";
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        // Initialization();
        // OpenURL();
        //ScreenshotUtil.SaveScreenShot("firstfile");
    }

    [OneTimeTearDown]
    public void AfterSuit()
    {
        //PropertiesCollection.driver.Quit();
        extent.Flush();
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
        public IWebDriver driver;
        public BrowserType browser;
        public LoginPage LP;
        public SearchPage SP;
        public BasePageClass BPC;
        public HomePage HP;

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
            HP = new HomePage(driver);
            BPC.OpenURL();

        }


        [OneTimeTearDown]
        public void AfterClassCLoseDriver()
        {
            driver.Quit();
        }


    }
}
