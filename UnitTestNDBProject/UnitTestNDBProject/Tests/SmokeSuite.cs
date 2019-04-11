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
    [Order(1)]
    public class SmokeSuite : BaseTestClass
    {        
        private static List<ParsedTestData> fullParsedJsonData;
        private static ParsedTestData loginFeatureParsedData;
        private static ParsedTestData newCustomerFeatureParsedData;
        private static ParsedTestData productLineFeatureParsedData;
        NewCustomerData newCustomerData;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            //Get complete json data
            fullParsedJsonData = DataAccess.GetFullJsonData();

            //Get login screen data
            loginFeatureParsedData = DataAccess.GetFeatureDataFromJson(fullParsedJsonData, "LoginScreen");
            //Get data for customer screen
            newCustomerFeatureParsedData = DataAccess.GetFeatureDataFromJson(fullParsedJsonData, "NewCustomerScreen");
            //Get product line feature data
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");

            newCustomerData = EnterNewCustomerPage.GetCustomerData(newCustomerFeatureParsedData);
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

        [Test, Order(3), Category("Smoke"), Description("Validate all the Home Page tabs are clickable")]
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

            Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
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

            _EnterNewCustomerPage.ClickSaveButton().ClickOnUserAddressAsEnteredButtonOnSmartyStreet().ContinueNewCustomerCreation();

            Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
            Assert.True(_EnterNewCustomerPage.VerifyCustomerCreation("Open Activity"));
            Assert.True(_EnterNewCustomerPage.VerifyEditButtonAvailable());
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifyPhoneNumberAndPhoneType());
            Assert.True(_EnterNewCustomerPage.VerifyAddress());
        }

        [Test, Order(6), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A6_VerifyProductCreation()
        {
            //TODO: Create a new Quote for newly created customer rather than serahcing it. This is just a temporary arrangement
            Thread.Sleep(6000); // This SLEEP is added to ensure that the green notification bar of customer creation has gone
            _QuotePage.SearchFunction().ClickOnAddNewQuote();

            foreach (DataDictionary data in productLineFeatureParsedData.Data)
            {
                ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(data.Value);

                //TODO: Temporary arrangement to ensure ADD PRODUCTS button is visible and clickable. Must be removed later. 
                //TODO: We should ideally check if the button is clickable or not.
                Thread.Sleep(5000);

                _QuotePage.ClickOnAddProduct().EnterWidth(productLine.Width).EnterHeight(productLine.Height).EnterRoomLocation(productLine.NDBRoomLocation)
                    .SelectProduct(productLine.ProductType).SelectMountingDynamic(productLine.ProductDetails).ClickAddProductButton();
            }
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
