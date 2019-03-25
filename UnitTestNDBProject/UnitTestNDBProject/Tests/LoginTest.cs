﻿using NUnit.Framework;
using System.Threading;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NLog;
using UnitTestNDBProject.Utils;

[TestFixture]

public class LoginTest : BaseTestClass
{
    private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    [SetUp]
    public void Setup()
    {
     GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [Test, Category("Regression"),Category("Smoke"),Description("Validate that error message populates once user enter invalid credentials")]
    public void A1_VerifyLoginWithInValidCredentails()
    {
        SheetData sheetData = ExcelDataAccess.GetTestData("LoginScreen$", "InValidCredentials");


        LoginPage_.EnterUserName(sheetData.Username).EnterPassword(sheetData.Password).ClickLoginButton();
        _logger.Info($": Successfully Entered invalid username {sheetData.Username}and password {sheetData.Password} and clicked on login button");

        Assert.True(LoginPage_.VerifyInvalidCredentialsAreDisplayed("Aser ID or Password are incorrect. Please try again or contact the NDB helpdesk"));
        _logger.Info($": Successfully Verified the message displayed after entering invalid username {sheetData.Username} and password {sheetData.Password}");
    }
    

    [Test,Category("Regression"), Category("Smoke"),Description("Validate that user is able to navigate to Home page using valid credentials")]
    public void A2_VerifyLoginWithValidCrdentails()
    {
        SheetData sheetData = ExcelDataAccess.GetTestData("LoginScreen$", "SAHUserValidCredentails");

        LoginPage_.EnterUserName(sheetData.Username).EnterPassword(sheetData.Password).ClickLoginButton();
        _logger.Info($": Successfully Entered valid username {sheetData.Username} and password {sheetData.Password} and clicked on login button");

        HomePage_.ClickShopAtHomeTab();
        _logger.Info($": Successfully CLicked on Shop at Home Tab on homepage");

       Assert.True(HomePage_.VerifyShopAtHomeTabIsClicked());
        _logger.Info($": Successfully Verfied that Shop at Home tab is clicked on homepage");
        
        HomePage_.Signout();
        _logger.Info($": Successfully CLicked on Signout button n homepage");
    }

    [TearDown]
    public void teardown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.Message);
        Status logstatus;
        var errorMessage = TestContext.CurrentContext.Result.Message;
        switch (status)
        {
            case TestStatus.Failed:
                ScreenshotUtil_.SaveScreenShot($"Failed Test{this.GetType().Name}");
                driver.Navigate().Refresh();
                Thread.Sleep(5000);
                logstatus = Status.Fail;
                GlobalSetup.test.Log(Status.Info, stacktrace + errorMessage);
                break;
            case TestStatus.Inconclusive:
                logstatus = Status.Warning;
                break;
            case TestStatus.Skipped:
                logstatus = Status.Skip;
                break;

            default:

                logstatus = Status.Pass;
                break;
        }
        GlobalSetup.test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

    }


}



