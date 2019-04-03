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
        [Order(1)]
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
        public void C1_VerifyCustomerCreation()
        {
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");

            string firstNameUnique = sheetData.FistNameUnique();
            string lastNameUnique = sheetData.LastNameUnique();
 
            string addressline1_2Unique = sheetData.addressline1_2Unique();

            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique).EnterPhoneNumber(sheetData.PhoneNumber1).SelectPhoneType(sheetData.PhoneType1).AddEmailAddress(sheetData.EmailAddressUnique())
                                 .ClickOnAddressLine1().ContinueNewCustomerCreation();

            _logger.Info($": Successfully Entered First Name {sheetData.FistNameUnique()}, Last Name {sheetData.LastNameUnique()} , Phone Number {sheetData.PhoneNumber1} , Phone Type {sheetData.PhoneType1} and email adress {sheetData.EmailAddressUnique()} then Clicked on AddressLine1 text box then on ContinueNewCustomerCreation button-IF available");

            EnterNewCustomerPage_.EnterAddressLine1(sheetData.AddressLine1).EnterCity(sheetData.City).SelectState(sheetData.State).enterZip(sheetData.ZipCode)        
                                .ClickOnAddAddressPlusButton().EnterAddressLine1(addressline1_2Unique).EnterCity(sheetData.City).SelectState(sheetData.State).enterZip(sheetData.ZipCode);

            _logger.Info($": Successfully Entered Customer 2 address : AddressLine1 {sheetData.AddressLine1},EnterCity {sheetData.City} ,SelectState {sheetData.State} , enterZip {sheetData.ZipCode}  AND  AddressLine1 {addressline1_2Unique},EnterCity {sheetData.City} ,SelectState {sheetData.State} , enterZip {sheetData.ZipCode}");
          

            EnterNewCustomerPage_.ClickTaxExemptionCheckBox().EnterTaxIDNumber(sheetData.TaxIdNumber).SelectTaxState(sheetData.TaxState).ClickDoesntExpireCheckBox()  
                                .ClickSaveButton().ClickOnUserAddressAsEnteredButtonOnSmartyStreet().ContinueNewCustomerCreation();
            _logger.Info($":Successfully Selected TaxExemption checkbox],EnterTaxIDNumber {sheetData.TaxIdNumber} ,SelectTaxState {sheetData.TaxState} and ClickDoesntExpireCheckBox then Clicked on saved button,selected correct address from smarty street and clicked on contiue new customer button");


            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
            _logger.Info($":Verified that New customer {sheetData.FistNameUnique()} and {sheetData.LastNameUnique()}  is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
            _logger.Info($":Verified that Edit button is present on the screeen");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            _logger.Info($":Verified that New customer having first name {firstNameUnique} is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidFirstName(lastNameUnique));
            _logger.Info($":Verified that New customer having first name {lastNameUnique} is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidBillingAddress(sheetData.AddressLine1,sheetData.City,sheetData.State,sheetData.ZipCode));
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