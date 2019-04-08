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
    [TestFixture]
    class CustomerCreationFromExistingCustomerTest : BaseTestClass
    {
        private Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private static ParsedTestData loginFeatureParsedData;
        private static ParsedTestData newCustomerFeatureParsedData;

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            loginFeatureParsedData = ExcelDataAccess.GetFeatureData("LoginScreen");
            object sahLoginData = ExcelDataAccess.GetKeyJsonData(loginFeatureParsedData, "SAHUserValidCredentails");
            LoginData loginData = JsonDataParser<LoginData>.ParseData(sahLoginData);

            LoginPage_.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            newCustomerFeatureParsedData = ExcelDataAccess.GetFeatureData("NewCustomerScreen");
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A5_VerifyCustomerCreationUsingCustomerSuggestion()
        {
            object newCustomerFeatureData = ExcelDataAccess.GetKeyJsonData(newCustomerFeatureParsedData, "customer1");
            NewCustomerData newCustomerData = JsonDataParser<NewCustomerData>.ParseData(newCustomerFeatureData);


            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName);

            _logger.Info($": Successfully Entered First Name {newCustomerData.FirstName}, Last Name {newCustomerData.LastName}");

            //Input phones
            for (int counter = 0; counter < newCustomerData.Phones.Count; counter++)
            {
                string phone = CommonFunctions.AppendMaxRangeRandomString(newCustomerData.Phones[counter].PhoneNumber);
                string phoneType = newCustomerData.Phones[counter].PhoneType;
                EnterNewCustomerPage_.EnterPhone(phone, counter).SelectPhoneType(phoneType, counter);

                if (counter < newCustomerData.Phones.Count - 1)
                {
                    EnterNewCustomerPage_.AddPhone();
                }

                _logger.Info($": Successfully Entered Phone Number {phone} , Phone Type {phoneType}");
            }

            //Input emails
            for (int counter = 0; counter < newCustomerData.Emails.Count; counter++)
            {
                string email = CommonFunctions.RandomizeEmail(newCustomerData.Emails[counter].EmailText);
                EnterNewCustomerPage_.EnterEmailAddress(email, counter);

                if (counter < newCustomerData.Emails.Count - 1)
                {
                    EnterNewCustomerPage_.AddEmailAddress();
                }

                _logger.Info($": Successfully Entered Email {email} then Clicked on AddressLine1 text box then on ContinueNewCustomerCreation button-IF available");
            }

            EnterNewCustomerPage_.ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion();

            //Assert.True(EnterNewCustomerPage_.VerifyExistingPhoneNumber(PhoneNumber1));
            //_logger.Info($": Phone1 copied successfully");

            //Assert.True(EnterNewCustomerPage_.VerifyExistingPhoneNumber(PhoneNumber2));
            //_logger.Info($": Phone2 copied successfully");

            //Assert.True(EnterNewCustomerPage_.VerifyExistingEmailAddress(EmailAddress1));
            //_logger.Info($": Email Address1 copied successfully");

            //Assert.True(EnterNewCustomerPage_.VerifyExistingEmailAddress(EmailAddress2));
            //_logger.Info($": Email Address2 copied successfully");

            EnterNewCustomerPage_.ClickEditSaveButton();

            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
            _logger.Info($": Green Banner Displayed Successfully.");

            Assert.True(EnterNewCustomerPage_.VerifyFirstName("AutomationPOS"));
            _logger.Info($": First Name Is Same As Selected From Customer Suggestion.");

            Assert.True(EnterNewCustomerPage_.VerifyLastName("AutomationPOS"));
            _logger.Info($": Last Name Is Same As Selected From Customer Suggestion.");
        }

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
}
