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

        [FindsBy(How = How.Name, Using = "phoneLists[1].Phone")]
        public IWebElement phonenumber1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"react-select-4--value\"]/div[1]")]
        public IWebElement phoneTypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"react-select-7--value\"]/div[1]")]
        public IWebElement phoneTypeDropDownForPhone2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='phoneLists[0].phoneType']")]
        public IWebElement phoneTypeDropDown2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='phoneLists[1].phoneType']")]
        public IWebElement phoneTypeDropDown2ForPhone2 { get; set; }


        [FindsBy(How = How.Name, Using = "Select is-clearable is-searchable Select--single")]
        public IWebElement phonetype { get; set; }

        [FindsBy(How = How.Id, Using = "idAddPhone")]
        public IWebElement addPhone { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[1].Email")]
        public IWebElement emailAddress1 { get; set; }
        [FindsBy(How = How.Id, Using = "btnAddEmail")]

        public IWebElement addEmail { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveUpper")]
        public IWebElement saveButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnEditSaveUpper")]
        public IWebElement saveButtonEdit { get; set; }

        [FindsBy(How = How.Id, Using = "btnContinue")]
        public IWebElement continueWithNewCustomer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='btnSection']/div/div[1]/div[2]/div/div/div/div/div/div[2]/div/div[1]")]
        public IWebElement continueWithExistingCustomer { get; set; }

        [FindsBy(How = How.Id, Using = "contactEdit")]
        public IWebElement EditButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='customerHeaderWithDoc']/div/div/div[2]/div/div[2]/div/h5")]
        public IWebElement OpenActivityText { get; set; }

        [FindsBy(How = How.Id, Using = "enterNewQuote")]
        public IWebElement EnterNewQuote { get; set; }

        [FindsBy(How = How.ClassName, Using = "msg-container")]
        public IWebElement GreenBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='customerPage']/div/div/form/div[1]/div/div[1]/div/div/div[2]/div/div[2]/div/div/div[2]/span")]
        public IWebElement FirstNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-6 pad-left-none']//span[@class='form-value']")]
        public IWebElement LastNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-4 col-md-4']//span[@class='form-value']")]
        public IWebElement PhoneNumberText { get; set; }

        //*[@id="customerPage"]/div/div/form/div[1]/div/div[1]/div/div/div[2]/div/div[3]/div[1]/div/div[2]/div[1]/div[1]/span


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
        /// Functions to Enter Phone Number 1
        /// </summary>
        /// <returns></returns>

        public EnterNewCustomerPage EnterPhoneNumber(string phone)
        {
            phonenumber.SendKeys(phone);
            return this;
        }

        /// <summary>
        /// Functions to Enter Phone Number 2
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>

        public EnterNewCustomerPage EnterPhoneNumber2(string phone)
        {
            phonenumber1.SendKeys(phone);
            return this;
        }

        /// <summary>
        /// Functions to Enter Phone Type 1
        /// </summary>
        /// <param name="phonetype"></param>
        /// <returns></returns>

        public EnterNewCustomerPage SelectPhoneType(string phonetype)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(this.phoneTypeDropDown, phonetype).Build().Perform();
            phoneTypeDropDown2.SendKeys(Keys.Enter);
            addPhone.Clickme(driver);
            return this;
           
        }

        /// <summary>
        /// Functions to Enter Phone Type 2
        /// </summary>
        /// <param name="phonetype"></param>
        /// <returns></returns>

        public EnterNewCustomerPage SelectPhoneType2(string phonetype)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(phoneTypeDropDownForPhone2, 4000);
            Actions actions = new Actions(driver);
            actions.SendKeys(this.phoneTypeDropDownForPhone2, phonetype).Build().Perform();
            phoneTypeDropDown2ForPhone2.SendKeys(Keys.Enter);
            return this;

        }
       
        /// <summary>
        /// Functions to Enter Email Address 1
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
            addEmail.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Functions to Enter Email Address 2
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public EnterNewCustomerPage AddEmailAddress2(string email)
        {

            emailAddress1.SendKeys(email);
            addEmail.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Functions to Save Customer
        /// </summary>
        /// <returns></returns>
        /// 

        public EnterNewCustomerPage ClickSaveButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(saveButton, 10000);
            //Thread.Sleep(10000);
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
        /// Functions to continue with existing customer
        /// </summary>
        /// <returns></returns>

        public EnterNewCustomerPage UpdateExistingCustomerFromCustomerSuggestion()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(continueWithExistingCustomer, 10000);
            //Thread.Sleep(10000);
            continueWithExistingCustomer.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Functions to select Save button for existing customer
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickEditSaveButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(saveButtonEdit, 10000);
            saveButtonEdit.Clickme(driver);
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
        /// Verify Customer Page is in editable mode.
        /// </summary>
        /// <param name="ValidMessage"></param>
        /// <returns></returns>
        public bool VerifyCustomerUpdation()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EnterNewQuote, 5000);
            bool enterNewQuote = false;
            if (EnterNewQuote.Enabled)
            {
                enterNewQuote = true;
                _logger.Info($" Customer Creation from existing customer is successful.");
            }

            return enterNewQuote;
        }
        /// <summary>
        /// Verify Customer Page is read only.
        /// </summary>
        /// <returns></returns>
        public bool VerifyEditButtonAvailable()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButton, 7000);
            bool editButtonAvailibility = false;
            if (EditButton.Enabled)
            {
                editButtonAvailibility = true;
                _logger.Info($" Edit Button is Available");
            }

            return editButtonAvailibility;
            
        }

        public bool VerifyGreedbarAfterEditIsSuccessful()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(GreenBar, 5000);
            bool editButtonAvailibility = false;
            if (GreenBar.Displayed)
            {
                editButtonAvailibility = true;
                _logger.Info($" Edit Button is Available");
            }

            return editButtonAvailibility;

        }

        public bool VerifyFirstName(String FirstNameOnScreen)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            driver.WaitForElementToBecomeVisibleWithinTimeout(FirstNameText, 10000);
            String FirstName = FirstNameText.GetText(driver);
            bool firstNameValue = false;
            if (FirstNameOnScreen.Contains(FirstName))
            {
                firstNameValue = true;
                _logger.Info($" First Name Is Correct");
            }
            return firstNameValue;

        }

        public bool VerifyLastName(String LastNameOnScreen)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(LastNameText, 10000);
            String LastName = LastNameText.GetText(driver);
            bool lastNameValue = false;
            if (LastNameOnScreen.Contains(LastName))
            {
                lastNameValue = true;
                _logger.Info($" Last Name Is Correct");
            }
            return lastNameValue;

        }

        public bool VerifyPhoneNumber(String PhoneNumberOnScreen)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(LastNameText, 10000);
            String LastName = PhoneNumberText.GetText(driver);
            bool lastNameValue = false;
            if (PhoneNumberOnScreen.Equals(LastName))
            {
                lastNameValue = true;
                _logger.Info($" Phone Is Correct");
            }
            return lastNameValue;

        }

    }
   

}
