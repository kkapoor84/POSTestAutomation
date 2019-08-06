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
            username.EnterText(uname);
            _logger.Info($": Successfully entered username {uname}");
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            pwd.EnterText(password);
            _logger.Info($": Successfully entered password {password}");
            return this;
        }
        
        public LoginPage ClickLoginButton()
        {
            loginButton.Clickme(driver);
            _logger.Info($": Login button clicked");
            new System.Threading.ManualResetEvent(false).WaitOne(4000);
            return this;
        }

        public bool VerifyInvalidCredentialsAreDisplayed(string InvalidMesage)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(invalidcredentialmessage,5000);
            bool isMessagePopulate = false;

            string ActualMessage = invalidcredentialmessage.Text;
            string ExpectedMessage = InvalidMesage;

            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }

        public static LoginData GetLoginDataByKey(ParsedTestData loginFeatureParsedData, string key)
        {
            object loginDataByKey = DataAccess.GetKeyJsonData(loginFeatureParsedData, key);
            return JsonDataParser<LoginData>.ParseData(loginDataByKey);
        }

        public static LoginData GetInvalidLoginData(ParsedTestData loginFeatureParsedData)
        {
            return GetLoginDataByKey(loginFeatureParsedData, "InValidCredentials");
        }

        public static LoginData GetSAHUserLoginData(ParsedTestData loginFeatureParsedData)
        {
            return GetLoginDataByKey(loginFeatureParsedData, "SAHUserValidCredentails");
        }
        public static LoginData GetAccounttantUserLoginData(ParsedTestData loginFeatureParsedData)
        {
            return GetLoginDataByKey(loginFeatureParsedData, "AccountUserValidCredentails");
        }

    }
}
