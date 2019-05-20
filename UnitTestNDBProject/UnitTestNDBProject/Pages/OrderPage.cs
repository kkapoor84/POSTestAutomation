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
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using UnitTestNDBProject.Tests;

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

        public static int beforeCount = 0;
        public static int afterCount = 0;

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

        [FindsBy(How = How.XPath, Using = "(//div[@class='dot-btn'])[1]")]
        public IWebElement HamburgerClick { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='dot-btn'])[2]")]
        public IWebElement HamburgerClick2 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//ul[@class='action-popup']//span[text()='COPY'])[1]")]
        public IWebElement CopyProductLine { get; set; }

        [FindsBy(How = How.XPath, Using = "(//ul[@class='action-popup']//span[text()='EDIT'])[2]")]
        public IWebElement EditProductLine { get; set; }

        [FindsBy(How = How.Id, Using = "doneProductLine")]
        public IWebElement AddProductLineButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "total-product")]
        public IWebElement TotalProducts { get; set; }

        [FindsBy(How = How.Id, Using = "roomlocation")]

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'SEARCH')]")]
        public IWebElement Search { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'ORDER NUMBER')]")]
        public IWebElement SearchOrder { get; set; }

        [FindsBy(How = How.Id, Using = "orderNumber")]
        public IWebElement EnterOrder { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Search')]")]
        public IWebElement Enter { get; set; }

        [FindsBy(How = How.Id, Using = "roomlocation")]
        public IWebElement roomlocation { get; set; }

        [FindsBy(How = How.ClassName, Using = "product-line-summary")]
        public IWebElement sizeOfProductLine { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancelOrder")]
        public IWebElement CancelOrder { get; set; }

        [FindsBy(How = How.Id, Using = "text-CancellationReason")]
        public IWebElement CancelOrderReasons { get; set; }

        [FindsBy(How = How.Id, Using = "btnPopupCancelOrder")]
        public IWebElement CancelOrderPopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'CANCELLED')]")]
        public IWebElement DisabledAnchorClass { get; set; }

        public int implicitWait = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWait"]);
        public static ReasonsData ReadcancelReasonData(ParsedTestData featureData)
        {
            object cancelReasonData = DataAccess.GetKeyJsonData(featureData, "CancelOrderReasons");
            return JsonDataParser<ReasonsData>.ParseData(cancelReasonData);
        }

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
                int currentcount=precount++;
                _logger.Info($" Totl record added in payment grid {currentcount}");
                return true;

            }
            else {
                return false;
            }

        }


        public List<PaymentData> ExpectedDataForGridVerification()
        {
            List<PaymentData> ActualFilteredLosit = new List<PaymentData>();

            PaymentData savedCreditCardPaymentData = PaymentPage.GetSavedCreditCardPaymentData(SmokeSuite.paymentParsedData);
            ActualFilteredLosit.Add(savedCreditCardPaymentData);
            PaymentData creditCardPaymentData = PaymentPage.GetCreditCardPaymentData(SmokeSuite.paymentParsedData);
            ActualFilteredLosit.Add(creditCardPaymentData);
            PaymentData checkPaymentData = PaymentPage.GetCheckPaymentData(SmokeSuite.paymentParsedData);
            ActualFilteredLosit.Add(checkPaymentData);
            PaymentData giftCardPaymentData = PaymentPage.GetGiftCardPaymentData(SmokeSuite.paymentParsedData);
            ActualFilteredLosit.Add(giftCardPaymentData);
            PaymentData financePaymentData = PaymentPage.GetFinancePaymentData(SmokeSuite.paymentParsedData);
            ActualFilteredLosit.Add(financePaymentData);
            return ActualFilteredLosit;
        }

        /// <summary>
        /// Function to verifypayment grid data on order page
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean VerifyGridData(List<PaymentData> record)

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
                List<string> ActualFilteredLosit = new List<string>();

                int count = 0;
                bool isCredit = RowLosit.ToList().Exists(x => x.Equals("••••"));
                RowLosit.ToList().ForEach(x =>
                {
                    if (count== 3 && isCredit)
                    {
                        ActualFilteredLosit[1] += x;
                    }
                    else if (!x.Equals("••••") && !x.Equals(DateTime.Now.ToString("M/d/yyyy", CultureInfo.InvariantCulture)))
                    {
                        ActualFilteredLosit.Add(x);
                    }
                    count++;
                });
                record[counter].Amount = "$" + record[counter].Amount;

                if (((record[counter].PaymentMethod.Equals(ActualFilteredLosit[1])) && (record[counter].Amount.Equals(ActualFilteredLosit[4])) && (record[counter].Amount.Equals(ActualFilteredLosit[5]))))
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
            _logger.Info($" User clicked on add detail button");
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
            _logger.Info($" User clicked on new payment button");
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
                _logger.Info($" Maximun transaction has been reached verified on order scree by clicking on new payment button");
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
                _logger.Info($" Maximun transaction has been reached verified on order screen by clicking on refund ");
            }
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
           // ClickOnHamberger();
            return isWarningPopulated;

        }
        public OrderPage WaitUntilPageload()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loader-overlay-section']")));
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }

        public void CalculateNumberOfProductLinesBeforeOperation()
        {
            beforeCount = 0;
            int i = 2;
            do
            {
                WaitUntilPageload();
                driver.FindElement(By.XPath("//li[" + i + "]//div[2]//span[1]//div[1]"));
                beforeCount++;
                i++;
            } while (By.XPath("//li[" + i + "]//div[2]//span[1]//div[1]").isPresent(driver));

        }

        public OrderPage ClickOnhamburgerButton1()
        {
            //int count = CalculateNumberOfProductLinesBeforeCopy();
            driver.WaitForElementToBecomeVisibleWithinTimeout(HamburgerClick, 60);
            WaitUntilPageload();
            Thread.Sleep(8000);
            HamburgerClick.Clickme(driver);
            _logger.Info($" Click on hamburger.");
            return this;
        }

        public OrderPage ClickOnCopyButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(CopyProductLine, 60);
            CopyProductLine.Clickme(driver);
            _logger.Info($" Clicked on Copy Product Line.");
            return this;
        }

        public OrderPage ClickAddProductButton()
        {
            Thread.Sleep(8000);
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("doneProductLine")));
            AddProductLineButton.Clickme(driver);
            _logger.Info($": ADD LINE button clicked");
            return this;
        }


        public void CalculateNumberOfProductLinesAfterOperation()
        {
            afterCount = 0;
            //afterCount = Convert.ToInt32(sizeOfProductLine.) - 1;
            int i = 2;
            do
            {
                WaitUntilPageload();
                driver.FindElement(By.XPath("//li[" + i + "]//div[2]//span[1]//div[1]"));
                afterCount++;
                i++;
            } while (By.XPath("//li[" + i + "]//div[2]//span[1]//div[1]").isPresent(driver));

        }

        public bool VerifyTotalProductsAfterCopy()
        {

            if ((afterCount - beforeCount) == 1)
                return true;
            else
                return false;

        }


    }
}
