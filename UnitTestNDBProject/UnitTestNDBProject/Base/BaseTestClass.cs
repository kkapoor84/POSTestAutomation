using NUnit.Framework;
using static UnitTestNDBProject.Base.BasePageClass;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestNDBProject.Utils;

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
        htmlReporter = new ExtentHtmlReporter(@"D:\Next Day Blinds\UnitTestNDBProject\UnitTestNDBProject\UnitTestNDBProject\Report\EReport.html");
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "Test Report | Khushboo Kapoor";
        htmlReporter.Config.ReportName = "KK Test Report | Khushboo Kapoor";
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        Initialization();
     
        OpenURL();
        ScreenshotUtil.SaveScreenShot("firstfile");
    }

    [OneTimeTearDown]
    public void AfterSuit()
    {
        PropertiesCollection.driver.Quit();
        extent.Flush();
    }
}
