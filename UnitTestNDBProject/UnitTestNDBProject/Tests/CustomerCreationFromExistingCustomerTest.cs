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

namespace UnitTestNDBProject.Pages
{
    [TestFixture]
    class CustomerCreationFromExistingCustomerTest : BaseTestClass
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
        public void A5_VerifyCustomerCreationUsingCustomerSuggestion()
        {

            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");
            // string[] AddedPhones = { PhoneNumber1, PhoneNumber2 };
            string PhoneNumber1 = sheetData.PhoneNumber1Unique();
            string PhoneNumber2 = sheetData.PhoneNumber2Unique();
            string EmailAddress1 = sheetData.EmailAddress1Unique();
            string EmailAddress2 = sheetData.EmailAddress2Unique();
            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(sheetData.FirstName).EnterLastName(sheetData.LastName)
                .EnterPhone(PhoneNumber1, 0).SelectPhoneType(sheetData.PhoneType1, 0).AddPhone().EnterPhone(PhoneNumber2, 1).SelectPhoneType(sheetData.PhoneType2, 1)
                .AddEmailAddress(EmailAddress1, 0).AddEmailAddress(EmailAddress2, 1)
                .ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion();

            _logger.Info($": Successfully Entered First Name {sheetData.FirstName}, Last Name {sheetData.LastName} " +
                $", Phone Number_1 {sheetData.PhoneNumber1} and Phone Type1 {sheetData.PhoneType1}, Phone Number_2 {sheetData.PhoneNumber2} and Phone Type2 {sheetData.PhoneType2}," +
                $" email_1 { sheetData.EmailAddress1},email_2 { sheetData.EmailAddress1}");

            // Assert.True(EnterNewCustomerPage_.VerifyAddedPhones(EnterNewCustomerPage_.getAddedPhones()));

         //   Assert.True(EnterNewCustomerPage_.VerifyAddedPhones(PhonesArray));

            Assert.True(EnterNewCustomerPage_.VerifyExistingPhoneNumber(PhoneNumber1));
            _logger.Info("Phone1 copied successfully");
            Assert.True(EnterNewCustomerPage_.VerifyExistingPhoneNumber(PhoneNumber2));
            _logger.Info("Phone2 copied successfully");
            Assert.True(EnterNewCustomerPage_.VerifyExistingEmailAddress(EmailAddress1));
            _logger.Info("Email Address1 copied successfully");
            
            Assert.True(EnterNewCustomerPage_.VerifyExistingEmailAddress(EmailAddress2));
            _logger.Info("Email Address2 copied successfully");

            EnterNewCustomerPage_.ClickEditSaveButton();

            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
            _logger.Info("Green Banner Displayed Successfully.");
            Assert.True(EnterNewCustomerPage_.VerifyFirstName("Shivani"));
            _logger.Info("First Name Is Same As Selected From Customer Suggestion.");
            Assert.True(EnterNewCustomerPage_.VerifyLastName("Thaman"));
            _logger.Info("Last Name Is Same As Selected From Customer Suggestion.");
        }


        
    }
}
