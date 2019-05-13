using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.Page;
using System.Threading;
using System.Globalization;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Pages
{
    public class OrderPage
    {

        public IWebDriver driver;
        private Logger _logger = LogManager.GetCurrentClassLogger();
        public int precount = 1;
        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'ORDER')]")]
        private IWebElement OrderPageText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='select-value-trancate']")]
        private IWebElement OpenActivityOrderText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='search-label']")]
        private IWebElement OpenActivityLoader { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus-circle show-hide-payment']")]
        private IWebElement AddDetailButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='table-grid accordion-panel']/ul/li")]
        private IList<IWebElement> RecordInPaymentGrid { get; set; }

        [FindsBy(How = How.Id, Using = "btnNewPayment")]
        private IWebElement NewPaymentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'row gutter-top gutter-sm-bottom')]//li[2]//div[@class='dot-btn']//span")]
        private IWebElement PaymentRowHamberger { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Refund')]")]
        private IWebElement Refund { get; set; }

        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-space']/ul/li")]
        public IWebElement WarningText { get; set; }

        /// <summary>
        /// Function to verify that order is created
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyOrderIsCreated()

        {
           driver.waitForElementNotVisible("//span[@class='search-label']");
            driver.WaitForElement(OrderPageText);

            bool isOrderCreated = false;
            
            String ActualOrderInActivityText = OpenActivityOrderText.GetText(driver);

            if ((OrderPageText.Displayed) && (ActualOrderInActivityText.Contains("ORDER")))
            {
                isOrderCreated = true;
                _logger.Info($" User is navigated to order page and order is created successfully");
            }
            return isOrderCreated;
           
        }
        /// <summary>
        /// Function to verify that correct number of row is added on payment grid after each successful payment
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyCorrectNumberOfRowAddedInPaymentSection()

        {
            int actualNoOfrecordInPaymentGrid = RecordInPaymentGrid.Count();

            if (precount + 1 == actualNoOfrecordInPaymentGrid)
            {
                precount++;
                return true;
            }
            else {
                return false;
            }

        }

        /// <summary>
        /// Function to verifypayment grid data on order page
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean VerifyGridData(List<GridRecord> record)

        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            Boolean IsDataMatched = false;
            int rowno = 2;
            

            for (int counter = 0; counter < record.Count; counter++)
            {
                IsDataMatched = false;
                IWebElement gridRecord = driver.FindElement(By.XPath("//div[contains(@class,'row gutter-top gutter-sm-bottom')]//li[" + rowno + "]"));
                string RowValue = gridRecord.GetText(driver);
                string[] RowLosit = RowValue.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> ExpectedFilteredLosit = new List<string>();

                int count = 0;
                bool isCredit = RowLosit.ToList().Exists(x => x.Equals("••••"));
                RowLosit.ToList().ForEach(x =>
                {
                    if (count== 3 && isCredit)
                    {
                        ExpectedFilteredLosit[1] += x;
                    }
                    else if (!x.Equals("••••") && !x.Equals(DateTime.Now.ToString("M/d/yyyy", CultureInfo.InvariantCulture)))
                    {
                        ExpectedFilteredLosit.Add(x);
                    }
                    count++;
                });

                if ((record[counter].Payment.Equals(ExpectedFilteredLosit[0])) && (record[counter].PaymentMethod.Equals(ExpectedFilteredLosit[1])) && (record[counter].OrderStatus.Equals(ExpectedFilteredLosit[2])) && (record[counter].SalesPerson.Equals(ExpectedFilteredLosit[3])) && (record[counter].AmountCollected.Equals(ExpectedFilteredLosit[4])) && (record[counter].AmountPosted.Equals(ExpectedFilteredLosit[5])) && (record[counter].BalanceDue.Equals(ExpectedFilteredLosit[6])))
                {
                    IsDataMatched = true;
                    _logger.Info($" Grid Data is populating correctly and matched with expected record");
                }
                else
                {
                    break;
                }

                rowno++;
            }


            return IsDataMatched;
        }
        /// <summary>
        /// Function to click on add detail button on order page
        /// </summary>
        /// <returns></returns>
        public OrderPage ClickOnAddDetailsButton()
        {
            

            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //This will scroll the page till the element is found		
            ex.ExecuteScript("arguments[0].scrollIntoView();", AddDetailButton);
            AddDetailButton.Clickme(driver);
            return this;

        }

        /// <summary>
        ///Function to click on add new payment button on order page
        /// </summary>
        /// <returns></returns>

        public OrderPage ClickOnNewPaymentButton()
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //This will scroll the web page till end.		
            ex.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            NewPaymentButton.Clickme(driver);
            return this;

        }
        /// <summary>
        /// Function to click on hamberger on payment grid
        /// </summary>
        /// <returns></returns>
        public OrderPage ClickOnHamberger()
        {
            driver.WaitForElement(PaymentRowHamberger);
            PaymentRowHamberger.Clickme(driver);
            return this;

        }
        /// <summary>
        /// Function to click on refund option on hamberger in payment grid record
        /// </summary>
        /// <returns></returns>
        public OrderPage ClickOnRefund()
        {
            driver.WaitForElement(Refund);
            Refund.Clickme(driver);
            return this;

        }

        /// <summary>
        /// Function to verify max transaction warning text on clicking on payment button
        /// </summary>
        /// <param name="expWarningMessage"></param>
        /// <returns></returns>
        public Boolean VerifyMaxTransWarningOnOrderScreen_PaymentButton (String expWarningMessage)
        {
            

            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //This will scroll the web page till end.		
            ex.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            NewPaymentButton.Clickme(driver);

            bool isWarningPopulated = false;
            driver.WaitForElement(WarningText);

            String ActualWarningMessageForMaxiumumTransaction = WarningText.GetText(driver);

            if (expWarningMessage.Equals(ActualWarningMessageForMaxiumumTransaction))
            {
                isWarningPopulated = true;
                _logger.Info($" Maximun transaction has been reached");
            }
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            return isWarningPopulated;

        }

        /// <summary>
        /// Function to verify max transaction warning tax on clicking on refund link
        /// </summary>
        /// <param name="expWarningMessage"></param>
        /// <returns></returns>
        public Boolean VerifyMaxTransWarningOnOrderScreen_RefundLink(String expWarningMessage)
        {

            bool isWarningPopulated = false;
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            AddDetailButton.Clickme(driver);
            ClickOnHamberger();
            ClickOnRefund();
            driver.WaitForElement(WarningText);

            String ActualWarningMessageForMaxiumumTransaction = WarningText.GetText(driver);

            if (expWarningMessage.Equals(ActualWarningMessageForMaxiumumTransaction))
            {
                isWarningPopulated = true;
                _logger.Info($" Maximun transaction has been reached");
            }
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            ClickOnHamberger();
            return isWarningPopulated;

        }


    }
}
