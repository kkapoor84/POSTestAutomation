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
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();


        [OneTimeSetUp]
        public void BeforeClass()
        {
            SheetData sheetData1 = ExcelDataAccess.GetTestData("LoginScreen$", "AccountUserValidCredentails");
            LoginPage_.EnterUserName(sheetData1.Username).EnterPassword(sheetData1.Password).ClickLoginButton();
        }

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
          
        }


        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A3_VerifyCustomerCreation()
        {
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");

            PreservedCustomerInformation_.firstName = sheetData.FistNameUnique();
            PreservedCustomerInformation_.lastName = sheetData.LastNameUnique();

            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(PreservedCustomerInformation_.firstName).EnterLastName(PreservedCustomerInformation_.lastName).EnterPhoneNumber(sheetData.phoneNumber1).SelectPhoneType(sheetData.phoneType1).AddEmailAddress(sheetData.EmailAddressUnique());
            _logger.Info($": Successfully Entered First Name {sheetData.FistNameUnique()}, Last Name {sheetData.LastNameUnique()} , Phone Number {sheetData.phoneNumber1} , Phone Type {sheetData.phoneType1} and email adress {sheetData.EmailAddressUnique()}");

            EnterNewCustomerPage_.ClickOnAddressLine1().ContinueNewCustomerCreation();
            _logger.Info(": Clicked on AddressLine1 text box then on ContinueNewCustomerCreation button");

            EnterNewCustomerPage_.EnterAddressLine1(sheetData.addressline1).EnterCity(sheetData.city).SelectState(sheetData.state).enterZip(sheetData.zipcode);
            _logger.Info($": Customer First Address: Successfully Entered AddressLine1 {sheetData.addressline1},EnterCity {sheetData.city} ,SelectState {sheetData.state} , enterZip {sheetData.zipcode} ");

            SheetData sheetData1 = ExcelDataAccess.GetTestData("UserCreationData$", "customer1address2");

            EnterNewCustomerPage_.ClickOnAddAddressPlusButton().EnterAddressLine1(sheetData1.addressline1).EnterCity(sheetData1.city).SelectState(sheetData1.state).enterZip(sheetData1.zipcode);
            _logger.Info($": Customer Second Address: Successfully Entered AddressLine1 {sheetData.addressline1},EnterCity {sheetData.city} ,SelectState {sheetData.state} , enterZip {sheetData.zipcode}");

            EnterNewCustomerPage_.ClickTaxExemptionCheckBox().EnterTaxIDNumber(sheetData1.taxidnumber).SelectTaxState(sheetData1.taxstate).ClickDoesntExpireCheckBox();
            _logger.Info($":Successfully Selected TaxExemption checkbox],EnterTaxIDNumber {sheetData1.taxidnumber} ,SelectTaxState {sheetData1.taxstate} and ClickDoesntExpireCheckBox");

            EnterNewCustomerPage_.ClickSaveButton().ClickOnCorrectedAddressButtonOnSmartyStreet().ContinueNewCustomerCreation();
            _logger.Info($":Successfully Clicked on saved button,selected correct address from smarty street and clicked on contiue new customer button");

            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
            _logger.Info($":Verified that New customer {sheetData.FistNameUnique()} and {sheetData.LastNameUnique()}  is created successfully");

         
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Customer Page is view Only")]
        public void A4_VerifyCustomerPageTurnViewOnly()
        {
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");
            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidFirstName(PreservedCustomerInformation_.firstName));
            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidLastName(PreservedCustomerInformation_.lastName));

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