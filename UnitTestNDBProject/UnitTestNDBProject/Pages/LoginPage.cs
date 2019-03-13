using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;
using static UnitTestNDBProject.Utils.TestConstant;

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Remote;
using UnitTestNDBProject.TestDataAccess;
using System.Configuration;
using UnitTestNDBProject.Base;

namespace UnitTestNDBProject.Pages
{
    public class LoginPage
    {
       public IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static By username = By.CssSelector("#username");
        public static By pwd = By.CssSelector("#password");
        public static By loginButton = By.XPath("//button[@type='button']");
        public static By invalidcredentialmessage = By.XPath("//span[contains(text(),'User ID or Password are incorrect. Please try agai')]");


        public void Login(string sheetname, string testName)
        {
            _logger.Trace("Attempting to login");
            driver.Navigate().Refresh();
            var userData = ExcelDataAccess.GetTestData(sheetname, testName);
            username.EnterText(driver, userData.Username);
            _logger.Info($" :username is {userData.Username}");
            pwd.EnterText(driver, userData.Password);
            _logger.Info(" :password is {0}", userData.Password);
            loginButton.Clickme(driver);

        }

       
        public bool VerifyMessageInvalidCredentials()
        {
            driver.WaitForElement(invalidcredentialmessage);
            bool isMessagePopulate = false;

            String ActualMessage = driver.FindElement(invalidcredentialmessage).Text;
            String ExpectedMessage = "User ID or Password are incorrect. Please try again or contact the NDB helpdesk";
             if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
                _logger.Info(" :Invalid Credentials");
            }
            return isMessagePopulate;
        }
    }
}
