using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Tests
{
    //[TestFixture]
    //[Order(2)]
    //class HomePageTest : BaseTestClass
    //{
    //    private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    //    private static ParsedTestData loginFeatureParsedData;

    //    [OneTimeSetUp]
    //    public void BeforeClass()
    //    {
    //        //Get data for login
    //        loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
    //        object accountingLoginData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "AccountUserValidCredentails");
    //        LoginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
                        
    //        _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();
    //        _logger.Info($": Successfully Entered valid username {loginData.Username}and password {loginData.Password} and clicked on login button");

    //        Assert.True(_HomePage.VerifyHomePageTitle("Point of Sale Home Page"));
    //    }

    //    [SetUp]
    //    public void Setup()
    //    {
    //        GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
    //    }

    //    [Test, Category("Regression"),Category("Smoke"), Description("Validate all the Home Page tabs are clickable")]
    //    public void A3_VerifyHomePageTabs()
    //    {
    //        _HomePage.ClickDashBoardTab();
    //        _logger.Info($": Successfully CLicked on Dashboard Tab on homepage");

    //        Assert.True(_HomePage.VerifyDashBoardTabIsClicked());
    //        _logger.Info($": Successfully Verfied that Dashboard tab is clicked on homepage");

    //        _HomePage.ClickDepositSummaryTab();
    //        _logger.Info($": Successfully CLicked on Deposit Summary Tab on homepage");

    //        Assert.True(_HomePage.VerifyDepositSummaryTabIsClicked());
    //        _logger.Info($": Successfully Verfied that Deposit Summary tab is clicked on homepage");

    //        _HomePage.ClickResourcesTab();
    //        _logger.Info($": Successfully CLicked on Resources Tab on homepage");

    //        Assert.True(_HomePage.VerifyResourceTabIsClicked());
    //        _logger.Info($": Successfully Verfied that Resources tab is clicked on homepage");


    //        _HomePage.ClickSettingTab();
    //        _logger.Info($": Successfully CLicked on Setting Tab on homepage");

    //        Assert.True(_HomePage.VerifySettingTabIsClicked());
    //        _logger.Info($": Successfully Verfied that Setting tab is clicked on homepage");

    //    }

    //    [TearDown]
    //    public void teardown()
    //    {
    //        var status = TestContext.CurrentContext.Result.Outcome.Status;
    //        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
    //                ? ""
    //                : string.Format("{0}", TestContext.CurrentContext.Result.Message);
    //        Status logstatus;
    //        var errorMessage = TestContext.CurrentContext.Result.Message;
    //        switch (status)
    //        {
    //            case TestStatus.Failed:
    //                _ScreenshotUtil.SaveScreenShot($"Failed Test{this.GetType().Name}");
    //                driver.Navigate().Refresh();
    //                Thread.Sleep(5000);
    //                logstatus = Status.Fail;
    //                GlobalSetup.test.Log(Status.Info, stacktrace + errorMessage);
    //                break;
    //            case TestStatus.Inconclusive:
    //                logstatus = Status.Warning;
    //                break;
    //            case TestStatus.Skipped:
    //                logstatus = Status.Skip;
    //                break;

    //            default:

    //                logstatus = Status.Pass;
    //                break;
    //        }
    //        GlobalSetup.test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

    //    }


    //    [OneTimeTearDown]
    //    public void AfterClass()
    //    {

    //        _HomePage.Signout();
    //        _logger.Info($": Successfully CLicked on Signout button n homepage");

    //    }
    //}
}
