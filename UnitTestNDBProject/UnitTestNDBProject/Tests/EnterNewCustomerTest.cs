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

            string num1 = sheetData.PhoneNumber1Unique();
            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(sheetData.FirstName).EnterLastName(sheetData.LastName)
                .EnterPhone(num1, 0).SelectPhoneType(sheetData.PhoneType1, 0).AddPhone().EnterPhone(sheetData.PhoneNumber2Unique(), 1).SelectPhoneType(sheetData.PhoneType2,1)
                .AddEmailAddress(sheetData.EmailAddress1Unique(),0).AddEmailAddress(sheetData.EmailAddress2Unique(),1)
                .ClickSaveButton().ContinueNewCustomerCreation();
            _logger.Info($": Successfully Entered First Name {sheetData.FirstName}, Last Name {sheetData.LastName} , Phone Number {sheetData.PhoneNumber1} and Phone Type {sheetData.PhoneType1}, email { sheetData.EmailAddress1}");
            //Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
            _logger.Info(num1);
            Assert.True(EnterNewCustomerPage_.VerifyPhoneNumber(num1));
            //EnterNewCustomerPage_.ComparePhone(sheetData.PhoneNumber1Unique(),EnterNewCustomerPage_.PhoneNumberText.)
        }

       

        [Test, Category("Regression"), Category("Smoke"), Description("Verify Green bar is Displayed.")]
        public void A9_VerifyGreenBar()
        {
            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Verify First Name Of Customer")]
        public void B10_VerifyFirstName()
        {
            Assert.True(EnterNewCustomerPage_.VerifyFirstName("Shivani"));
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Verify Last Name Of Customer")]
        public void B11_VerifyLastName()
        {
            Assert.True(EnterNewCustomerPage_.VerifyLastName("Thaman"));
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
