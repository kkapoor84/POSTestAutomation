using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    [Parallelizable]
    class SearchTest : BaseTestClass
    {

        public SearchTest() : base(BrowserType.Firefox)
        {
        }

        [Order(1), Category("Regression")]
        public void VerifyLogin()
        {
            //   PropertiesCollection.driver.Navigate().GoToUrl("https://www.google.com");
            try
            {
                GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginInValidCredentials");
                LP.Login("LoginScreen$", "InValid");

                Assert.True(LP.VerifyMessageInvalidCredentials(), "These credentials are correct");
            }
            catch (NoSuchElementException e)
            {
                GlobalSetup.test.Fail(e.StackTrace);
            }

        }
    }
}
