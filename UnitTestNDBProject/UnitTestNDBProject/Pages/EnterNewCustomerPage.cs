using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Pages
{
    public class EnterNewCustomerPage
    {
        public IWebDriver driver;

        public EnterNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();


        [FindsBy(How = How.ClassName, Using = "customer-section")]
        public IWebElement enterNewCustomer { get; set; }


        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement lastname { get; set; }

        [FindsBy(How = How.Name, Using = "phoneLists[0].Phone")]
        public IWebElement phonenumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"react-select-4--value\"]/div[1]")]
        public IWebElement phoneTypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='phoneLists[0].phoneType']")]
        public IWebElement phoneTypeDropDown2 { get; set; }

        
        [FindsBy(How = How.Name, Using = "Select is-clearable is-searchable Select--single")]
        public IWebElement phonetype { get; set; }

        [FindsBy(How = How.Id, Using = "idAddPhone")]
        public IWebElement addPhone { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveUpper")]
        public IWebElement saveButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnContinue")]
        public IWebElement continueWithNewCustomer { get; set; }

        [FindsBy(How = How.Id, Using = "contactEdit")]
        public IWebElement EditButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='customerHeaderWithDoc']/div/div/div[2]/div/div[2]/div/h5")]
        public IWebElement OpenActivityText { get; set; }


        public EnterNewCustomerPage ClickEnterNewCustomerButton()
        {
            
            driver.WaitForElementToBecomeVisibleWithinTimeout(enterNewCustomer, 10000);
            enterNewCustomer.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Functions to Enter First Name
        /// </summary>
        /// <param name="fname"></param>
        /// <returns></returns>

        public EnterNewCustomerPage EnterFirstName(string fname)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(firstName, 10000);
            firstName.SendKeys(fname);
            return this;
        }
        /// <summary>
        /// Functions to Enter Last Name
        /// </summary>
        /// <param name="lname"></param>
        /// <returns></returns>

        public EnterNewCustomerPage EnterLastName(string lname)
        {
            lastname.SendKeys(lname);
            return this;
        }
        /// <summary>
        /// Functions to Enter Phone Number
        /// </summary>
        /// <returns></returns>

        public EnterNewCustomerPage EnterPhoneNumber(string phone)
        {
            phonenumber.SendKeys(phone);
            return this;
        }

        /// <summary>
        /// Functions to Enter Phone Type
        /// </summary>
        /// <param name="phonetype"></param>
        /// <returns></returns>

        public EnterNewCustomerPage SelectPhoneType(string phonetype)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(this.phoneTypeDropDown, phonetype).Build().Perform();
            phoneTypeDropDown2.SendKeys(Keys.Enter);
            return this;
        }

        /// <summary>
        /// Functions to Add Phone
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage AddPhoneNumber()
        {
            addPhone.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Functions to Enter Email Address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
            return this;
        }

        /// <summary>
        /// Functions to Save Customer
        /// </summary>
        /// <returns></returns>
        /// 

        public EnterNewCustomerPage ClickSaveButton()
        {

            saveButton.Clickme(driver);
            return this;

        }
        /// <summary>
        /// Functions to continue with new customer
        /// </summary>
        /// <returns></returns>

        public EnterNewCustomerPage ContinueNewCustomerCreation()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(continueWithNewCustomer, 10000);
            continueWithNewCustomer.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Verify Customer Creation is scuccessful.
        /// </summary>
        /// <param name="ValidMessage"></param>
        /// <returns></returns>

        public bool VerifyCustomerCreation(String ValidMessage)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(OpenActivityText, 5000);
            bool noActivityVerification = false;
            String ActualValue = OpenActivityText.GetText(driver);
            if (ActualValue.Contains(ValidMessage))
            {
                noActivityVerification = true;
                _logger.Info($" Customer Created Successfully");
            }
            return noActivityVerification;
        }
        /// <summary>
        /// Verify Customer Page is read only.
        /// </summary>
        /// <returns></returns>
        public bool VerifyEditButtonAvailable()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButton, 5000);
            bool editButtonAvailibility = false;
            if (EditButton.Enabled)
            {
                editButtonAvailibility = true;
                _logger.Info($" Edit Button is Available");
            }

            return editButtonAvailibility;
            
        }

    }
   

}
