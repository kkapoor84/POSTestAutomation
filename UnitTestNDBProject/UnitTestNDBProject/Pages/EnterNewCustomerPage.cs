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
using UnitTestNDBProject.TestDataAccess;
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

        //[FindsBy(How = How.Name, Using = "phoneLists[0].Phone")]
        //public IWebElement phonenumber { get; set; }

        //[FindsBy(How = How.Name, Using = "phoneLists[1].Phone")]
        //public IWebElement phonenumber1 { get; set; }

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

        //[FindsBy(How = How.Id, Using = "idAddPhone")]
        //public IWebElement addPhone { get; set; }

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

        [FindsBy(How = How.XPath, Using = "//*[@id='customerPage']/div/div/form/div[1]/div/div[1]/div/div/div[2]/div/div[3]/div/div/div[2]/div[1]/div[1]")]
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
               
        public EnterNewCustomerPage EnterPhone(string phone, int i)
        {
            string strMyXPath = "phoneLists[" + i + "].Phone";
            driver.FindElement(By.Id(strMyXPath)).SendKeys(phone);
            return this;
                       
        }

        public EnterNewCustomerPage AddPhone()
        {
            driver.FindElement(By.Id("idAddPhone")).Clickme(driver);
            return this;

        }

        public EnterNewCustomerPage SelectPhoneType(string phonetype, int i)
        {

           string strMyXPath = "phoneLists[" + i + "].phoneType";
            Actions actions = new Actions(driver);
            actions.SendKeys(driver.FindElement(By.Id(strMyXPath)), phonetype).Build().Perform();
            driver.FindElement(By.Id(strMyXPath)).SendKeys(Keys.Enter);
            return this;

        } 

        public EnterNewCustomerPage AddEmailAddress(string email, int i)
        {
            String strEmailAddress = "emailList["+ i +"].Email";
            driver.FindElement(By.Id(strEmailAddress)).SendKeys(email);
            addEmail.Clickme(driver);
            return this;
        }

        public void ComparePhone(string s1, string s2)
        {
            if(s1 == s2)
            {
                _logger.Info("Phone numbers are same");
            }
        }


        /// <summary>
        /// Functions to Enter Email Address 1
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

       /* public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
            addEmail.Clickme(driver);
            return this;
        } */

        /// <summary>
        /// Functions to Enter Email Address 2
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        //public EnterNewCustomerPage AddEmailAddress2(string email)
        //{

        //    emailAddress1.SendKeys(email);
        //    addEmail.Clickme(driver);
        //    return this;
        //}

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

        public bool VerifyPhoneNumber(string EnteredPhone)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(PhoneNumberText, 10000);
            string PhoneNumber = PhoneNumberText.GetText(driver);
            string ActualPhoneNumber = String.Concat(PhoneNumber.Substring(1, 3),PhoneNumber.Substring(6, 3),PhoneNumber.Substring(10, 4));
            _logger.Info(ActualPhoneNumber);
            bool PhoneNumberValue = false;
            if (EnteredPhone.Contains(ActualPhoneNumber))
            {
                PhoneNumberValue = true;
                _logger.Info($" Phone Is Correct");
            }
            return PhoneNumberValue;

        }

        public bool VerifyExistingPhoneNumber(string EnteredPhone)
        {
            Thread.Sleep(4000);
            int i = 0;
            string[] tempVar = new string[100];
            do
            {
                string PhoneNumber = driver.FindElement(By.Id("phoneLists[" + i + "].Phone")).GetAttribute("value");
                _logger.Info("I am inside VerificationMethod" + PhoneNumber);
                string ActualPhoneNumber = string.Concat(PhoneNumber.Substring(1, 3), PhoneNumber.Substring(6, 3), PhoneNumber.Substring(10, 4));
                tempVar[i] = ActualPhoneNumber;
                i++;
            } while (By.Id("phoneLists[" + i + "].Phone").isPresent(driver));
            
            int j = 0;
            bool PhoneExist = false;
            do
            {
                if(EnteredPhone.Contains((tempVar[j])))
                    {
                    PhoneExist = true;
                    break;
                }
                j++;
            } while (tempVar[j] != null);

            return PhoneExist;

                    }

    }


}
