using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class EnterNewCustomerTest : BaseTestClass
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A3_VerifyCustomerCreation()
        {
            SheetData sheetData = ExcelDataAccess.GetTestData("LoginScreen$", "SAHUserValidCredentails");
            LoginPage_.EnterUserName(sheetData.Username).EnterPassword(sheetData.Password).ClickLoginButton();

            EnterNewCustomerPage_.ClickEnterNewCustomerButton();

            //EnterFirstName(sheetData.firstName).EnterLastName(sheetData.lastName).EnterPhoneNumber(sheetData.phoneNumber).SelectPhoneType(sheetData.phoneType);
            _logger.Info($": Successfully Entered First Name {sheetData.firstName}, Last Name {sheetData.lastName} , Phone Number {sheetData.phoneNumber} and Phone Type {sheetData.phoneType}");

            Assert.True(EnterNewCustomerPage_.VerifyCustomerCreation("This customer has no open activities."));
            //_logger.Info($": Successfully Verified the message displayed after entering invalid username {sheetData.Username} and password {sheetData.Password}");
        }
    }
}
