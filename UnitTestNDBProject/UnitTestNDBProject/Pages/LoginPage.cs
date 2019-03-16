using NLog;
using OpenQA.Selenium;
using System;
using UnitTestNDBProject.Utils;
using UnitTestNDBProject.TestDataAccess;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;
using UnitTestNDBProject.Base;

namespace UnitTestNDBProject.Pages
{
    public class LoginPage 
    {
        public IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [FindsBy(How = How.Id, Using = "username")]
         public IWebElement username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement pwd { get; set; }


        [FindsBy(How = How.ClassName, Using = "btn-outline")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'User ID or Password are incorrect. Please try again')]")]
        public IWebElement invalidcredentialmessage { get; set; }


        public LoginPage EnterUserName(string uname)
        {
            driver.Navigate().Refresh();
            username.SendKeys(uname);

            return this;

        }

        public LoginPage EnterPassword(string password)
        {
            pwd.SendKeys(password);
            return this;

        }
        
        public LoginPage ClickLoginButton()
        {
            loginButton.Clickme(driver);
            return this;
        }

        public bool VerifyInvalidCredentialsAreDisplayed(string InvalidMesage)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(invalidcredentialmessage,5000);
            bool isMessagePopulate = false;

            String ActualMessage = invalidcredentialmessage.Text;
            String ExpectedMessage = InvalidMesage;

            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }

    }
}
