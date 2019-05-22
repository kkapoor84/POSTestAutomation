﻿using NLog;
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
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using UnitTestNDBProject.Base;
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
       // Constants objectConstant = new Constants();

        

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

        [FindsBy(How = How.XPath, Using = "//div[@class='Select default-select-dropdown has-value is-clearable is-searchable Select--single']")]
        public IWebElement UpdateDeliveryType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='deliveryType']")]
        public IWebElement UpdateDeliveryTypeIsFocused { get; set; }

        [FindsBy(How = How.Id, Using = "save-quote")]
        public IWebElement SaveOrder { get; set; }

        [FindsBy(How = How.Id, Using = "btnShipmentEdit")]
        public IWebElement EditShipmentDetails { get; set; }

        [FindsBy(How = How.Id, Using = "shippingOption-0")]
        public IWebElement ShipmentDetailsOptions { get; set; }

        [FindsBy(How = How.Id, Using = "btnDone")]
        public IWebElement DoneOnShippingPopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='gutter-sm-top']")]
        public IWebElement SectionName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='total-product']")]
        public IWebElement ProductTotal { get; set; }


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

        public OrderPage NavigateToTopOfTheOrderPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-1500)");
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

        public OrderPage  ClickOnhamburgerButton1()
        {
            //int count = CalculateNumberOfProductLinesBeforeCopy();
            driver.WaitForElementToBecomeVisibleWithinTimeout(HamburgerClick, 60);
            WaitUntilPageload();
            Thread.Sleep(8000);
            HamburgerClick.Clickme(driver);
            _logger.Info($" Click on hamburger.");
            return this;
        }

        public OrderPage ClickOnhamburgerButton2()
        {
            //int count = CalculateNumberOfProductLinesBeforeCopy();
            driver.WaitForElementToBecomeVisibleWithinTimeout(HamburgerClick, 60);
            WaitUntilPageload();
            Thread.Sleep(8000);
            HamburgerClick2.Clickme(driver);
            _logger.Info($" Click on hamburger.");
            return this;
        }

        public void  CalculateNumberOfProductLinesBeforeOperation()
        {
            beforeCount = 0;
             int i=2;
            do
            {
                WaitUntilPageload();
                driver.FindElement(By.XPath("//li["+i+"]//div[2]//span[1]//div[1]"));
                beforeCount++;
                i++;
            } while (By.XPath("//li[" + i + "]//div[2]//span[1]//div[1]").isPresent(driver));

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

        public OrderPage ClickOnEditButton()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditProductLine,implicitWait);
            EditProductLine.Clickme(driver);
            _logger.Info($" Clicked on Edit Product Line.");
            return this;
        }

        public OrderPage EnterRoomLocation(string RoomLocation)
        {

            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, implicitWait);
            roomlocation.EnterText(RoomLocation);
            _logger.Info($": Successfully entered room location {RoomLocation}");
            return this;
        }

        public OrderPage SelectProductOptionsEdit(List<EditProductDetail> editProductDetails)
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Mounting")));

            foreach (EditProductDetail editProduct in editProductDetails)
            {
                driver.FindElement(By.Id(editProduct.OptionTypeId)).EnterText(editProduct.Option);
                driver.FindElement(By.Id(editProduct.OptionTypeId)).SendKeys(Keys.Enter);
                _logger.Info($": Successfully updated Option {editProduct.Option} for Option Type {editProduct.OptionTypeId}");
                Thread.Sleep(500);
            }
            return this;
        }
        public void EditProductLineConfiguration(List<DataDictionary> editproductLineData)
        {
            foreach (DataDictionary data in editproductLineData)
            {
                EditProductLineData editProductLine = JsonDataParser<EditProductLineData>.ParseData(data.Value);
                Thread.Sleep(4000);
                EnterRoomLocation(editProductLine.NDBRoomLocation)
                    .SelectProductOptionsEdit(editProductLine.EditProductDetails).ClickAddProductButton();
            }
        }

            public bool VerifyTotalProductsAfterCopy()
        {

           if ((afterCount - beforeCount) == 1)
                return true;
            else
                return false;

        }

        public bool VerifyTotalProductsAfterDelete()
        {
            if ((beforeCount - afterCount) == 1)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        public OrderPage DeleteProductLine()
        {
            WaitUntilPageload();
            driver.FindElement(By.XPath("(//ul[@class='action-popup']//span[text()='DELETE'])[2]")).Clickme(driver);
            OkButton.Clickme(driver);
            return this;
        }

        public OrderPage WaitUntilPageload()
        {
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }

        /// <summary>
        /// Click On Cancel Order Button
        /// </summary>
        /// <returns></returns>
        public OrderPage ClickOnCancelOrderButton()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(CancelOrder, 10000);
            CancelOrder.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Enter Cancel Reasons
        /// </summary>
        /// <param name="reasons"></param>
        /// <returns></returns>
        public OrderPage EnterCancelOrderReasons(string reasons)
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(CancelOrderReasons, 10000);
            driver.WaitForElement(CancelOrderReasons);
            CancelOrderReasons.EnterText(reasons);
            return this;
        }

        /// <summary>
        /// Click On Cancel Popup
        /// </summary>
        /// <returns></returns>
        public OrderPage ClickOnCancelOrderPopup()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(CancelOrderPopup, 10000);
            CancelOrderPopup.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Verify cancel Order
        /// </summary>
        /// <returns></returns>
        public bool VerifyCancelOrder()
        {
            WaitUntilPageload();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-200)");
            driver.WaitForElementToBecomeVisibleWithinTimeout(DisabledAnchorClass, 10000);
            bool isOrderCancelled = false;
            String orderHeading = DisabledAnchorClass.GetText(driver);

            if (orderHeading.Contains("CANCELLED"))
            {
                isOrderCancelled = true;
                _logger.Info($"Verified order is cancelled.");
            }

            return isOrderCancelled;

        }

        public OrderPage SearchFunctionForOrder()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            _logger.Info($" User clicked on search button on top navigation panel");
            SearchOrder.Clickme(driver);
            _logger.Info($" User clicked on search for order tab on search page");
            //  EnterOrder.EnterText("2013543");
            EnterOrder.EnterText("2013804");
            _logger.Info($" User entered quote{2013804}");
            Enter.Clickme(driver);
            _logger.Info($" User clicked on search button");
            WaitUntilPageload();
            _logger.Info($" Waited for loader gets loaded");
            Thread.Sleep(1000);
            return this;
        }

        /// <summary>
        /// Updating delivery type from delivery type dropdown
        /// </summary>
        /// <returns></returns>
        public OrderPage UpdateDeliveryTypeFromDropDown()
        {
            WaitUntilPageload();
            UpdateDeliveryType.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Function to set delivery type to shipping
        /// </summary>
        /// <returns></returns>
        public OrderPage SetDeliveryTypeToShipping()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(UpdateDeliveryTypeIsFocused, implicitWait);
            UpdateDeliveryTypeIsFocused.EnterText(Constants.ShippingDeliveryType);
            UpdateDeliveryTypeIsFocused.SendKeys(Keys.Enter);
            return this;
        }

        /// <summary>
        /// function to click on Edit button of shipping options
        /// </summary>
        /// <returns></returns>
        public OrderPage EditDeliveryOptions()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditShipmentDetails, implicitWait);
            EditShipmentDetails.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Function to verify atleast one delivery type is populated
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyDeliveryOptionsPopulated()
        {
            WaitUntilPageload();
            //driver.WaitForElementToBecomeVisibleWithinTimeout(ShipmentDetailsOptions, implicitWait);
            Boolean deliveryOptionsPopulated = false;
            if (By.Id("shippingOption-0").isPresent(driver))
            {
                deliveryOptionsPopulated = true;
            }
            return deliveryOptionsPopulated;

        }

        /// <summary>
        /// function to save changes after updating delivery type
        /// </summary>
        /// <returns></returns>
        public OrderPage SaveChangesToshippingOption()
        {
            WaitUntilPageload();
            driver.WaitForElementToBecomeVisibleWithinTimeout(DoneOnShippingPopup, implicitWait);
            DoneOnShippingPopup.Clickme(driver);
            WaitUntilPageload();
            return this;
        }

        /// <summary>
        /// Function to click on Save Order Button
        /// </summary>
        /// <returns></returns>
        public OrderPage SaveOrderButton()
        {
            WaitUntilPageload();         
            driver.WaitForElementToBecomeVisibleWithinTimeout(SaveOrder, implicitWait);
            SaveOrder.Clickme(driver);
            return this;
        }


        /// <summary>
        /// Function to verify shipping details
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyShippingSection()
        {
            WaitUntilPageload();
            Boolean shippingSectionIsAvailable = false;
            String sectionNameOnScreen = SectionName.GetText(driver);
            if (sectionNameOnScreen.Contains(Constants.ShippingDeliveryType))
            {
                shippingSectionIsAvailable = true;
            }
            return shippingSectionIsAvailable;
        }


    /// <summary>
    /// Function to verify shipping option Edit button is enabled.
    /// </summary>
    /// <returns></returns>
        public Boolean VerifyShippingSectionEditButtonIsEnabled()
        {
            WaitUntilPageload();
            Boolean editShippingButton = false;
            if (By.Id("btnShipmentEdit").isPresent(driver))
            {
                editShippingButton = true;
            }
            return editShippingButton;
        }

        /// <summary>
        /// Function to verify if products are not install only only then to update the delivery options
        /// </summary>
        /// <returns></returns>
        public OrderPage UpdateDeliveryTypeToShipping()
        {
            WaitUntilPageload();
            if (By.Id("idBtnOK").isPresent(driver))
            {
                OkButton.Clickme(driver);                
            }
            else
            {
                Assert.True(VerifyShippingSectionEditButtonIsEnabled());
                EditDeliveryOptions();
                Assert.True(VerifyDeliveryOptionsPopulated());
                SaveChangesToshippingOption();
                Assert.True(VerifyShippingSection());
            }               
            return this;
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
                    if (count == 3 && isCredit)
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
        /// Listing All the key data of PaymentScreen
        /// </summary>
        /// <returns></returns>
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
        /// Function to get the total product number before copying quote from order page
        /// </summary>
        /// <returns></returns>
        public OrderPage GetProductTotalBeforeCopyingQuote()
        {
            driver.WaitForElement(ProductTotal);

            String Value = ProductTotal.GetText(driver);
            Constants.ProductTotal = Value;
            return this;
        }

    }
}
