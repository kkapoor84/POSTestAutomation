

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NLog;
using NUnit.Framework;
using System.IO;

[SetUpFixture]
public class GlobalSetUp
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public static ExtentReports extent;
    public static ExtentReports report;
    public static ExtentHtmlReporter htmlReporter;
    public static ExtentTest test;

    /// <summary>
    /// This method would be called before execution of each class
    /// </summary>
    [OneTimeSetUp]
    public void BeforeSuite()
    {

        LogManager.Configuration.Variables["logdirectory"] = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\logs\\NdbPOS";
        // LogManager.Configuration.Variables["logdirectory"] = "..\\UnitTestNDBProject\\UnitTestNDBProject\\logs\\NdbPOS";
        string FilePath = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\Report\\EReport.html";
        // string FilePath = "..\\UnitTestNDBProject\\UnitTestNDBProject\\Report\\EReport.html";
        htmlReporter = new ExtentHtmlReporter(FilePath);
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = "Test Report | Point Of Sales";
        htmlReporter.Config.ReportName = "POS Test Report | Point Of Sales";
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        _logger.Info(" :Successfully executed the BeforeSuit() method of " + this.GetType().Name);
    }

    /// <summary>
    /// This method would be called after execution of each class
    /// </summary>
    [OneTimeTearDown]
    public void Aftersuite()
    {
        extent.Flush();
        _logger.Info(" :Successfully executed the AfterSuit() method of " + this.GetType().Name);
    }


}




