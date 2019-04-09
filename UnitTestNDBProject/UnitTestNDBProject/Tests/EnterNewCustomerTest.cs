using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
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
        CommonTest commonTest;

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            commonTest = new CommonTest();

            //Get data for login
            loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
            object accountingLoginData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "AccountUserValidCredentails");
            LoginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
            
            LoginPage_.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            //Get data for customer screen
            newCustomerFeatureParsedData = DataAccess.GetFeatureData("NewCustomerScreen");
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A4_VerifyCustomerCreation()
        {            
            object newCustomerFeatureData = DataAccess.GetKeyJsonData(newCustomerFeatureParsedData, "customer1");
            NewCustomerData newCustomerData = JsonDataParser<NewCustomerData>.ParseData(newCustomerFeatureData);

            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);

            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);

            _logger.Info($": Successfully Entered First Name {firstNameUnique}, Last Name {lastNameUnique}");

            //Input phones
            List<Tuple<string, string>> phones = commonTest.AddCustomerPhones(EnterNewCustomerPage_, newCustomerData.Phones);
            foreach(Tuple<string, string> phone in phones)
            {
                _logger.Info($": Successfully Entered Phone Number {phone.Item1} , Phone Type {phone.Item2}");
            }

            //Input emails
            List<string> emails = commonTest.AddCustomerEmails(EnterNewCustomerPage_, newCustomerData.Emails);
            foreach (string email in emails)
            {
                _logger.Info($": Successfully Entered Email {email}");
            }
                        
            //Click on Address line 1
            EnterNewCustomerPage_.ClickOnAddressLine1().ContinueNewCustomerCreation();
            _logger.Info($": Clicked on AddressLine1 text box then on ContinueNewCustomerCreation button-IF available");

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

            //TODO: Make Smarty Street pop-up dynamic
            //EnterNewCustomerPage_.ClickSaveButton().ClickOnUserAddressAsEnteredButtonOnSmartyStreet().ContinueNewCustomerCreation();
            EnterNewCustomerPage_.ClickSaveButton().ContinueNewCustomerCreation();

            _logger.Info($":Clicked on SAVE button, selected correct address from smarty street and clicked on continue new customer button");

            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
            _logger.Info($":Green Banner Displayed Successfully.");

            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("Open Activity"));
            _logger.Info($":Verified that New customer {firstNameUnique} and {lastNameUnique}  is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
            _logger.Info($":Verified that Edit button is present on the screeen");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            _logger.Info($":Verified that New customer having first name {firstNameUnique} is created successfully");

            Assert.True(EnterNewCustomerPage_.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            _logger.Info($":Verified that New customer having last name {lastNameUnique} is created successfully");
            
            //TODO: Ability to assert multiple PHONES

            //for(int counter = 0; counter < phones.Count; counter++)
            //{
            //    Assert.True(EnterNewCustomerPage_.VerifyPhoneNumber(phones[counter].Item1));
            //    _logger.Info("Phone Number " + (counter + 1) + " Is Same As Entered.");
            //}
           
            Assert.True(EnterNewCustomerPage_.VerifyPhoneNumber(phones[0].Item1));
            _logger.Info("Phone Number " + (1) + " Is Same As Entered.");

            //TODO: How to ASSERT below statement?
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
