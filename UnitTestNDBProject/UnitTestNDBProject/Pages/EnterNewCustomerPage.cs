using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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

        private Logger _logger = LogManager.GetCurrentClassLogger();


        [FindsBy(How = How.ClassName, Using = "customer-section")]
        public IWebElement enterNewCustomer { get; set; }


        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-3 pad-left-none']//span[@class='form-value']")]
        public IWebElement ViewOnlyfirstName { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement lastname { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-6 pad-left-none']//span[@class='form-value']")]
        public IWebElement ViewOnlylastname { get; set; }

        [FindsBy(How = How.Name, Using = "phoneLists[0].Phone")]
        public IWebElement phonenumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"react-select-4--value\"]/div[1]")]

        public IWebElement phoneTypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='phoneLists[0].phoneType']")]

        public IWebElement phoneTypeDropDown2 { get; set; }

        [FindsBy(How = How.Name, Using = "Select is-clearable is-searchable Select--single")]
        public IWebElement phonetype { get; set; }

        [FindsBy(How = How.Id, Using = "address-line1")]
        public IWebElement addressLine1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='addressLine1']/following-sibling::span")]
        public IWebElement viewOnlyAddressLine1 { get; set; }


        [FindsBy(How = How.Id, Using = "address-line2")]
        public IWebElement addressLine2 { get; set; }

        [FindsBy(How = How.Id, Using = "address-city")]

        public IWebElement city { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[@for='city']/following-sibling::span")]

        public IWebElement viewOnlyCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='state']")]

        public IWebElement state { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='state']/following-sibling::span")]
        public IWebElement viewOnlyState { get; set; }


        [FindsBy(How = How.Name, Using = "zip")]
        public IWebElement zip { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='col-sm-2']//span[@class='form-value'])[2]")]
        public IWebElement viewOnlyZip { get; set; }

        [FindsBy(How = How.Id, Using = "idAddPhone")]
        public IWebElement addPhone { get; set; }

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


        [FindsBy(How = How.XPath, Using = "//h5[text()='Open Activity']")]
        public IWebElement OpenActivityText { get; set; }

        [FindsBy(How = How.Id, Using = "enterNewQuote")]
        public IWebElement EnterNewQuote { get; set; }

        [FindsBy(How = How.ClassName, Using = "msg-container")]
        public IWebElement GreenBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-3 pad-left-none']//span[@class='form-value']")]
        public IWebElement FirstNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-6 pad-left-none']//span[@class='form-value']")]
        public IWebElement LastNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='row phone-data']//span[@class='form-value'])[1]")]
        public IWebElement PhoneNumberText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add Address')]")]
        public IWebElement AddAddress { get; set; }

        [FindsBy(How = How.Id, Using = "btnUseEnteredAddress")]
        public IWebElement UseAddressAsEntered { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkbox-TaxExempt")]
        public IWebElement TaxCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='exceptions-section']//i[@class='icon-plus-circle']")]
        public IWebElement AddTaxButton { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }

        /// <summary>
        /// Click On Enter New Customer Buton
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterPhoneNumber(string phone)
        {
            phonenumber.SendKeys(phone);
            return this;
        }
        public EnterNewCustomerPage SelectPhoneType(string phonetype)
        {
            Actions actions_ = new Actions(driver);
            actions_.SendKeys(this.phoneTypeDropDown2, phonetype).Build().Perform();
            phoneTypeDropDown2.SendKeys(Keys.Enter);
            return this;
        }
        /// <summary>
        /// Enter Phone Number
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterPhone(string phone, int i)
        {
            Thread.Sleep(1000);
            string strMyXPath = "phoneLists[" + i + "].Phone";
            driver.FindElement(By.Id(strMyXPath)).SendKeys(phone);
            return this;

        }
        /// <summary>
        /// Add New Phone
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage AddPhone()
        {
            addPhone.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Select Phone Type
        /// </summary>
        /// <param name="phonetype"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public EnterNewCustomerPage SelectPhoneType(string phonetype, int i)
        {

            string strMyXPath = "phoneLists[" + i + "].phoneType";
            Actions actions = new Actions(driver);
            actions.SendKeys(driver.FindElement(By.Id(strMyXPath)), phonetype).Build().Perform();
            driver.FindElement(By.Id(strMyXPath)).SendKeys(Keys.Enter);
            return this;

        }

        public EnterNewCustomerPage EnterEmailAddress(string email, int i)
        {
            String strEmailAddress = "emailList[" + i + "].Email";
            driver.FindElement(By.Id(strEmailAddress)).SendKeys(email);
            //addEmail.Clickme(driver);
            return this;
        }
        
        public EnterNewCustomerPage AddEmailAddress()
        {
            addEmail.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Click on Save button
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickSaveButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(saveButton, 10000);
            saveButton.Clickme(driver);
            return this;

        }

        /// <summary>
        /// CLick on Address Line1
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickOnAddressLine1()
        {
            Thread.Sleep(2000);
            addressLine1.Clickme(driver);
            return this;
        }
        /// <summary>
        /// Functions to continue with new customer
        /// </summary>
        /// <returns></returns>

        public EnterNewCustomerPage ContinueNewCustomerCreation()
        {
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnContinue")));
                continueWithNewCustomer.Clickme(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                
            }
            return this;
        }

 
        /// <summary>
        /// Functions to continue with existing customer
        /// </summary>
        /// <returns></returns>
        /// 
        public EnterNewCustomerPage UpdateExistingCustomerFromCustomerSuggestion()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(continueWithExistingCustomer, 10000);
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

        /// <summary>
        /// Verify Green Banner
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Verify First Name is same as entered
        /// </summary>
        /// <param name="FirstNameOnScreen"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verify last name is same as entered
        /// </summary>
        /// <param name="LastNameOnScreen"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Veerify Phone Number is same as entered
        /// </summary>
        /// <param name="EnteredPhone"></param>
        /// <returns></returns>
        public bool VerifyPhoneNumber(string EnteredPhone)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(PhoneNumberText, 10000);
            string PhoneNumber = PhoneNumberText.GetText(driver);
            string ActualPhoneNumber = String.Concat(PhoneNumber.Substring(1, 3), PhoneNumber.Substring(6, 3), PhoneNumber.Substring(10, 4));
            bool PhoneNumberValue = false;
            if (EnteredPhone.Contains(ActualPhoneNumber))
            {
                PhoneNumberValue = true;
                _logger.Info($" Phone Is Correct");
            }
            return PhoneNumberValue;

        }

        /// <summary>
        /// Verify that phone numbers are appended in existing customer.
        /// </summary>
        /// <param name="EnteredPhone"></param>
        /// <returns></returns>
        public bool VerifyExistingPhoneNumber(string EnteredPhone)
        {
            Thread.Sleep(4000);
            int i = 0;
            string[] PhoneNumberArray = new string[100];
            do
            {
                string PhoneNumber = driver.FindElement(By.Id("phoneLists[" + i + "].Phone")).GetAttribute("value");
                string ActualPhoneNumber = string.Concat(PhoneNumber.Substring(1, 3), PhoneNumber.Substring(6, 3), PhoneNumber.Substring(10, 4));
                PhoneNumberArray[i] = ActualPhoneNumber;
                i++;
            } while (By.Id("phoneLists[" + i + "].Phone").isPresent(driver));

            int j = 0;
            bool PhoneExist = false;
            do
            {
                if (EnteredPhone.Contains((PhoneNumberArray[j])))
                {
                    PhoneExist = true;
                    _logger.Info($" Phone For Existing Customer Is Added");
                    break;
                }
                j++;
            } while (PhoneNumberArray[j] != null);

            return PhoneExist;

        }

        /// </summary>
        /// <param name="EnteredEmail"></param>
        /// <returns></returns>
        public bool VerifyExistingEmailAddress(string EnteredEmail)
        {
            Thread.Sleep(4000);
            int i = 0;
            string[] EmailAddressArray = new string[100];
            do
            {
                string EmailAddress = driver.FindElement(By.Id("emailList[" + i + "].Email")).GetAttribute("value");
                EmailAddressArray[i] = EmailAddress;
                i++;
            } while (By.Id("emailList[" + i + "].Email").isPresent(driver));

            int j = 0;
            bool EmailExist = false;
            do
            {
                if (EnteredEmail.Contains((EmailAddressArray[j])))
                {
                    EmailExist = true;
                    _logger.Info($" Email For Existing Customer Is Added");
                    break;
                }
                j++;
            } while (EmailAddressArray[j] != null);

            return EmailExist;

        }

        /// <summary>
        /// Function to enter address in Address Line1
        /// </summary>
        /// <param name="address1"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine1(String address1)
        {
            addressLine1.SendKeys(address1);
            _logger.Info("entering address Line 1...." + address1);
            return this;
        }

        /// <summary>
        /// Function to enter address in Address Line2
        /// </summary>
        /// <param name="address2"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine2(String address2)
        {
            addressLine2.SendKeys(address2);
            _logger.Info("entering address Line 2...." + address2);
            return this;
        }

        /// <summary>
        /// Function to enter city 
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterCity(String City)
        {
            city.SendKeys(City);
            _logger.Info("entering city...." + City);
            return this;
        }

        /// <summary>
        /// Function to select state value
        /// </summary>
        /// <param name="statevalue"></param>
        /// <returns></returns>
        public EnterNewCustomerPage SelectState(String statevalue)
        {


            Actions actions_ = new Actions(driver);
            actions_.SendKeys(this.state, statevalue).Build().Perform();
            state.SendKeys(Keys.Enter);
            return this;
        }


        /// <summary>
        /// Function to enter zip
        /// </summary>
        /// <param name="Zip"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterZip(String Zip)
        {
            zip.SendKeys(Zip);
            _logger.Info("entering zip...." + Zip);
            return this;
        }

        /// <summary>
        /// Function to Click on addtion address for the customer
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickOnAddAddressPlusButton()
        {
            AddAddress.Clickme(driver);
            Thread.Sleep(2000);
            return this;
        }

        /// <summary>
        /// Function to click on corrected address button on smarty street
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickOnUserAddressAsEnteredButtonOnSmartyStreet()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(UseAddressAsEntered, 20000);
            UseAddressAsEntered.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Function to Clicking on tax exemption checkbox
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickTaxExemptionCheckBox()
        {

            TaxCheckBox.Clickme(driver);
            Thread.Sleep(1000);
            return this;
        }

        /// <summary>
        /// Function to enter taxid number
        /// </summary>
        /// <param name="taxid"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterTaxIDNumber(string taxid, int i)
        {
            String strtaxID = "#taxIdNumber" + i;
            driver.FindElement(By.CssSelector(strtaxID)).SendKeys(taxid);
            return this;
        }


        /// <summary>
        /// Function to select state in tax section
        /// </summary>
        /// <param name="taxstatevalue"></param>
        /// <returns></returns>


        public EnterNewCustomerPage SelectTaxState(String taxstatevalue, int i)
        {
            String strtaxID = "//input[@id='exemptStateAbbreviation" + i + "']";

            Actions actions_ = new Actions(driver);
            actions_.SendKeys(driver.FindElement(By.XPath(strtaxID)), taxstatevalue).Build().Perform();
            driver.FindElement(By.XPath(strtaxID)).SendKeys(Keys.Enter);
            return this;
        }


        /// <summary>
        /// Function to check the doesnt expire tax exemption checkbox
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickDoesntExpireCheckBox(int i)
        {
            String doesntexpirecheckbox = "//input[@id='doesNotExpire" + i + "']";

            driver.FindElement(By.XPath(doesntexpirecheckbox)).Clickme(driver);
            return this;
        }


        public EnterNewCustomerPage AddTax()
        {
            AddTaxButton.Clickme(driver);
            Thread.Sleep(2000);
            return this;
        }



        /// <summary>
        /// Function to verify thatcustomer is created the valid first name
        /// </summary>
        /// <param name="ExpFirstName"></param>
        /// <returns></returns>
        public bool VerifCustomerIsCreatedWithValidFirstName(String ExpFirstName)
        {
            bool IsFirstName = false;
            String ActualFirstName = ViewOnlyfirstName.GetText(driver);

            if (ExpFirstName.Contains(ActualFirstName))
            {
                IsFirstName = true;
            }

            return IsFirstName;
        }

        /// <summary>
        /// Function to verify thatcustomer is created the valid last name
        /// </summary>
        /// <param name="ExpLastName"></param>
        /// <returns></returns>
        public bool VerifCustomerIsCreatedWithValidLastName(String ExpLastName)
        {
            bool IsLastName = false;
            String ActualLastName = ViewOnlylastname.GetText(driver);

            if (ExpLastName.Contains(ActualLastName))
            {
                IsLastName = true;
            }

            return IsLastName;
        }

        /// <summary>
        /// Function to verify that customer is created with valid address
        /// </summary>
        /// <param name="ExpAddressline1"></param>
        /// <param name="ExpCity"></param>
        /// <param name="ExpState"></param>
        /// <param name="ExpZipcode"></param>
        /// <returns></returns>
        public bool VerifCustomerIsCreatedWithValidBillingAddress(String ExpAddressline1, String ExpCity, String ExpState, String ExpZipcode)
        {
            bool IsAddressCorrect = false;
            driver.WaitForElementToBecomeVisibleWithinTimeout(viewOnlyAddressLine1, 2000);
            String ActualAddressLine1 = viewOnlyAddressLine1.GetText(driver);
            String ActualCity = viewOnlyCity.GetText(driver);
            String ActualState = viewOnlyState.GetText(driver);
            String ActualZip = viewOnlyZip.GetText(driver);
            bool billingaddress = driver.FindElement(By.XPath("//span[contains(text(),'Billing Address')]")).Displayed;

            if (ExpAddressline1.Contains(ActualAddressLine1) && ExpCity.Contains(ActualCity) && ExpState.Contains(ActualState.Substring(0, 1)) && ExpZipcode.Contains(ActualZip))
            {
                if (billingaddress == true)
                {
                    IsAddressCorrect = true;
                }

            }

            return IsAddressCorrect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
            return this;
        }
    }


}
