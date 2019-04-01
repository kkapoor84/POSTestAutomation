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
        public void A8_VerifyCustomerCreationUsingCustomerSuggestion()
        {
            Random random = new Random();
            SheetData sheetData = ExcelDataAccess.GetTestData("UserCreationData$", "customer1");
            EnterNewCustomerPage_.ClickEnterNewCustomerButton().EnterFirstName(sheetData.FirstName).EnterLastName(sheetData.LastName)
                .EnterPhoneNumber(sheetData.PhoneNumber1 + random.Next(1000000000)).SelectPhoneType(sheetData.PhoneType1).EnterPhoneNumber2(sheetData.PhoneNumber2 + random.Next(1000000000)).SelectPhoneType2(sheetData.PhoneType2)
                .AddEmailAddress(sheetData.EmailAddress1 + random.Next(100) + "@nextdayblinds.com").AddEmailAddress2(sheetData.EmailAddress2 + random.Next(1000) + "@nextdayblinds.com")
                .ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion().ClickEditSaveButton();
            _logger.Info($": Successfully Entered First Name {sheetData.FirstName}, Last Name {sheetData.LastName} , Phone Number {sheetData.PhoneNumber1} and Phone Type {sheetData.PhoneType1}, email_1 { sheetData.EmailAddress1},email_2 { sheetData.EmailAddress1}");
            
            Assert.True(EnterNewCustomerPage_.VerifyEditButtonAvailable());
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Verify Green bar is Displayed.")]
        public void A9_VerifyGreenBarCustomerSuggestion()
        {
            Assert.True(EnterNewCustomerPage_.VerifyGreedbarAfterEditIsSuccessful());
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Verify First Name Of Customer")]
        public void B10_VerifyFirstNameCustomerSuggestion()
        {
            Assert.True(EnterNewCustomerPage_.VerifyFirstName("Shivani"));
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Verify Last Name Of Customer")]
        public void B11_VerifyLastNameCustomerSuggestion()
        {
            Assert.True(EnterNewCustomerPage_.VerifyLastName("Thaman"));
        }

        
    }
}
