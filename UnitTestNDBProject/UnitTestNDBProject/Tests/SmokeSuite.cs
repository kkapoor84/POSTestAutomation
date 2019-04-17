using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    
    public class SmokeSuite : BaseTestClass
    {        
       
        private static ParsedTestData loginFeatureParsedData;
        private static ParsedTestData newCustomerFeatureParsedData;
        private static ParsedTestData productLineFeatureParsedData;
        private static ParsedTestData updateCustomerFeatureParsedData;
        private static ParsedTestData internalInfoParsedData;
        NewCustomerData newCustomerData;
        InternalInfoData internalInforData;


        [OneTimeSetUp]
        public void BeforeClass()
        {
            //Get login screen data
            loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
            //Get data for customer screen
            newCustomerFeatureParsedData = DataAccess.GetFeatureData("NewCustomerScreen");
            //Get data for update customer screen
            updateCustomerFeatureParsedData = DataAccess.GetFeatureData("UpdateCustomerScreen");
            //Get product line feature data
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            //Get data for Internal Infor Section
            internalInfoParsedData = DataAccess.GetFeatureData("InternalInfoScreen");

            //parse data of NewCustomerScreen feature in NewCustomerData class
            newCustomerData = EnterNewCustomerPage.GetCustomerData(newCustomerFeatureParsedData);
            internalInforData = QuotePage.GetInternalInfoData(internalInfoParsedData);

        }

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(1), Category("Smoke"), Description("Validate that error message populates once user enter invalid credentials")]
        public void A1_VerifyLoginWithInValidCredentails()
        {
            LoginData loginData = LoginPage.GetInvalidLoginData(loginFeatureParsedData);

            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            Assert.True(_LoginPage.VerifyInvalidCredentialsAreDisplayed("User ID or Password are incorrect. Please try again or contact the NDB helpdesk"));
        }

        [Test, Order(2), Category("Smoke"), Description("Validate that user is able to navigate to Home page using valid credentials")]
        public void A2_VerifyLoginWithValidCrdentails()
        {
            LoginData loginData = LoginPage.GetSAHUserLoginData(loginFeatureParsedData);

            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();
            _HomePage.ClickShopAtHomeTab();

            Assert.True(_HomePage.VerifyShopAtHomeTabIsClicked());
        }

        [Test, Order(3), Category("Smoke"),  Description("Validate all the Home Page tabs are clickable")]
        public void A3_VerifyHomePageTabs()
        {
            _HomePage.ClickDashBoardTab();
            Assert.True(_HomePage.VerifyDashBoardTabIsClicked());

            _HomePage.ClickDepositSummaryTab();
            Assert.True(_HomePage.VerifyDepositSummaryTabIsClicked());

            _HomePage.ClickResourcesTab();
            Assert.True(_HomePage.VerifyResourceTabIsClicked());

            _HomePage.ClickSettingTab();
            Assert.True(_HomePage.VerifySettingTabIsClicked());
        }

        [Test, Order(4), Category("Smoke"), Description("Enter Customer Card Details and create new customer from customer suggestion")]
        public void A4_VerifyCustomerCreationUsingCustomerSuggestion()
        {
            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName);

            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            //Click on SAVE button and update existing customer
            _EnterNewCustomerPage.ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion();

            for (int counter = 0; counter < phones.Count; counter++)
            {
                Assert.True(_EnterNewCustomerPage.VerifyExistingPhoneNumber(phones[counter].Item1));
            }

            for (int counter = 0; counter < emails.Count; counter++)
            {
                Assert.True(_EnterNewCustomerPage.VerifyExistingEmailAddress(emails[counter]));
            }

            _EnterNewCustomerPage.ClickEditSaveButton();

            // Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
            Assert.True(_EnterNewCustomerPage.VerifyFirstName(newCustomerData.FirstName));
            Assert.True(_EnterNewCustomerPage.VerifyLastName(newCustomerData.LastName));
        }

        [Test, Order(5), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A5_VerifyCustomerCreation()
        {
            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);


            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            _EnterNewCustomerPage.ClickOnAddressLine1().ContinueNewCustomerCreation();

            _EnterNewCustomerPage.AddCustomerAddresses(newCustomerData.Addresses);
            _EnterNewCustomerPage.AddCustomerTaxNumbers(newCustomerData.TaxNumbers);

            _EnterNewCustomerPage.ClickSaveButton().ContinueNewCustomerCreation();

            Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
            Assert.True(_EnterNewCustomerPage.VerifyCustomerCreation("Open Activity"));
            Assert.True(_EnterNewCustomerPage.VerifyEditButtonAvailable());
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifyPhoneNumberAndPhoneType());
            Assert.True(_EnterNewCustomerPage.VerifyEmailAddress());
            Assert.True(_EnterNewCustomerPage.VerifyAddressine2());
            Assert.True(_EnterNewCustomerPage.VerifyAddress());
            Assert.True(_EnterNewCustomerPage.VerifyTaxidNumberAndState());
        }


        [Test, Order(6), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A6_VerifyCustomerUpdate()
        {
            UpdateCustomerData updateCustomerData = EnterNewCustomerPage.GetUpdateCustomerData(updateCustomerFeatureParsedData);

            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(updateCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(updateCustomerData.LastName);

            //Updating Information of Customer Information Section
            _EnterNewCustomerPage.ClickEditButton("contactEdit");
            _EnterNewCustomerPage.EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(updateCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(updateCustomerData.Emails);
            _EnterNewCustomerPage.ClickEditSaveButton();

            //Updating Information of Address Section
            _EnterNewCustomerPage.ClickEditButton("addressEdit");
            _EnterNewCustomerPage.AddCustomerAddresses(updateCustomerData.Addresses);
            _EnterNewCustomerPage.ClickEditSaveButton();

            //Updating Information of Tax Section
            _EnterNewCustomerPage.ClickEditButton("exemptionEdit");
            _EnterNewCustomerPage.AddCustomerTaxNumbers(updateCustomerData.TaxNumbers);
            _EnterNewCustomerPage.ClickEditSaveButton();

            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifyPhoneNumberAndPhoneType());
            Assert.True(_EnterNewCustomerPage.VerifyEmailAddress());
            Assert.True(_EnterNewCustomerPage.VerifyAddressine2());
            Assert.True(_EnterNewCustomerPage.VerifyAddress());
            Assert.True(_EnterNewCustomerPage.VerifyTaxidNumberAndState());
        }


        [Test, Order(7), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A7_VerifyProductCreation()
        {
            _QuotePage.ClickOnAddNewQuote().SaveQuoteButton();

            Assert.True(_QuotePage.VerifyErrorPopup());

            _QuotePage.OkOnErrorMessage().UpdateNickname(internalInforData.Nickname).UpdateInternalInfo().UpdateSidemark(internalInforData.Sidemark)
                .ApplyInternalInfoUpdates().AddMultipleProducts(productLineFeatureParsedData.Data);

            Assert.True(_QuotePage.VerifyQuoteCreation());

            Assert.True(_QuotePage.VerifyTotalProducts());
        }

        /// <summary>
        /// Tear Down function
        /// </summary>
        [TearDown]
        public void Teardown()
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
                    _ScreenshotUtil.SaveScreenShot($"Failed Test{this.GetType().Name}");
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

        /// <summary>
        /// One tiem Tear Down function
        /// </summary>
        [OneTimeTearDown]
        public void AfterClass()
        {
            //This is just to ensure that there isn't any loader blocking the button.
            //TODO: Any better way to handle it?
            Thread.Sleep(5000);
            _HomePage.Signout();
        }
    }
}
