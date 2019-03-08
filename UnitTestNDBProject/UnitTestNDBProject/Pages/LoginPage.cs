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
        //test
        public IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static By username = By.CssSelector("#username");
        public static By pwd = By.CssSelector("#password");
        public static By loginButton = By.XPath("//button[@type='button']");
        public static By title = By.XPath("//h1[contains(text(),'Point of Sale Home Page')]");
        public static By invalidcredentialmessage = By.XPath("//span[contains(text(),'User ID or Password are incorrect. Please try agai')]");
        public static By homeSignoutIcon = By.XPath("//i[@class='icon-account']");
        public static By signoutButton = By.XPath("//a[contains(text(),'Log Out')]");



        //public void Login(String Usern, String pwdn)
        //{
        //    _logger.Trace("Attempting to login");
        //    PropertiesCollection.driver.Navigate().Refresh();
        //    username.EnterText(Usern);
        //    _logger.Info($"username is {Usern}");
        //    pwd.EnterText(pwdn);
        //    _logger.Info("password is {0}", pwdn);
        //    loginButton.Clickme();


        //}

//branch kk
        public void Login(string sheetname, string testName)
        {
            _logger.Trace("Attempting to login");
            driver.Navigate().Refresh();
            var userData = ExcelDataAccess.GetTestData(sheetname, testName);
            username.EnterText(driver, userData.Username);
            _logger.Info($"username is {userData.Username}");
            pwd.EnterText(driver, userData.Password);
            _logger.Info("password is {0}", userData.Password);
            loginButton.Clickme(driver);




        }

        public void Signout()
        {
            homeSignoutIcon.Clickme(driver);
            driver.WaitForElement(signoutButton);
            signoutButton.Clickme(driver);
        }

        public bool VerifyHomePageTitle()
        {
            driver.WaitForElement(title);
            bool isTitlePresent = false;
            String ActualValue = title.GetText(driver);
            String ExpectedValue = "Point of Sale Home Page";
            if (ActualValue.Contains(ExpectedValue))
            {
                isTitlePresent = true;
            }
            return isTitlePresent;

        }
        public bool VerifyMessageInvalidCredentials()
        {
            driver.WaitForElement(invalidcredentialmessage);
            bool isMessagePopulate = false;

            String ActualMessage = driver.FindElement(invalidcredentialmessage).Text;
            String ExpectedMessage = "User ID or Password are incorrect. Please try again or contact the NDB helpdesk";
            // String ExpectedMessage = "YOUR";
            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }
    }
}
