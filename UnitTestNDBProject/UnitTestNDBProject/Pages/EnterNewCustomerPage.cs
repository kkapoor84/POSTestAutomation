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
    public class EnterNewCustomerPage
    {
        public IWebDriver driver;

        public EnterNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElement(enterNewCustomer);

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static By enterNewCustomer = By.XPath("//*[@id='root']/div/div[1]/header/div/div/div[2]/div/div"); // EnterNewCustomer Button 
        public static By firstName = By.Id("firstName"); // FirstName
        public static By lastName = By.Name("lastName"); // LastName
        public static By title = By.ClassName("customer-tab active"); // EnterNewCustomer heading
        public static By phoneNumber = By.Id("phoneLists[0].Phone"); // phone Number. 
        public static By phoneType = By.Id("react-select-4--value-item"); // phone Type. 
        public static By saveCustomer = By.Id("btnSaveUpper"); // save customer. 
        public static By existingCustometPopup = By.ClassName("col-sm-12");
        public static By continueNewCustomer = By.Id("btnContinue");
        public static By editButton = By.Id("contactEdit");
        public static By openActivity = By.ClassName("customer-tab open-activity default-activity pointer ");
        private bool isMessagePopulate;

        public void customerInformationCard(string sheetname, string testName)
        {

            var userData = ExcelDataAccess.GetTestData(sheetname, testName);
            // enterNewCustomer.Clickme(driver);

            driver.WaitForElement(firstName);
            firstName.EnterText(driver, userData.firstName);
            _logger.Trace($"Entered First Name is {userData.firstName}");

            lastName.EnterText(driver, userData.lastName);
            _logger.Trace($"Entered Last Name is {userData.lastName}");

            phoneNumber.EnterText(driver, userData.phoneNumber);
            _logger.Trace($"Entered phone number is {userData.phoneNumber}");

            phoneType.EnterText(driver, userData.phoneType);
            _logger.Trace($"Selected phone Type is {userData.phoneType}");
         //   phoneType.SelectDropDown(phoneType, userData.phoneType);

            phoneNumber.Clickme(driver);
            _logger.Trace($"Created customer is {userData.firstName+lastName}");

            //Thread.Sleep(2000);
            driver.WaitForElement(existingCustometPopup);

            continueNewCustomer.Clickme(driver);
            _logger.Trace($"Continued customer creation");



        }

        public bool VerifyCustomerPageTitle()
        {
            driver.WaitForElement(title);
            bool isTitlePresent = false;
            String ActualValue = title.GetText(driver);
            String ExpectedValue = "ENTER NEW CUSTOMER";
            if (ActualValue.Contains(ExpectedValue))
            {
                isTitlePresent = true;
            }
            return isTitlePresent;

        }

        public bool VerifyCustomerCreation()
        {
            driver.WaitForElement(editButton);
  
            String ActualMessage = driver.FindElement(openActivity).Text;
            String ExpectedMessage = "This customer has no open activities.";
            // String ExpectedMessage = "YOUR";
            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }


    }
}
