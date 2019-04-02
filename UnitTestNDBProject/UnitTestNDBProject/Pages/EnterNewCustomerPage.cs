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
        public Logger _logger = LogManager.GetCurrentClassLogger();

        public EnterNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

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

        [FindsBy(How = How.Id, Using = "address-line2")]

        public IWebElement addressLine2 { get; set; }

        [FindsBy(How = How.Id, Using = "address-city")]

        public IWebElement city { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='state']")]

        public IWebElement state { get; set; }

        [FindsBy(How = How.Name, Using = "zip")]
        public IWebElement zip { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveUpper")]
        public IWebElement saveButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnContinue")]
        public IWebElement continueWithNewCustomer { get; set; }


        [FindsBy(How = How.Id, Using = "contactEdit")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='customerHeaderWithDoc']/div/div/div[2]/div/div[2]/div/h5")]
        public IWebElement OpenActivityText { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add Address')]")]
        public IWebElement AddAddress { get; set; }

        [FindsBy(How = How.Id, Using = "btnUseCorrectedAddress")]
        public IWebElement CorrectedAddressbutton { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkbox-TaxExempt")]
        public IWebElement TaxCheckBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#taxIdNumber1")]
        public IWebElement TaxIDNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='exemptStateAbbreviation1']")]
        public IWebElement TaxState { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='doesNotExpire1']")]
        public IWebElement DoesntExpire { get; set; }


        




        public EnterNewCustomerPage ClickEnterNewCustomerButton()
        {

            driver.WaitForElementToBecomeVisibleWithinTimeout(enterNewCustomer, 10000);
            enterNewCustomer.Clickme(driver);
            return this;
        }

        public EnterNewCustomerPage EnterFirstName(string fname)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(firstName, 10000);
            firstName.SendKeys(fname);
            return this;
        }

        public EnterNewCustomerPage EnterLastName(string lname)
        {
            lastname.SendKeys(lname);
            return this;
        }
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

        public EnterNewCustomerPage ClickSaveButton()
        {

            saveButton.Clickme(driver);
            return this;

        }

        public EnterNewCustomerPage ClickOnAddressLine1()
        {
            Thread.Sleep(2000);
            addressLine1.Clickme(driver);
            
            return this;
        }


        public EnterNewCustomerPage ContinueNewCustomerCreation()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(continueWithNewCustomer, 10000);
            continueWithNewCustomer.Clickme(driver);
            return this;
        }

        public EnterNewCustomerPage EnterAddressLine1(String address1)
        {
		
		addressLine1.SendKeys(address1);
            _logger.Info("entering address Line 1...."+ address1);
            return this;
		}

    public EnterNewCustomerPage EnterAddressLine2 (String address2)
	{
		addressLine2.SendKeys(address2);
            _logger.Info("entering address Line 2...." + address2);
            return this;
        }

    public EnterNewCustomerPage EnterCity(String City)
    {
        city.SendKeys(City);
            _logger.Info("entering city...." + City);
            return this;
        }

    public EnterNewCustomerPage SelectState(String statevalue)
    {


            Actions actions_ = new Actions(driver);
            actions_.SendKeys(this.state, statevalue).Build().Perform();
            state.SendKeys(Keys.Enter);
            return this;
        }

        public EnterNewCustomerPage SelectTaxState(String taxstatevalue)
        {


            Actions actions_ = new Actions(driver);
            actions_.SendKeys(this.TaxState, taxstatevalue).Build().Perform();
            TaxState.SendKeys(Keys.Enter);
            return this;
        }

        public EnterNewCustomerPage enterZip(String Zip)
    {
        zip.SendKeys(Zip);
            _logger.Info("entering zip...." + Zip);
            return this;
        }

        public EnterNewCustomerPage ClickOnAddAddressPlusButton()
        {
            AddAddress.Clickme(driver);
            Thread.Sleep(2000);
            return this;
        }

        public EnterNewCustomerPage ClickOnCorrectedAddressButtonOnSmartyStreet()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(CorrectedAddressbutton, 10000);
            CorrectedAddressbutton.Clickme(driver);
            return this;
        }

        public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
            return this;
        }

        public EnterNewCustomerPage ClickTaxExemptionCheckBox()
        {

            TaxCheckBox.Clickme(driver);
            return this;
        }

        public EnterNewCustomerPage EnterTaxIDNumber (string taxid)
        {

            TaxIDNumber.SendKeys(taxid);
            return this;
        }

        public EnterNewCustomerPage ClickDoesntExpireCheckBox()
        {

            DoesntExpire.Clickme(driver);
            return this;
        }

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

        public bool VerifyEditButtonAvailable()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButton, 5000);
            bool editButtonAvailibility = false;
            if (EditButton.Displayed)
            {
                editButtonAvailibility = true;
                _logger.Info($" Edit Button is Available");
            }

            return editButtonAvailibility;

        }

    }
}

