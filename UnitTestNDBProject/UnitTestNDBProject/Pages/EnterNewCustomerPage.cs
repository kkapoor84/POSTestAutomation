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
using UnitTestNDBProject.Utils;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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

        [FindsBy(How = How.Id, Using = "btnUseEnteredAddress")]
        public IWebElement UseAddressAsEntered { get; set; }

        [FindsBy(How = How.Id, Using = "emailList[0].Email")]
        public IWebElement emailAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkbox-TaxExempt")]
        public IWebElement TaxCheckBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='exceptions-section']//i[@class='icon-plus-circle']")]
        public IWebElement AddTaxButton { get; set; }


        



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

        public EnterNewCustomerPage ClickSaveButton()
        {

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
        /// Click on New Customer Creation button (if customer suggetion popup populates)
        /// </summary>
        public void ContinueNewCustomerCreation()
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

        }

        /// <summary>
        /// Function to enter address in Address Line1
        /// </summary>
        /// <param name="address1"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine1(String address1)
        {
 		addressLine1.SendKeys(address1);
            _logger.Info("entering address Line 1...."+ address1);
            return this;
		}

        /// <summary>
        /// Function to enter address in Address Line2
        /// </summary>
        /// <param name="address2"></param>
        /// <returns></returns>
        public EnterNewCustomerPage EnterAddressLine2 (String address2)
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
        public EnterNewCustomerPage enterZip(String Zip)
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
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public EnterNewCustomerPage AddEmailAddress(string email)
        {

            emailAddress.SendKeys(email);
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
        public bool VerifCustomerIsCreatedWithValidBillingAddress(String ExpAddressline1,String ExpCity, String ExpState, String ExpZipcode)
        {
            bool IsAddressCorrect = false;
            driver.WaitForElementToBecomeVisibleWithinTimeout(viewOnlyAddressLine1, 2000);
            String ActualAddressLine1 = viewOnlyAddressLine1.GetText(driver);
            String ActualCity = viewOnlyCity.GetText(driver);
            String ActualState = viewOnlyState.GetText(driver);
            String ActualZip = viewOnlyZip.GetText(driver);
            bool billingaddress = driver.FindElement(By.XPath("//span[contains(text(),'Billing Address')]")).Displayed;

            if (ExpAddressline1.Contains(ActualAddressLine1) && ExpCity.Contains(ActualCity) && ExpState.Contains(ActualState.Substring(0,1)) && ExpZipcode.Contains(ActualZip))
            {
                if (billingaddress == true)
                {
                    IsAddressCorrect = true;
                }
                
            }

            return IsAddressCorrect;
        }


        /// <summary>
        /// Function to verify that customer is created and activity text is displayed
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

