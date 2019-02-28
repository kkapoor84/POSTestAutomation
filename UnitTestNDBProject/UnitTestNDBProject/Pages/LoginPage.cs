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

namespace UnitTestNDBProject.Pages
{
    public class LoginPage
    {
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

        public void Login(string sheetname,string testName)
        {
            _logger.Trace("Attempting to login");
            PropertiesCollection.driver.Navigate().Refresh();
            var userData = ExcelDataAccess.GetTestData(sheetname, testName);
            username.EnterText(userData.Username);
            _logger.Info($"username is {userData.Username}");
            pwd.EnterText(userData.Password);
            _logger.Info("password is {0}", userData.Password);
            loginButton.Clickme();
            
            

        }

        public void Signout()
        {
            homeSignoutIcon.Clickme();
            PropertiesCollection.driver.WaitForElement(signoutButton);
            signoutButton.Clickme();
        }

        public bool VerifyHomePageTitle()
        {
            PropertiesCollection.driver.WaitForElement(title);
            bool isTitlePresent = false;
            String ActualValue = title.GetText();
            String ExpectedValue = "Point of Sale Home Page";
            if (ActualValue.Contains(ExpectedValue))
            {
                isTitlePresent = true;
            }
            return isTitlePresent;

        }
        public bool VerifyMessageInvalidCredentials()
        {
            bool isMessagePopulate = false;

            String ActualMessage = PropertiesCollection.driver.FindElement(invalidcredentialmessage).Text;
            String ExpectedMessage = "User ID or Password are incorrect. Please try again or contact the NDB helpdesk";
            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }
    }
}
