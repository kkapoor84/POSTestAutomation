using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestNDBProject.TestDataAccess;
using NUnit.Framework.Interfaces;
using UnitTestNDBProject.Base;
using NLog;
using System.Threading;
using AventStack.ExtentReports;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    //[TestFixture]
    //class CustomerCreationFromExistingCustomerTest : BaseTestClass
    //{
    //    private Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    //    private static ParsedTestData loginFeatureParsedData;
    //    private static ParsedTestData newCustomerFeatureParsedData;
    //    CommonTest commonTest;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
    //    }

    //    [OneTimeSetUp]
    //    public void BeforeClass()
    //    {
    //        commonTest = new CommonTest();

    //        //Get data for login
    //        loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
    //        object sahLoginData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "SAHUserValidCredentails");
    //        LoginData loginData = JsonDataParser<LoginData>.ParseData(sahLoginData);

    //        _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

    //        //Get data for customer
    //        newCustomerFeatureParsedData = DataAccess.GetFeatureData("NewCustomerScreen");
    //    }

    //    [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
    //    public void A5_VerifyCustomerCreationUsingCustomerSuggestion()
    //    {
    //        object newCustomerFeatureData = DataAccess.GetKeyJsonData(newCustomerFeatureParsedData, "customer1");
    //        NewCustomerData newCustomerData = JsonDataParser<NewCustomerData>.ParseData(newCustomerFeatureData);
            
    //        _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName);

    //        _logger.Info($": Successfully Entered First Name {newCustomerData.FirstName}, Last Name {newCustomerData.LastName}");
                  
    //        //Input phones
    //        List<Tuple<string, string>> phones = commonTest.AddCustomerPhones(_EnterNewCustomerPage, newCustomerData.Phones);
    //        foreach (Tuple<string, string> phone in phones)
    //        {
    //            _logger.Info($": Successfully Entered Phone Number {phone.Item1} , Phone Type {phone.Item2}");
    //        }

    //        //Input emails
    //        List<string> emails = commonTest.AddCustomerEmails(_EnterNewCustomerPage, newCustomerData.Emails);
    //        foreach (string email in emails)
    //        {
    //            _logger.Info($": Successfully Entered Email {email}");
    //        }
            
    //        //Click on SAVE button and update existing customer
    //        _EnterNewCustomerPage.ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion();

    //        for (int counter = 0; counter < phones.Count; counter++)
    //        {
    //            Assert.True(_EnterNewCustomerPage.VerifyExistingPhoneNumber(phones[counter].Item1));
    //            _logger.Info($": Phone " + (counter + 1) + " copied successfully");
    //        }

    //        for (int counter = 0; counter < emails.Count; counter++)
    //        {
    //            Assert.True(_EnterNewCustomerPage.VerifyExistingEmailAddress(emails[counter]));
    //            _logger.Info($": Email " + (counter + 1) + " copied successfully");
    //        }

    //        _EnterNewCustomerPage.ClickEditSaveButton();

    //        Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
    //        _logger.Info($": Green Banner Displayed Successfully.");

    //        Assert.True(_EnterNewCustomerPage.VerifyFirstName(newCustomerData.FirstName));
    //        _logger.Info($": First Name Is Same As Selected From Customer Suggestion.");

    //        Assert.True(_EnterNewCustomerPage.VerifyLastName(newCustomerData.LastName));
    //        _logger.Info($": Last Name Is Same As Selected From Customer Suggestion.");
    //    }

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
    //}
}
