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
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class EnterNewCustomerTest : BaseTestClass
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
            object accountingLoginData = ExcelDataAccess.GetKeyJsonData(loginFeatureParsedData, "AccountUserValidCredentails");
            LoginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
            
            LoginPage_.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            newCustomerFeatureParsedData = ExcelDataAccess.GetFeatureData("NewCustomerScreen");
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A4_VerifyCustomerCreation()
        {            
            object newCustomerFeatureData = ExcelDataAccess.GetKeyJsonData(newCustomerFeatureParsedData, "customer1");
            NewCustomerData newCustomerData = JsonDataParser<NewCustomerData>.ParseData(newCustomerFeatureData);

            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);

            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);

            _logger.Info($": Successfully Entered First Name {firstNameUnique}, Last Name {lastNameUnique}");

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

            EnterNewCustomerPage_.ClickOnAddressLine1().ContinueNewCustomerCreation();

            //Input addresses
            for (int counter = 0; counter < newCustomerData.Addresses.Count; counter++)
            {
                string addressLine1 = newCustomerData.Addresses[counter].AddressLine1;
                string addressLine2 = newCustomerData.Addresses[counter].AddressLine2;
                string city = newCustomerData.Addresses[counter].City;
                string state = newCustomerData.Addresses[counter].State;
                string zipCode =newCustomerData.Addresses[counter].ZipCode;

                EnterNewCustomerPage_.EnterAddressLine1(addressLine1).EnterAddressLine2(addressLine2).EnterCity(city).SelectState(state).EnterZip(zipCode);

                if (counter < newCustomerData.Addresses.Count - 1)
                {
                    EnterNewCustomerPage_.ClickOnAddAddressPlusButton();
                }

                _logger.Info($": Successfully Entered address : AddressLine1 {addressLine1}, AddressLine2 {addressLine2}, EnterCity {city} ,SelectState {state} , enterZip {zipCode}");
            }

            //Input tax numbers
            if (newCustomerData.TaxNumbers.Count > 0)
            {
                EnterNewCustomerPage_.ClickTaxExemptionCheckBox();

                for (int counter = 0; counter < newCustomerData.TaxNumbers.Count; counter++)
                {
                    string taxId = CommonFunctions.AppendMaxRangeRandomString(newCustomerData.TaxNumbers[counter].TaxIdNumber);
                    string taxState = newCustomerData.TaxNumbers[counter].TaxState;

                    EnterNewCustomerPage_.EnterTaxIDNumber(taxId, counter + 1).SelectTaxState(taxState, counter + 1).ClickDoesntExpireCheckBox(counter + 1);

                    if (counter < newCustomerData.TaxNumbers.Count - 1)
                    {
                        EnterNewCustomerPage_.AddTax();
                    }

                    _logger.Info($": Successfully Selected TaxExemption checkbox, TaxIDNumber: {taxId} , TaxState {taxState} and ClickDoesntExpireCheckBox");
                }
            }

            EnterNewCustomerPage_.ClickSaveButton().ClickOnUserAddressAsEnteredButtonOnSmartyStreet().ContinueNewCustomerCreation();

            _logger.Info($":Clicked on SAVE button, selected correct address from smarty street and clicked on continue new customer button");

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

            //TODO: Write logic to be able to preserve phone numbers/email/addresses/tax etc and verify on Asserts.

            //Assert.True(EnterNewCustomerPage_.VerifyPhoneNumber(PhoneNumber1));
            //_logger.Info("Phone Number Is Same As Entered.");

            //Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidBillingAddress(sheetData.AddressLine1, sheetData.City, sheetData.State, sheetData.ZipCode));
            //_logger.Info($":Verified that New customer having last name {lastNameUnique} is created successfully");
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
