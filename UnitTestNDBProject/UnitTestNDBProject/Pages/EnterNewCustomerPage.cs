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
        public List<Tuple<string, string>> newPhones;
        public List<Tuple<string, string>> newTax;
        public List<Tuple<string, string, string, string, string>> newAddresses;
        public List<string> newEmails;

        public EnterNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


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

        [FindsBy(How = How.XPath, Using = "//label[@for='addressLine2']/following-sibling::span")]
        public IWebElement viewOnlyAddressLine2 { get; set; }

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

        [FindsBy(How = How.XPath, Using = "((//div[@class='row phone-data']//span[@class='form-value'])[5]")]
        public IWebElement ViewOnlyTaxIdNumber { get; set; }


        [FindsBy(How = How.XPath, Using = "(//div[@class='row phone-data']//span[@class='form-value break-all'])[1]")]
        public IWebElement EmailAddressViewOnly { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add Address')]")]
        public IWebElement AddAddress { get; set; }

        [FindsBy(How = How.Id, Using = "btnUseEnteredAddress")]
        public IWebElement UseAddressAsEntered { get; set; }


        [FindsBy(How = How.Id, Using = "btnCorrectAddress")]
        public IWebElement AddressIsCorrect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkbox-TaxExempt")]
        public IWebElement TaxCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='exceptions-section']//i[@class='icon-plus-circle']")]
        public IWebElement AddTaxButton { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }


        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='has-error-message']")]
        public IWebElement InvalidText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnSection']//ul/li[2]")]
        public IWebElement PopupFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-space']//ul/li")]
        public IWebElement PopupMainMessage{ get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelUpper")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "purchaseOrder")]
        public IWebElement POStatus { get; set; }

        [FindsBy(How = How.Id, Using = "creditLimit")]
        public IWebElement CreditLimit { get; set; }
        


        /// <summary>
        /// Click On Enter New Customer Buton
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickEnterNewCustomerButton()
        {

           new System.Threading.ManualResetEvent(false).WaitOne(3000);
            enterNewCustomer.Clickme(driver);
            _logger.Info($": Successfully clicked Enter New Custokmer button");
            return this;
        }

        /// <summary>
        /// Click on Ok button in popup
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage OkOnErrorMessage()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, OkButton, 60);
            OkButton.Clickme(driver);
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
            firstName.Clear();
            firstName.EnterText(fname);
            _logger.Info($": Successfully Entered First Name {fname}");
            return this;
        }
        /// <summary>
        /// Functions to Enter Last Name
        /// </summary>
        /// <param name="lname"></param>
        /// <returns></returns>

        public EnterNewCustomerPage EnterLastName(string lname)
        {
            lastname.Clear();
            lastname.EnterText(lname);
            _logger.Info($": Successfully Entered Last Name {lname}");
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterPhoneNumber(string phone)
        {
            phonenumber.EnterText(phone);
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
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            string strMyXPath = "phoneLists[" + i + "].Phone";
            driver.FindElement(By.Id(strMyXPath)).EnterText(phone);
            _logger.Info($": Successfully Entered Phone Number {phone}");
            return this;

        }
        /// <summary>
        /// Add New Phone
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage AddPhone()
        {
            addPhone.Clickme(driver);
            _logger.Info($": Successfully Entered Add Phone button");
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
            _logger.Info($": Successfully Entered Phone Type {phonetype}");
            return this;

        }

        /// <summary>
        /// Enter email address and uncheck the marketing email opt in checkbox if (checked) only
        /// </summary>
        /// <param name="email"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterEmailAddress(string email, int i)
        {
            String strEmailAddress = "emailList[" + i + "].Email";
            driver.FindElement(By.Id(strEmailAddress)).Clear();
            //new System.Threading.ManualResetEvent(false).WaitOne(2000);
            driver.FindElement(By.Id(strEmailAddress)).EnterText(email);
            _logger.Info($": Successfully Entered Email {email}");

            string strMarketMyXpath = "emailList[" + i + "].emailOptIn";
            string strValueAttributeText = driver.FindElement(By.Name(strMarketMyXpath)).GetAttribute("value");
            if (strValueAttributeText.Contains("true"))
            {
                driver.FindElement(By.Name(strMarketMyXpath)).Click();
                _logger.Info($": Successfully Unchecked Marketing Email Opt In checkbox");
            }

            return this;
        }

        public EnterNewCustomerPage AddEmailAddress()
        {
            addEmail.Clickme(driver);
            _logger.Info($": Successfully Entered Add Email button");
            return this;
        }

        /// <summary>
        /// Save functionality for negative Scenario
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage VerifySmartyStreet()
        {

           try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnUseEnteredAddress")));
                UseAddressAsEntered.Clickme(driver);
                _logger.Info($": Continue As Use address as entered on smarty street - If available");
            }
            catch (Exception e)
            {
                try
                {
                    WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnCorrectAddress")));
                    AddressIsCorrect.Clickme(driver);
                    _logger.Info($": Continue As This address is correct on smarty street - If available");
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.StackTrace);
                }

            }


            return this;
        }

            

        /// <summary>
        /// Click on Save button and handle the smarty street if it populates
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickSaveButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(saveButton, 10000);
            saveButton.Clickme(driver);
            _logger.Info($":Clicked on SAVE button of customer page");
            return this;
        }

        /// <summary>
        /// CLick on Address Line1
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickOnAddressLine1()
        {
           // new System.Threading.ManualResetEvent(false).WaitOne(1000);
            addressLine1.Clickme(driver);
            _logger.Info($": Clicked on AddressLine1 text box");
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
                _logger.Info($": Continue As New Customer button - If available");
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
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='btnSection']/div/div[1]/div[2]/div/div/div/div/div/div[2]/div/div[1]")));
                continueWithExistingCustomer.Clickme(driver);
                _logger.Info($": Selects existing customer");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return this;
        }

        /// <summary>
        /// Functions to click Save button and handle the smarty street if it populates
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickEditSaveButton()
        {
            //new System.Threading.ManualResetEvent(false).WaitOne(1000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(saveButtonEdit, 10000);
            saveButtonEdit.Clickme(driver);
            _logger.Info($": Successfully clicked on SAVE button for existing customer");
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnUseEnteredAddress")));
                UseAddressAsEntered.Clickme(driver);
                _logger.Info($": Continue As Use address as entered on smarty street - If available");
            }
            catch (Exception e)
            {
                try
                {
                    WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnCorrectAddress")));
                    AddressIsCorrect.Clickme(driver);
                    _logger.Info($": Continue As This address is correct on smarty street - If available");
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.StackTrace);
                }

            }

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
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("msg-container")));
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
        public bool VerifyFirstName(String firstNameOnFile)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", FirstNameText);

            // Thread.Sleep(3000);
            // WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='col-sm-3 pad-left-none']//span[@class='form-value']")));
            String fName = FirstNameText.GetText(driver);
            bool firstNameValue = false;
          //  new System.Threading.ManualResetEvent(false).WaitOne(1000);
            if (fName.Contains(firstNameOnFile))
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
        public bool VerifyLastName(String lastNameOnFile)
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='col-sm-6 pad-left-none']//span[@class='form-value']")));

            String LastName = LastNameText.GetText(driver);
            bool lastNameValue = false;
           // new System.Threading.ManualResetEvent(false).WaitOne(1000);
            if (LastName.Contains(lastNameOnFile))
            {
                lastNameValue = true;
                _logger.Info($" Last Name Is Correct");
            }
            return lastNameValue;

        }

        /// <summary>
        /// Function to add customer phones
        /// </summary>
        /// <param name="phones"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> AddCustomerPhones(List<Phone> phones)
        {
            newPhones = new List<Tuple<string, string>>();

            //Input phones
            for (int counter = 0; counter < phones.Count; counter++)
            {
                string phone = CommonFunctions.AppendMaxRangeRandomString(phones[counter].PhoneNumber);
                string phoneType = phones[counter].PhoneType;
                EnterPhone(phone, counter).SelectPhoneType(phoneType, counter);

                try
                {
                    if ((counter < phones.Count - 1) && saveButton.Displayed)
                    {
                        AddPhone();
                    }
                }
                catch
                {
                    _logger.Info("Save button is not displayed and User is updating the phone number of customer details");
                }

                newPhones.Add(new Tuple<string, string>(phone, phoneType));
            }

            return newPhones;
        }


        /// <summary>
        /// Veerify Phone Number is same as entered
        /// </summary>
        /// <param name="EnteredPhone"></param>
        /// <returns></returns>
        public bool VerifyPhoneNumberAndPhoneType()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='row phone-data']//span[@class='form-value'])[1]")));

            bool PhoneNumberAndTypeValue = false;

            for (int counter = 0; counter < newPhones.Count; counter++)
            {
                var phoneCounter = counter * 2 + 1;

                string phoneNumberXpath = "(//div[@class='row phone-data']//span[@class='form-value'])[" + phoneCounter + "]";
                string phoneNumber = driver.FindElement(By.XPath(phoneNumberXpath)).GetText(driver);
                string actualPhoneNumber = string.Concat(phoneNumber.Substring(1, 3), phoneNumber.Substring(6, 3), phoneNumber.Substring(10, 4));

                string ExpectedPhone = newPhones[counter].Item1;
                if (ExpectedPhone.Contains(actualPhoneNumber))
                {
                    PhoneNumberAndTypeValue = true;
                    _logger.Info($" Phone Is Correct");
                }

                var phonetypecounter = phoneCounter + 1;

                string Phonetypexpath = "(//div[@class='row phone-data']//span[@class='form-value'])[" + phonetypecounter + "]";
                string ActualPhoneType = driver.FindElement(By.XPath(Phonetypexpath)).GetText(driver);
                string ExpectedPhoneType = newPhones[counter].Item2;

                if (ExpectedPhoneType.Contains(ActualPhoneType))
                {
                    PhoneNumberAndTypeValue = true;
                    _logger.Info($" Phone Is Correct");
                }

            }

            return PhoneNumberAndTypeValue;

        }

        public bool VerifyTaxidNumberAndState()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='row phone-data']//span[@class='form-value'])[5]")));


            bool taxIdNumberAndStateValue = false;

            for (int counter = 0; counter < newTax.Count; counter++)
            {
                var taxNumberCounter = counter + 5;

                string taxNumberXpath = "(//div[@class='row phone-data']//span[@class='form-value'])[" + taxNumberCounter + "]";
                string taxNumber = driver.FindElement(By.XPath(taxNumberXpath)).GetText(driver);

                string expectedTaxIdNumber = newTax[counter].Item1;

                if (expectedTaxIdNumber.Contains(taxNumber))
                {
                    taxIdNumberAndStateValue = true;
                    _logger.Info($" TaxidNumber Is Correct");
                }

                var taxStateCounter = taxNumberCounter + 1;

                string taxStateXpath = "(//div[@class='row phone-data']//span[@class='form-value'])[" + taxStateCounter + "]";
                string actaulTaxState = driver.FindElement(By.XPath(taxStateXpath)).GetText(driver);
                string expectedTaxState = newTax[counter].Item2;

                if (expectedTaxState.Contains(actaulTaxState))
                {
                    taxIdNumberAndStateValue = true;
                    _logger.Info($"Tax state Is Correct");
                }

            }

            return taxIdNumberAndStateValue;

        }


        public bool VerifyEmailAddress()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='row phone-data']//span[@class='form-value break-all'])[1]")));

            bool emailAddressValue = false;

            for (int counter = 0; counter < newEmails.Count; counter++)
            {
                var emailCounter = counter + 1;

                string emailXpath = "(//div[@class='row phone-data']//span[@class='form-value break-all'])[" + emailCounter + "]";
                string actualEmailText = driver.FindElement(By.XPath(emailXpath)).GetText(driver);


                string ExpectedEmail = newEmails[counter];
                if (ExpectedEmail.Contains(actualEmailText))
                {
                    emailAddressValue = true;
                    _logger.Info($" Email Is Correct{emailCounter}");
                }

           

            }
            return emailAddressValue;


        }


        /// <summary>
        /// Function to verify that customer is created with valid address
        /// </summary>
        /// <param name="ExpAddressline1"></param>
        /// <param name="ExpCity"></param>
        /// <param name="ExpState"></param>
        /// <param name="ExpZipcode"></param>
        /// <returns></returns>
        public bool VerifCustomerIsCreatedWithValidBillingAddress(string expAddressline1, string expCity, string expState, string expZipcode)
        {
            bool isAddressCorrect = false;
            driver.WaitForElementToBecomeVisibleWithinTimeout(viewOnlyAddressLine1, 2000);
            String ActualAddressLine1 = viewOnlyAddressLine1.GetText(driver);
            String ActualCity = viewOnlyCity.GetText(driver);
            String ActualState = viewOnlyState.GetText(driver);
            String ActualZip = viewOnlyZip.GetText(driver);
            bool billingaddress = driver.FindElement(By.XPath("//span[contains(text(),'Billing Address')]")).Displayed;

            if (expAddressline1.Contains(ActualAddressLine1) && expCity.Contains(ActualCity) && expState.Contains(ActualState.Substring(0, 1)) && expZipcode.Contains(ActualZip) && billingaddress)
            {
                isAddressCorrect = true;
            }

            return isAddressCorrect;
        }

        /// <summary>
        /// Verifies the address
        /// </summary>
        /// <returns></returns>
        public bool VerifyAddressine2()
        {
            bool isaddressline2 = false;
            for (int counter1 = 0; counter1 < newAddresses.Count; counter1++)
            {
                if (!newAddresses[counter1].Item2.Equals(""))
                {
                    for (int counter = 0; counter < newAddresses.Count; counter++)
                    {
                        string expectedAddressLine2 = newAddresses[counter].Item2;
                        string actualAddressLine2 = viewOnlyAddressLine2.GetText(driver);

                        if (expectedAddressLine2.Contains(actualAddressLine2))
                        {
                            isaddressline2 = true;
                        }
                    }
                    return isaddressline2;
                }

                else
                {
                    _logger.Info("addressline2 is not present");
                    isaddressline2 = true;
                }
            }
            return isaddressline2;
        }

        public bool VerifyAddress()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(viewOnlyAddressLine1, 10000);

            bool isAddressCorrect = false;

            for (int counter = 0; counter < newAddresses.Count; counter++)
            {

                string expectedAddressLine1 = newAddresses[counter].Item1;
                string actualAddressLine1 = viewOnlyAddressLine1.GetText(driver);
                // string expectedAddressLine2 = newAddresses[counter].Item2;
                //string actualAddressLine2 = viewOnlyAddressLine2.GetText(driver);
                string expectedCity = newAddresses[counter].Item3;
                string actualCity = viewOnlyCity.GetText(driver);
                string expectedState = newAddresses[counter].Item4;
                string actualState = viewOnlyState.GetText(driver);
                string expectedZip = newAddresses[counter].Item5;
                string actualZip = viewOnlyZip.GetText(driver);

                bool billingaddress = driver.FindElement(By.XPath("//span[contains(text(),'Billing Address')]")).Displayed;

                if (expectedAddressLine1.Contains(actualAddressLine1) && expectedCity.Contains(actualCity) && expectedState.Contains(actualState.Substring(0, 1)) && expectedZip.Contains(actualZip) && billingaddress)
                {
                    isAddressCorrect = true;
                }
            }

            return isAddressCorrect;
        }


        /// <summary>
        /// Verify that phone numbers are appended in existing customer.
        /// </summary>
        /// <param name="EnteredPhone"></param>
        /// <returns></returns>
        public bool VerifyExistingPhoneNumber(string EnteredPhone)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            int i = 0;
            string[] phoneNumberArray = new string[100];

            do
            {
                string phoneNumber = driver.FindElement(By.Id("phoneLists[" + i + "].Phone")).GetAttribute("value");
                string actualPhoneNumber = string.Concat(phoneNumber.Substring(1, 3), phoneNumber.Substring(6, 3), phoneNumber.Substring(10, 4));
                phoneNumberArray[i] = actualPhoneNumber;
                i++;
            } while (By.Id("phoneLists[" + i + "].Phone").isPresent(driver));

            int j = 0;
            bool phoneExist = false;
            do
            {
                if (EnteredPhone.Contains((phoneNumberArray[j])))
                {
                    phoneExist = true;
                    _logger.Info($" Phone " + EnteredPhone + " For Existing Customer Is Added");
                    break;
                }
                j++;
            } while (phoneNumberArray[j] != null);

            return phoneExist;

        }

        /// </summary>
        /// <param name="EnteredEmail"></param>
        /// <returns></returns>
        public bool VerifyExistingEmailAddress(string enteredEmail)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            int i = 0;
            string[] emailAddressArray = new string[100];
            do
            {
                string emailAddress = driver.FindElement(By.Id("emailList[" + i + "].Email")).GetAttribute("value");
                emailAddressArray[i] = emailAddress;
                i++;
            } while (By.Id("emailList[" + i + "].Email").isPresent(driver));

            int j = 0;
            bool emailExist = false;
            do
            {
                if (enteredEmail.Contains((emailAddressArray[j])))
                {
                    emailExist = true;
                    _logger.Info($" Email " + enteredEmail + " For Existing Customer Is Added");
                    break;
                }
                j++;
            } while (emailAddressArray[j] != null);

            return emailExist;

        }

        /// <summary>
        /// Function to enter address in Address Line1
        /// </summary>
        /// <param name="address1"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine1(String address1)
        {
            addressLine1.EnterText(address1);
            _logger.Info("Entering address Line 1: " + address1);
            return this;
        }

        /// <summary>
        /// Function to enter address in Address Line2
        /// </summary>
        /// <param name="address2"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine2(String address2)
        {
            addressLine2.EnterText(address2);
            _logger.Info("Entering address Line 2: " + address2);
            return this;
        }

        /// <summary>
        /// Function to enter city 
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterCity(String City)
        {
            city.EnterText(City);
            _logger.Info("Entering city: " + City);
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
            _logger.Info("Entering state: " + statevalue);
            return this;
        }

        /// <summary>
        /// Function to enter zip
        /// </summary>
        /// <param name="Zip"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterZip(string Zip)
        {
            zip.EnterText(Zip);
            _logger.Info("Entering zip: " + Zip);
            return this;
        }

        /// <summary>
        /// Function to Click on addtion address for the customer
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickOnAddAddressPlusButton()
        {
            AddAddress.Clickme(driver);
            _logger.Info($": Successfully clicked Add Address button");
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            return this;
        }


        /// <summary>
        /// Function to Clicking on tax exemption checkbox
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickTaxExemptionCheckBox()
        {

            TaxCheckBox.Clickme(driver);
            _logger.Info($": Successfully Selected Tax Exemption checkbox");
            Thread.Sleep(1000);
            return this;
        }

        /// <summary>
        /// Click on cancel button on customer page
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickCancelButton()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            driver.WaitForElement(CancelButton);
            CancelButton.Clickme(driver);
            _logger.Info($": Successfully Clicked On Cancel Button");
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
            driver.FindElement(By.CssSelector(strtaxID)).EnterText(taxid);
            _logger.Info($": Successfully Selected TaxIDNumber: {taxid}");
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
            _logger.Info($": Successfully Selected TaxState {taxstatevalue}");
            return this;
        }

        /// <summary>
        /// Function to check the doesnt expire tax exemption checkbox
        /// </summary>
        /// <returns></returns>
        public EnterNewCustomerPage ClickDoesntExpireCheckBox(int i)
        {
            string doesntexpirecheckbox = "//input[@id='doesNotExpire" + i + "']";
            IWebElement doesntExpireCheckBoxElement = driver.FindElement(By.XPath(doesntexpirecheckbox));

            if (!doesntExpireCheckBoxElement.Selected)
            {
                doesntExpireCheckBoxElement.Clickme(driver);
                _logger.Info($": Successfully clicked Doesnt Expire CheckBox");
            }
            else
            {
                _logger.Info("TaxExemtion Checkbox is already selected in customer edit mode");
            }


            return this;
        }

        public EnterNewCustomerPage AddTax()
        {
            AddTaxButton.Clickme(driver);
            _logger.Info($": Successfully clicked on Add Tax button");
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            return this;
        }

        public EnterNewCustomerPage ClickEditButton(string id)
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            driver.FindElement(By.Id(id)).Clickme(driver);
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

        public static NewCustomerData GetCustomerData(ParsedTestData featureData)
        {
            object newCustomerFeatureData = DataAccess.GetKeyJsonData(featureData, "customer1");
            return JsonDataParser<NewCustomerData>.ParseData(newCustomerFeatureData);
        }

        public static UpdateCustomerData GetUpdateCustomerData(ParsedTestData featureData)
        {
            object updateCustomerFeatureData = DataAccess.GetKeyJsonData(featureData, "customer1");
            return JsonDataParser<UpdateCustomerData>.ParseData(updateCustomerFeatureData);
        }

        /// <summary>
        /// Function to add customer emails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        public List<string> AddCustomerEmails(List<Email> emails)
        {
            newEmails = new List<string>();

            for (int counter = 0; counter < emails.Count; counter++)
            {
                string email = CommonFunctions.RandomizeEmail(emails[counter].EmailText);
                EnterEmailAddress(email, counter);

                try
                {
                    if ((counter < emails.Count - 1) && saveButton.Displayed)
                    {
                        AddEmailAddress();
                    }
                }
                catch
                {
                    _logger.Info("Save button is not displayed and User is updating the email address of customer details");
                }

                newEmails.Add(email);
            }

            return newEmails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public List<Tuple<string, string, string, string, string>> AddCustomerAddresses(List<Address> addresses)
        {
            newAddresses = new List<Tuple<string, string, string, string, string>>();
            //Input addresses
            for (int counter = 0; counter < addresses.Count; counter++)
            {
                string custAddLine1 = addresses[counter].AddressLine1;
                string custAddLine2 = addresses[counter].AddressLine2;
                string custCity = addresses[counter].City;
                string custState = addresses[counter].State;
                string custZipCode = addresses[counter].ZipCode;

                EnterAddressLine1(custAddLine1).EnterAddressLine2(custAddLine2).EnterCity(custCity).SelectState(custState).EnterZip(custZipCode);

                try
                {
                    if ((counter < addresses.Count - 1) && saveButton.Displayed)
                    {
                        ClickOnAddAddressPlusButton();
                    }
                }
                catch
                {
                    _logger.Info("Save button is not displayed and User is updating the  address of customer details");
                }

                newAddresses.Add(new Tuple<string, string, string, string, string>(custAddLine1, custAddLine2, custCity, custState, custZipCode));
            }
            return newAddresses;
        }


        /// <summary>
        /// Verify popup is displayed with given values
        /// </summary>
        /// <returns></returns>
        public bool VerifyPopupWithValue()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
             driver.WaitForElement(PopupFirstName);
            bool isMessagePopulate = false;

           IList<IWebElement> listOfOption= driver.FindElements(By.XPath("//div[@id='btnSection']//ul/li"));

            if ((Constants.ExpFirstName.Contains(listOfOption[0].Text)) && (Constants.ExpLastName.Contains(listOfOption[1].Text)) && (Constants.ExpPhone.Contains(listOfOption[2].Text)) && (Constants.ExpEmail.Contains(listOfOption[3].Text)) && (Constants.ExpAddress.Contains(listOfOption[4].Text)))
                {
                isMessagePopulate = true;
            }
        
            return isMessagePopulate;
        }

        /// <summary>
        /// Verify popup is displayed for missing phone number as main
        /// </summary>
        /// <returns></returns>
        public bool VerifyPopupForMainPhone()
        {
            driver.WaitForElement(PopupMainMessage);
            bool isMessagePopulate = false;

            String Expected =Constants.NoMainSelectdMessageForPhone;
          String Actual = PopupMainMessage.GetText(driver);

            if  (Actual.Equals(Expected))
                {
                isMessagePopulate = true;
            }

            return isMessagePopulate;
        }

        /// <summary>
        ///Verify popup is displayed for missing email as main
        /// </summary>
        /// <returns></returns>
        public bool VerifyPopupForMainEmail()
        {
            driver.WaitForElement(PopupMainMessage);
            bool isMessagePopulate = false;

            String Expected = Constants.NoMainSelectdMessageForEmail;
            String Actual = PopupMainMessage.GetText(driver);

            if (Actual.Equals(Expected))
            {
                isMessagePopulate = true;
            }

            return isMessagePopulate;
        }


        /// <summary>
        /// Verify invalid phone number
        /// </summary>
        /// <returns></returns>
        public bool VerifyTextForInvalidPhone()
        {
            driver.WaitForElement(InvalidText);
            bool isMessagePopulate = false;

            String Expected = Constants.InvalidPhone;
            String Actual = InvalidText.GetText(driver);

            if (Expected.Equals(Actual))
            {
                isMessagePopulate = true;
            }

            return isMessagePopulate;
        }

        /// <summary>
        /// Verify invalid email
        /// </summary>
        /// <returns></returns>
        public bool VerifyTextForInvalidEmail()
        {
            driver.WaitForElement(InvalidText);
            bool isMessagePopulate = false;

            String Expected = Constants.InvalidEmail;
            String Actual = InvalidText.GetText(driver);

            if (Expected.Equals(Actual))
            {
                isMessagePopulate = true;
            }

            return isMessagePopulate;
        }

        /// <summary>
        /// Select payment order status
        /// </summary>
        /// <param name="taxstatevalue"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public EnterNewCustomerPage SelectPOStatus(String postatus)
        {
            Actions actions_ = new Actions(driver);
            actions_.SendKeys((POStatus), postatus).Build().Perform();
            POStatus.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Selected POSttaus {postatus}");
            return this;
        }

        public EnterNewCustomerPage EnterCreditLimit(String limit)
        {
            CreditLimit.EnterText(limit);
            _logger.Info($": Successfully Entered CreditLimit POSttaus {limit}");
            return this;
        }

        
        /// <summary>
        /// Function to add tax numbers
        /// </summary>
        /// <param name="taxNumbers"></param>
        public List<Tuple<string, string>> AddCustomerTaxNumbers(List<TaxNumber> taxNumbers)
        {
            newTax = new List<Tuple<string, string>>();
            if (!TaxCheckBox.Selected)
            {
                ClickTaxExemptionCheckBox();
            }
            else
            {
                _logger.Info("TaxExemtion Checkbox is already selected in customer edit mode");
            }

            //Input Taxid and Tax state
            for (int counter = 0; counter < taxNumbers.Count; counter++)
            {
                string taxId = CommonFunctions.AppendMaxRangeRandomString(taxNumbers[counter].TaxIdNumber);
                string taxState = taxNumbers[counter].TaxState;

                EnterTaxIDNumber(taxId, counter + 1).SelectTaxState(taxState, counter + 1).ClickDoesntExpireCheckBox(counter + 1);

                try
                {
                    if ((counter < taxNumbers.Count - 1) && saveButton.Displayed)
                    {
                        AddTax();
                    }
                }
                catch
                {
                    _logger.Info("Save button is not displayed and User is updating the tax number of customer details");
                }

                newTax.Add(new Tuple<string, string>(taxId, taxState));
            }
            return newTax;
        }
    }
}