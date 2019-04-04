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
            SheetData sheetData1 = ExcelDataAccess.GetTestData("LoginScreen$", "AccountUserValidCredentails");
            LoginPage_.EnterUserName(sheetData1.Username).EnterPassword(sheetData1.Password).ClickLoginButton();
        }


        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A4_VerifyCustomerCreation()
        {
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");

            string firstNameUnique = sheetData.FistNameUnique();
            string lastNameUnique = sheetData.LastNameUnique();
            string PhoneNumber1 = sheetData.PhoneNumber1Unique();
            string EmailAddress1 = sheetData.EmailAddress1Unique();

            string addressline1_2Unique = sheetData.addressline1_2Unique();

            
            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique)
                .EnterPhone(PhoneNumber1, 0).SelectPhoneType(sheetData.PhoneType1, 0).AddPhone().EnterPhone(sheetData.PhoneNumber2Unique(), 1).SelectPhoneType(sheetData.PhoneType2, 1)
                .AddEmailAddress(EmailAddress1, 0).AddEmailAddress(sheetData.EmailAddress2Unique(), 1)
                .ClickOnAddressLine1().ContinueNewCustomerCreation();

            _logger.Info($": Successfully Entered First Name {sheetData.FistNameUnique()}, Last Name {sheetData.LastNameUnique()} , Phone Number {sheetData.PhoneNumber1} , Phone Type {sheetData.PhoneType1} and email adress {sheetData.EmailAddressUnique()} then Clicked on AddressLine1 text box then on ContinueNewCustomerCreation button-IF available");

            EnterNewCustomerPage_.EnterAddressLine1(sheetData.AddressLine1).EnterCity(sheetData.City).SelectState(sheetData.State).enterZip(sheetData.ZipCode)
                                .ClickOnAddAddressPlusButton().EnterAddressLine1(addressline1_2Unique).EnterCity(sheetData.City).SelectState(sheetData.State).enterZip(sheetData.ZipCode);

            _logger.Info($": Successfully Entered Customer 2 address : AddressLine1 {sheetData.AddressLine1},EnterCity {sheetData.City} ,SelectState {sheetData.State} , enterZip {sheetData.ZipCode}  AND  AddressLine1 {addressline1_2Unique},EnterCity {sheetData.City} ,SelectState {sheetData.State} , enterZip {sheetData.ZipCode}");


            EnterNewCustomerPage_.ClickTaxExemptionCheckBox().EnterTaxIDNumber(sheetData.TaxIdNumber1, 1).SelectTaxState(sheetData.TaxState1, 1).ClickDoesntExpireCheckBox(1).AddTax().EnterTaxIDNumber(sheetData.TaxIdNumber2, 2).SelectTaxState(sheetData.TaxState2, 2).ClickDoesntExpireCheckBox(2)
                                .ClickSaveButton().ClickOnUserAddressAsEnteredButtonOnSmartyStreet().ContinueNewCustomerCreation();
            _logger.Info($":Successfully Selected TaxExemption checkbox],EnterTaxIDNumber {sheetData.TaxIdNumber1} ,SelectTaxState {sheetData.TaxState1} and ClickDoesntExpireCheckBox then Clicked on saved button,selected correct address from smarty street and clicked on contiue new customer button");

            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
            _logger.Info($":Green Banner Displayed Successfully.");

            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
            _logger.Info($":Verified that New customer {sheetData.FistNameUnique()} and {sheetData.LastNameUnique()}  is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
            _logger.Info($":Verified that Edit button is present on the screeen");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            _logger.Info($":Verified that New customer having first name {firstNameUnique} is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            _logger.Info($":Verified that New customer having last name {lastNameUnique} is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifyPhoneNumber(PhoneNumber1));
            _logger.Info("Phone Number Is Same As Entered.");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidBillingAddress(sheetData.AddressLine1, sheetData.City, sheetData.State, sheetData.ZipCode));
            _logger.Info($":Verified that New customer having last name {lastNameUnique} is created successfully");

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
