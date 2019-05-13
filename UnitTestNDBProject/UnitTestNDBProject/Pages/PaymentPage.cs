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
using UnitTestNDBProject.Page;
using OpenQA.Selenium.Interactions;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Page
{
    public class PaymentPage
    {
        public IWebDriver driver;
        private Logger _logger = LogManager.GetCurrentClassLogger();
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-cash']")]
        private IWebElement CashButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'FINANCING')]")]
        private IWebElement FinanceButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'CHECK')]")]
        private IWebElement CheckButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'CREDIT CARD')]")]
        private IWebElement CreditCardButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'NDB GIFT CARD')]")]
        private IWebElement GiftCardButton { get; set; }

        [FindsBy(How = How.Id, Using = "GiftCardNumber")]
        private IWebElement GiftCardNumber { get; set; }

        

        [FindsBy(How = How.Id, Using = "amountPosting")]
        private IWebElement AmountTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "btnPaymentDone")]
        private IWebElement ProcessPaymentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='home-icon']")]
        private IWebElement HomeIcon { get; set; }

        [FindsBy(How = How.Id, Using = "btnCancel")]
        private IWebElement CancleButton { get; set; }

        [FindsBy(How = How.Id, Using = "exitPaymentId")]
        private IWebElement ExitPaymentScreenButton { get; set; }

        [FindsBy(How = How.Id, Using = "text-shortDeposit")]
        private IWebElement ExitReasonTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "btnShortDeposit")]
        private IWebElement ExitPopupContiueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='msg-container']")]
        private IWebElement GreenBanner { get; set; }

        [FindsBy(How = How.Id, Using = "FinanceAccountNumberLast4Digits")]
        private IWebElement AccountNo { get; set; }

        [FindsBy(How = How.Id, Using = "text-AuthorizationCode")]
        private IWebElement AuthorizationCode { get; set; }

        [FindsBy(How = How.Id, Using = "text-paymentDetail")]
        private IWebElement ReasonDetailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "exitPaymentReasonsId")]
        private IWebElement ExitReasonDropDown { get; set; }


        [FindsBy(How = How.Id, Using = "btnExitPayment")]
        private IWebElement ExitPaymentButtonOnPopUp { get; set; }

        [FindsBy(How = How.Id, Using = "text-AccountName")]
        private IWebElement AccountName { get; set; }

        [FindsBy(How = How.Id, Using = "text-RoutingNumber")]
        private IWebElement RoutingNumber { get; set; }

        [FindsBy(How = How.Id, Using = "text-AccountNumber")]
        private IWebElement AccountNumber { get; set; }

        [FindsBy(How = How.Id, Using = "text-CheckNumber")]
        private IWebElement CheckNumber { get; set; }

        [FindsBy(How = How.Id, Using = "text-StateIdentificationNumber")]
        private IWebElement StateIDNumber { get; set; }

        [FindsBy(How = How.Id, Using = "StateIdentificationStateAbbreviation")]
        private IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "skipVerificationId")]
        private IWebElement CheckSkipVerification { get; set; }

        [FindsBy(How = How.Id, Using = "getCheckAuthorizationBypassReasonsId")]
        private IWebElement SkippingReason { get; set; }


        [FindsBy(How = How.Id, Using = "text-checkAuthorizationBypassComments")]
        private IWebElement SkippingDetails { get; set; }

        [FindsBy(How = How.Id, Using = "btnContinue")]
        private IWebElement SkippingPopupButtonContinue { get; set; }

        [FindsBy(How = How.Id, Using = "newCreditCardPaymentTypeId")]
        private IWebElement EnterNewCreditCardRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "savedCreditCardPaymentTypeId")]
        private IWebElement SavedCreditCardRadioButton { get; set; }
        

        [FindsBy(How = How.Id, Using = "CardNumber")]
        private IWebElement CreditCardNumber { get; set; }

        [FindsBy(How = How.Id, Using = "ExpirationMonth")]
        private IWebElement CreditExpirationMonth { get; set; }

        [FindsBy(How = How.Id, Using = "ExpirationYear")]
        private IWebElement CreditExpirationYear { get; set; }

        [FindsBy(How = How.Id, Using = "CVVCode")]
        private IWebElement CreditCVVCode { get; set; }

        [FindsBy(How = How.Id, Using = "CardholderName")]
        private IWebElement CreditCardHolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-space']/ul/li")]
        public  IWebElement WarningText { get; set; }

        

        public static PaymentData GetGiftCardPaymentData (ParsedTestData featureData)
        {
            object giftCardDataValue = DataAccess.GetKeyJsonData(featureData, "GiftCardKey");
            return JsonDataParser<PaymentData>.ParseData(giftCardDataValue);
        }

        public static PaymentData GetFinancePaymentData(ParsedTestData featureData)
        {
            object financeDataValue = DataAccess.GetKeyJsonData(featureData, "FinanceKey");
            return JsonDataParser<PaymentData>.ParseData(financeDataValue);
        }

        public static PaymentData GetCheckPaymentData(ParsedTestData featureData)
        {
            object checkDataValue = DataAccess.GetKeyJsonData(featureData, "CheckKey");
            return JsonDataParser<PaymentData>.ParseData(checkDataValue);
        }

        public static PaymentData GetCreditCardPaymentData(ParsedTestData featureData)
        {
            object creditCardDataValue = DataAccess.GetKeyJsonData(featureData, "CreditCardKey");
            return JsonDataParser<PaymentData>.ParseData(creditCardDataValue);
        }

        public static PaymentData GetSavedCreditCardPaymentData(ParsedTestData featureData)
        {
            object savedCreditCardDataValue = DataAccess.GetKeyJsonData(featureData, "SavedCreditCardKey");
            return JsonDataParser<PaymentData>.ParseData(savedCreditCardDataValue);
        }

        public static PaymentData GetPaymentGridData(ParsedTestData featureData)
        {
            object paymentGridDataValue = DataAccess.GetKeyJsonData(featureData, "PaymentGridKey");
            return JsonDataParser<PaymentData>.ParseData(paymentGridDataValue);
        }


        /// <summary>
        /// Function to  make payment using gift card
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public PaymentPage MakeGiftCardPayment(String Number,String Amount)
        {
            driver.WaitForElement(GiftCardButton);
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            GiftCardButton.Clickme(driver);
            _logger.Info($" User clicked on gift card button");
            GiftCardNumber.EnterText(Number);
            _logger.Info($" User entered gift card number");
            AmountTextBox.Clickme(driver);
            _logger.Info($" User clicked on amount text box");
            driver.waitForElementNotVisible("//label[@class='form-value']/span");
            
            AmountTextBox.EnterText(Amount);
            _logger.Info($" User entered amount in amount text box");
            ProcessPaymentButton.Clickme(driver);
            _logger.Info($" User clicked on process payment button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            driver.WaitForElement(OkButton);
            _logger.Info($" User clicked on ok button");
            OkButton.Clickme(driver);
            return this;

        }

        /// <summary>
        /// Function to  to close exit payment popup screen
        /// </summary>
        /// <returns></returns>
        public PaymentPage CloseExitPaymentPopup()
        {
            driver.waitForElementNotVisible("//div[@class='msg-container']");
            driver.WaitForElement(HomeIcon);
            HomeIcon.Clickme(driver);
            _logger.Info($" User clicked on ome icon");
            driver.WaitForElement(CancleButton);
            CancleButton.Clickme(driver);
            _logger.Info($" User clicked on cancle button of exit payment popup");
            return this;
        }

        /// <summary>
        /// Function to enter details in exit payment popup 
        /// </summary>
        /// <param name="exitreasonvalue"></param>
        /// <param name="reasondetail"></param>
        /// <returns></returns>
        public PaymentPage EnterDetailInExitPaymentPopup(String exitreasonvalue, String reasondetail)
        {
            driver.waitForElementNotVisible("//div[@class='msg-container']");

            driver.WaitForElement(ExitPaymentScreenButton);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].click();", ExitPaymentScreenButton);

            driver.WaitForElement(ExitReasonDropDown);
            Actions actions = new Actions(driver);
            actions.SendKeys(ExitReasonDropDown, exitreasonvalue).Build().Perform();
            ExitReasonDropDown.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Selected Aexist reason from drop down {exitreasonvalue}");
            ReasonDetailTextBox.EnterText(reasondetail);
            _logger.Info($": Successfully Entered reason detail");
            driver.WaitForElement(ExitPaymentButtonOnPopUp);
            ExitPaymentButtonOnPopUp.Clickme(driver);
            _logger.Info($": User clicked on exit payment button on popup");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");


            return this;
        }

        /// <summary>
        /// Function to click on exit payment screen button
        /// </summary>
        /// <param name="exitReason"></param>
        /// <returns></returns>
        public PaymentPage ClickOnExitPaymentScreenButton(String exitReason)
        {

            driver.WaitForElement(ExitPaymentScreenButton);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].click();", ExitPaymentScreenButton);
            _logger.Info($" User clicked on ExitPaymentScreenButton");
            driver.WaitForElement(ExitReasonTextBox);
            ExitReasonTextBox.EnterText(exitReason);
            _logger.Info($" User entered text in ExitReasonTextBox");

            driver.WaitForElement(ExitPopupContiueButton);
            ExitPopupContiueButton.Clickme(driver);
            _logger.Info($" User clicked on contiue button");

            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            return this;
        }
        /// <summary>
        /// Function to make payment using finance payment mode
        /// </summary>
        /// <param name="CashAmount"></param>
        /// <returns></returns>
        public PaymentPage MakeFinancePayment(String Amount)
        {

            driver.WaitForElement(FinanceButton);
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            FinanceButton.Clickme(driver);
            _logger.Info($" User clicked on finance button");
            AccountNo.EnterText(CommonFunctions.RandomString());
            _logger.Info($" User entered account number");
            AuthorizationCode.EnterText(CommonFunctions.RandomString());
            _logger.Info($" User entered authorization code");
            AmountTextBox.EnterText(Amount);
            _logger.Info($" User entered amount");
            ProcessPaymentButton.Clickme(driver);
            _logger.Info($" Userclicked on process payment button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            _logger.Info($" User clicked on okay button");
            return this;

        }

        /// <summary>
        /// Function to make payment using check payment mode
        /// </summary>
        /// <param name="actName"></param>
        /// <param name="routingNo"></param>
        /// <param name="actNo"></param>
        /// <param name="checkNo"></param>
        /// <param name="stateId"></param>
        /// <param name="state"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public PaymentPage MakeCheckPayment(String actName, String routingNo, String actNo, String checkNo, String stateId, String state,String amount)
        {

            driver.WaitForElement(CheckButton);
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            CheckButton.Clickme(driver);
            _logger.Info($": User clicked on check button");

            driver.WaitForElement(AccountName);
            AccountName.EnterText("Automation");
            _logger.Info($": Successfully Entered AccountName {"Automation"}");
            driver.WaitForElement(RoutingNumber);
            RoutingNumber.EnterText("123456780");
            _logger.Info($": Successfully Entered RoutingNumber ");
            driver.WaitForElement(AccountNumber);
            AccountNumber.EnterText("1234567890");
            _logger.Info($": Successfully Entered AccountNumber");
            driver.WaitForElement(CheckNumber);
            CheckNumber.EnterText("1234567890");
            _logger.Info($": Successfully Entered CheckNumber ");
            driver.WaitForElement(StateIDNumber);
            StateIDNumber.EnterText("1234567890");
            _logger.Info($": Successfully Entered StateIDNumber ");

            driver.WaitForElement(State);
            Actions actions = new Actions(driver);
            actions.SendKeys(State, "AK - Alaska").Build().Perform();
            State.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Entered State");

            AmountTextBox.EnterText(amount);
            _logger.Info($": Successfully Entered Check amount{amount}");
            return this;
        }
        /// <summary>
        /// Function to select verificattion for check and addd detail on popup
        /// </summary>
        /// <param name="skipReason"></param>
        /// <param name="skipDetail"></param>
        /// <returns></returns>
        public PaymentPage SelectSkipVerification(String skipReason, String skipDetail)
        { 
            CheckSkipVerification.Clickme(driver);
            Actions actions = new Actions(driver);
            driver.WaitForElement(SkippingReason);
            actions.SendKeys(SkippingReason, skipReason).Build().Perform();
            SkippingReason.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Entered Skiping Reason{skipReason}");
            SkippingDetails.EnterText(skipDetail);
            _logger.Info($": Successfully Entered Skipping Details{skipDetail} ");
            SkippingPopupButtonContinue.Clickme(driver);

            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            return this;

        }
        /// <summary>
        /// Function to make payment using manual credit card
        /// </summary>
        /// <param name="creditCardNo"></param>
        /// <param name="expirationMonth"></param>
        /// <param name="expirationYear"></param>
        /// <param name="cVVCode"></param>
        /// <param name="creditCardHolder"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public PaymentPage MakeCreditCardPayment(String creditCardNo, String expirationMonth, String expirationYear, String cVVCode, String creditCardHolder,String amount)
        {

            driver.WaitForElement(CreditCardButton);
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            CreditCardButton.Clickme(driver);
            _logger.Info($": User clciked on credit card button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");

            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //This will scroll the page till the element is found		
            ex.ExecuteScript("arguments[0].scrollIntoView();", EnterNewCreditCardRadioButton);
            EnterNewCreditCardRadioButton.Clickme(driver);
            _logger.Info($": User clciked on enter new credit card button");
            driver.WaitForElement(CreditCardNumber);
            CreditCardNumber.EnterText(creditCardNo);
            _logger.Info($": User entered credit card number");
            Actions actions = new Actions(driver);
            driver.WaitForElement(CreditExpirationMonth);
            actions.SendKeys(CreditExpirationMonth, expirationMonth).Build().Perform();
            CreditExpirationMonth.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Entered Expiration Month");


            driver.WaitForElement(CreditExpirationYear);
            actions.SendKeys(CreditExpirationYear, expirationYear).Build().Perform();
            CreditExpirationYear.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Entered Expiration Year");

            driver.WaitForElement(CreditCVVCode);
            CreditCVVCode.EnterText(cVVCode);
            _logger.Info($": User entered CVVCode ");
            driver.WaitForElement(CreditCardHolder);
            CreditCardHolder.EnterText(creditCardHolder);
            _logger.Info($": User entered credit card holder name");
            AmountTextBox.EnterText(amount);
            ProcessPaymentButton.Clickme(driver);
            _logger.Info($": User clicked on process payment button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            _logger.Info($": User clicked on Okay button");
            return this;


        }
        /// <summary>
        /// Function to make payment using saved credit card
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public PaymentPage MakeSavedCreditCardPayment(String amount)
        {

            driver.WaitForElement(CreditCardButton);
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            CreditCardButton.Clickme(driver);
            _logger.Info($": User clicked on credit card button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");

            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            //This will scroll the page till the element is found		
            ex.ExecuteScript("arguments[0].scrollIntoView();", SavedCreditCardRadioButton);
            SavedCreditCardRadioButton.Clickme(driver);
            _logger.Info($": User selected saved credit card radio button");
            AmountTextBox.EnterText(amount);
            _logger.Info($": User entered amount");
            ProcessPaymentButton.Clickme(driver);
            _logger.Info($": User clicked on process payment button");
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            return this;


        }
        /// <summary>
        /// Function to verify the max transaction warning tax popup on payment screen
        /// </summary>
        /// <param name="expWarningMessage"></param>
        /// <returns></returns>
        public Boolean VerifyMaxTransWarningOnPaymentScreen(String expWarningMessage)
        {

            bool isWarningPopulated = false;
            driver.WaitForElement(WarningText);

            String ActualWarningMessageForMaxiumumTransaction = WarningText.GetText(driver);

            if (expWarningMessage.Equals(ActualWarningMessageForMaxiumumTransaction))
            {
                isWarningPopulated = true;
                _logger.Info($" Maximun transaction has been reached poup is verified on payment screen");
            }
            driver.WaitForElement(OkButton);
            OkButton.Clickme(driver);
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            return isWarningPopulated;

        }

        
    }
}
