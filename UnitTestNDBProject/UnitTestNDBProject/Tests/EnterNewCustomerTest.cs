using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    class EnterNewCustomerTest : BaseTestClass
    {
        ILog log = LogManager.GetLogger(typeof(EnterNewCustomerTest));
        public EnterNewCustomerTest() : base(BrowserType.Chrome)
        {
        }

        public static By enterNewCustomer = By.ClassName("customer-section");


        [OneTimeSetUp]
        public void BeforeClass()
        {
            LP.Login("LoginScreen$", "Valid");
            
            driver.WaitForElement(enterNewCustomer);
            enterNewCustomer.Clickme(driver);
        }
        //[Test, Order(1), Category("Regression")]
        //public void verifyCustomerCreationPageIsEnable()
        //{
        //    try
        //    {
        //       // LoginTest test = new LoginTest(driver);
        //        GlobalSetup.test = GlobalSetup.extent.CreateTest("EnterNewCustomerPageEnable");
        //        //newCustomer.customerInformationCard("UserCreationData$", "customer1");
        //        //LP.Login("LoginScreen$", "InValid");
        //        //Assert.True(LP.VerifyMessageInvalidCredentials(), "These credentials are correct");
        //        //Assert.True(newCustomer.VerifyCustomerPageTitle(), "We are on customer creation page.");
        //        newCustomer.VerifyCustomerPageTitle();

        //    }
        //    catch (Exception e)
        //    {
        //        GlobalSetup.test.Fail(e.StackTrace);
        //    }
        //}

        [Test, Order(1), Category("Regression")]
        public void verifyCustomerCreation()
        {
            try
            {
                GlobalSetup.test = GlobalSetup.extent.CreateTest("CustomerCreationSuccessful");
                newCustomer.customerInformationCard("UserCreationData$", "customer1");
                Assert.True(newCustomer.VerifyCustomerCreation(),"CustomerCreatedSuccessfully");

            }
            catch (Exception e)
            {
                GlobalSetup.test.Fail(e.StackTrace);
            }
        }
    }
}
