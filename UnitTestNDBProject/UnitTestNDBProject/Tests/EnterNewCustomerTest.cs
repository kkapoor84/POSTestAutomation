using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class EnterNewCustomerTest : BaseTestClass
    {
        private Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            SheetData sheetData1 = ExcelDataAccess.GetTestData("LoginScreen$", "SAHUserValidCredentails");
            LoginPage_.EnterUserName(sheetData1.Username).EnterPassword(sheetData1.Password).ClickLoginButton();
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A3_VerifyCustomerCreation()
        {
            Random random = new Random();
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");
            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(sheetData.FirstName).EnterLastName(sheetData.LastName).EnterPhoneNumber(sheetData.PhoneNumber1)
                .SelectPhoneType(sheetData.PhoneType1).AddEmailAddress(sheetData.EmailAddress1+random.Next(100)+"@nextdayblinds.com")
                .ClickSaveButton().ContinueNewCustomerCreation();
            _logger.Info($": Successfully Entered First Name {sheetData.FirstName}, Last Name {sheetData.LastName} , Phone Number {sheetData.PhoneNumber1} and Phone Type {sheetData.PhoneType1}, email { sheetData.EmailAddress1}");
            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Customer Page is view Only")]
        public void A4_VerifyCustomerPageTurnViewOnly()
        {
            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
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
