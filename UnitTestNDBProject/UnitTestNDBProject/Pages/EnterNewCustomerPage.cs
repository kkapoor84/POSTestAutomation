using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
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
    public class EnterNewCustomerPage {
        public IWebDriver driver;

        public EnterNewCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [FindsBy(How = How.XPath, Using = "//*[@id='main - header']/div/div[2]/div/div/button")]
        public IWebElement enterNewCustomer { get; set; }

        [FindsBy(How = How.Name, Using = "firstName")]
        public IWebElement firstName { get; set; }
        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement lastname { get; set; }
        [FindsBy(How = How.Name, Using = "phoneLists[0].Phone")]
        public IWebElement phonenumber { get; set; }
        [FindsBy(How = How.Id, Using = "react-select-18--value")]
        public IWebElement phonetype { get; set; }
        [FindsBy(How = How.Id, Using = "btnSaveUpper")]
        public IWebElement saveButton { get; set; }
        [FindsBy(How = How.Id, Using = "btnContinue")]
        public IWebElement continueWithNewCustomer { get; set; }


        [FindsBy(How = How.Id, Using = "contactEdit")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='customerHeaderWithDoc']/div/div/div[2]/div/div[2]/div/span")]
        public IWebElement noOpenActivityText { get; set; }

        public EnterNewCustomerPage ClickEnterNewCustomerButton()
        {
            Thread.Sleep(2000);
            enterNewCustomer.Clickme(driver);
            return this;
        }

        public EnterNewCustomerPage EnterFirstName(string fname)
        {
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

        public EnterNewCustomerPage ClickSaveButton()
        {
            enterNewCustomer.Clickme(driver);
            return this;
        }


        

        public EnterNewCustomerPage SelectPhoneType(string ptype)
        {
            return this;
        }
        public bool VerifyCustomerCreation(string InvalidMesage)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButton, 5000);
            bool isMessagePopulate = false;

            string ActualMessage = noOpenActivityText.Text;
            string ExpectedMessage = InvalidMesage;

            if (ActualMessage.Contains(ExpectedMessage))
            {
                isMessagePopulate = true;
            }
            return isMessagePopulate;
        }
    }

   
   

}
