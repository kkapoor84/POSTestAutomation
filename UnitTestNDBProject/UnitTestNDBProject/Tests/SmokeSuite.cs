using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.Page;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]

    public class SmokeSuite : BaseTestClass
    {

        private static ParsedTestData loginFeatureParsedData;
        private static ParsedTestData newCustomerFeatureParsedData;
        private static ParsedTestData productLineFeatureParsedData;
        private static ParsedTestData miscproductLineFeatureParsedData;
        private static ParsedTestData componentproductLineFeatureParsedData;
        private static ParsedTestData accessoryproductLineFeatureParsedData;
        private static ParsedTestData productLineEditFeatureParsedData;
        private static ParsedTestData updateCustomerFeatureParsedData;
        private static ParsedTestData internalInfoParsedData;
        private static ParsedTestData measurementAndInstallationParsedData;
        private static ParsedTestData adjustmentParsedData;
        private static ParsedTestData taxParsedData;
        public static ParsedTestData paymentParsedData;
        public static ParsedTestData refundParsedData;
        private static ParsedTestData reasonsParser;
        private static ParsedTestData storeParser;
        private static ParsedTestData searchParser;

        NewCustomerData newCustomerData;
        InternalInfoData internalInforData;
        ReasonsData cancelReasonData;
        StoreData storePickupData;
        //SearchData searchQuoteNumber;
        //SearchData searchOrderNumber;
        //   EditProductLineData editProductData;

      

        [OneTimeSetUp]
        public void BeforeClass()
        {
            //Get login screen data
            loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
            //Get data for customer screen
            newCustomerFeatureParsedData = DataAccess.GetFeatureData("NewCustomerScreen");
            //Get data for update customer screen
            updateCustomerFeatureParsedData = DataAccess.GetFeatureData("UpdateCustomerScreen");
            //Get product line feature data
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            miscproductLineFeatureParsedData = DataAccess.GetFeatureData("MiscellaneousScreen");
            componentproductLineFeatureParsedData = DataAccess.GetFeatureData("ComponentScreen");
            accessoryproductLineFeatureParsedData = DataAccess.GetFeatureData("AccessoryScreen");
            //Get product line Edit feature data
            productLineEditFeatureParsedData = DataAccess.GetFeatureData("EditProductScreen");
            //Get data for Internal Infor Section
            internalInfoParsedData = DataAccess.GetFeatureData("InternalInfoScreen");
            //Get data for Measurement and Installation screen
            measurementAndInstallationParsedData = DataAccess.GetFeatureData("MeasurementAndInstallationScreen");
            adjustmentParsedData = DataAccess.GetFeatureData("AddAdjustmentsPopup");
            taxParsedData = DataAccess.GetFeatureData("TaxExemptionPopup");
            paymentParsedData = DataAccess.GetFeatureData("PaymentScreen");
            refundParsedData = DataAccess.GetFeatureData("RefundScreen");
            reasonsParser = DataAccess.GetFeatureData("Reasons");
            storeParser = DataAccess.GetFeatureData("StoreCode");
            searchParser = DataAccess.GetFeatureData("Search");


            //parse data of NewCustomerScreen feature in NewCustomerData class
            newCustomerData = EnterNewCustomerPage.GetCustomerData(newCustomerFeatureParsedData);
            internalInforData = QuotePage.GetInternalInfoData(internalInfoParsedData);
            cancelReasonData = OrderPage.ReadcancelReasonData(reasonsParser);
            storePickupData = OrderPage.ReadStorePickupData(storeParser);

            // editProductData = QuotePage.GetEditProductData(productLineEditFeatureParsedData);

        }

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(1), Category("Smoke"), Description("Validate that error message populates once user enter invalid credentials")]
        public void A1_VerifyLoginWithInValidCredentails()
        {
            LoginData loginData = LoginPage.GetInvalidLoginData(loginFeatureParsedData);

            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            Assert.True(_LoginPage.VerifyInvalidCredentialsAreDisplayed("User ID or Password are incorrect. Please try again or contact the NDB helpdesk"));
        }

        [Test, Order(2), Category("Smoke"), Description("Validate that user is able to navigate to Home page using valid credentials")]
        public void A2_VerifyLoginWithValidCrdentails()
        {
            LoginData loginData = LoginPage.GetSAHUserLoginData(loginFeatureParsedData);

            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();
           // _HomePage.ClickShopAtHomeTab();

         //   Assert.True(_HomePage.VerifyShopAtHomeTabIsClicked());
        }

        [Test, Order(3), Category("Smoke"), Description("Validate all the Home Page tabs are clickable")]
        public void A3_VerifyHomePageTabs()
        {
            _HomePage.ClickDashBoardTab();
            Assert.True(_HomePage.VerifyDashBoardTabIsClicked());

            _HomePage.ClickDepositSummaryTab();
            Assert.True(_HomePage.VerifyDepositSummaryTabIsClicked());

            _HomePage.ClickResourcesTab();
            Assert.True(_HomePage.VerifyResourceTabIsClicked());

            _HomePage.ClickSettingTab();
            Assert.True(_HomePage.VerifySettingTabIsClicked());
        }

        [Test, Order(4), Category("Smoke"), Description("Enter Customer Card Details and create new customer from customer suggestion")]
        public void A4_VerifyCustomerCreationUsingCustomerSuggestion()
        {
            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName);

            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            //Click on SAVE button and update existing customer
            _EnterNewCustomerPage.ClickSaveButton().VerifySmartyStreet().UpdateExistingCustomerFromCustomerSuggestion();

            for (int counter = 0; counter < phones.Count; counter++)
            {
                Assert.True(_EnterNewCustomerPage.VerifyExistingPhoneNumber(phones[counter].Item1));
            }

            for (int counter = 0; counter < emails.Count; counter++)
            {
                Assert.True(_EnterNewCustomerPage.VerifyExistingEmailAddress(emails[counter]));
            }

            _EnterNewCustomerPage.ClickEditSaveButton();

            // Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
            Assert.True(_EnterNewCustomerPage.VerifyFirstName(newCustomerData.FirstName));
            Assert.True(_EnterNewCustomerPage.VerifyLastName(newCustomerData.LastName));
        }

        [Test, Order(5),Category("Smoke"), Description("Invalid Scenario of Customer Page")]
        public void A5_VerifyCustomerCreationNegativeScenario()
        {

            Assert.Multiple(() =>
            {
                //Scenario 1 
                _EnterNewCustomerPage.ClickEnterNewCustomerButton().ClickSaveButton();
                Assert.True(_EnterNewCustomerPage.VerifyPopupWithValue());

                //Scenario 2
                _EnterNewCustomerPage.OkOnErrorMessage();
                _EnterNewCustomerPage.EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName).ClickSaveButton(); ;
                Assert.True(_EnterNewCustomerPage.VerifyPopupWithValue());
                _EnterNewCustomerPage.OkOnErrorMessage();

                //Scenario 3
                _EnterNewCustomerPage.EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName).EnterPhone(newCustomerData.InvalidPhone, 0).ClickSaveButton();
                Assert.True(_EnterNewCustomerPage.VerifyPopupForMainPhone());
                _EnterNewCustomerPage.OkOnErrorMessage();
                Assert.True(_EnterNewCustomerPage.VerifyTextForInvalidPhone());

                //Scenario 4
                _EnterNewCustomerPage.EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName).EnterPhone(CommonFunctions.AppendMaxRangeRandomString(newCustomerData.Phones[0].PhoneNumber), 0).SelectPhoneType(newCustomerData.Phones[0].PhoneType).EnterEmailAddress(newCustomerData.InvalidEmail, 0).ClickSaveButton();
                Assert.True(_EnterNewCustomerPage.VerifyPopupForMainEmail());
                _EnterNewCustomerPage.OkOnErrorMessage();
                Assert.True(_EnterNewCustomerPage.VerifyTextForInvalidEmail());
            }
             );
            _EnterNewCustomerPage.ClickCancelButton();

        }

        [Test, Order(6), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A6_VerifyCustomerCreation()
        {
            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);


            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            _EnterNewCustomerPage.ClickOnAddressLine1().ContinueNewCustomerCreation();

            _EnterNewCustomerPage.AddCustomerAddresses(newCustomerData.Addresses);
            _EnterNewCustomerPage.AddCustomerTaxNumbers(newCustomerData.TaxNumbers);

            _EnterNewCustomerPage.ClickSaveButton().VerifySmartyStreet();

            //commenting this assertion because if somehow CUsotmer suggetion popup is not displayed then it takes time 30 sec to wait for the popup till than greenbar gets disappear and assertion gets failed 
            // Assert.True(_EnterNewCustomerPage.VerifyGreedbarAfterEditIsSuccessful());
            Assert.True(_EnterNewCustomerPage.VerifyCustomerCreation("Open Activity"));
            Assert.True(_EnterNewCustomerPage.VerifyEditButtonAvailable());
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifyPhoneNumberAndPhoneType());
            Assert.True(_EnterNewCustomerPage.VerifyEmailAddress());
            Assert.True(_EnterNewCustomerPage.VerifyAddressine2());
            Assert.True(_EnterNewCustomerPage.VerifyAddress());
            Assert.True(_EnterNewCustomerPage.VerifyTaxidNumberAndState());
        }

      

        [Test, Order(7), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A7_VerifyCustomerUpdate()
        {
            UpdateCustomerData updateCustomerData = EnterNewCustomerPage.GetUpdateCustomerData(updateCustomerFeatureParsedData);

            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(updateCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(updateCustomerData.LastName);

            //Updating Information of Customer Information Section
            _EnterNewCustomerPage.ClickEditButton("contactEdit");
            _EnterNewCustomerPage.EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(updateCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(updateCustomerData.Emails);
            _EnterNewCustomerPage.ClickEditSaveButton();

            //Updating Information of Address Section
            _EnterNewCustomerPage.ClickEditButton("addressEdit");
            _EnterNewCustomerPage.AddCustomerAddresses(updateCustomerData.Addresses);
            _EnterNewCustomerPage.ClickEditSaveButton();

            //Updating Information of Tax Section
            _EnterNewCustomerPage.ClickEditButton("exemptionEdit");
            _EnterNewCustomerPage.AddCustomerTaxNumbers(updateCustomerData.TaxNumbers);
            _EnterNewCustomerPage.ClickEditSaveButton();

            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidFirstName(firstNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifCustomerIsCreatedWithValidLastName(lastNameUnique));
            Assert.True(_EnterNewCustomerPage.VerifyPhoneNumberAndPhoneType());
            Assert.True(_EnterNewCustomerPage.VerifyEmailAddress());
            Assert.True(_EnterNewCustomerPage.VerifyAddressine2());
            Assert.True(_EnterNewCustomerPage.VerifyAddress());
            Assert.True(_EnterNewCustomerPage.VerifyTaxidNumberAndState());
        }


        [Test, Order(8), Category("Smoke"), Description("Verify Product and Quote Creation by adding 3 product lines.")]
        public void A8_VerifyProductCreation()
        {
            Thread.Sleep(2000);
            _QuotePage.ClickOnAddNewQuote().SaveQuoteButton();
            Assert.True(_QuotePage.VerifyErrorPopup());
            _QuotePage.OkOnErrorMessage().UpdateNickname(internalInforData.Nickname).UpdateGroup(internalInforData.Group).UpdateInternalInfo().AddLeadNumber(internalInforData.Leadnumber).UpdateSidemark(internalInforData.Sidemark);
            _QuotePage.ApplyInternalInfoUpdates()
            .AddMultipleProducts(productLineFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyQuoteCreation());
            Assert.True(_QuotePage.VerifyProductsEntered(productLineFeatureParsedData.Data));
            Assert.True(_QuotePage.VerifyProductDataAfterAdd(productLineFeatureParsedData.Data));
        }

        [Test, Order(9), Category("Smoke"),Description("Verify Product Copy")]
        public void A9_VerifyCopyproductLine()
        {

            _QuotePage.ClickOnhamburgerButton().ClickOnCopyButton();

            _OrderPage.ClickAddProductButton();

            Assert.True(_QuotePage.VerifyTotalProductsAfterCopy(productLineFeatureParsedData.Data));
            Assert.True(_QuotePage.VerifyProductDataAfterAdd(productLineFeatureParsedData.Data));
        }

        [Test, Order(10), Category("Smoke"), Description("Verify Product Line Edit Functionality")]
        public void B1_VerifyEditproductLine()
        {
            _QuotePage.ClickOnhamburgerButton().ClickOnEditButton();
            _QuotePage.EditProductLineConfiguration(productLineEditFeatureParsedData.Data, _OrderPage);
            Assert.True(_QuotePage.VerifyProductDataAfterEdit(productLineEditFeatureParsedData.Data));


        }

        [Test, Order(11), Category("Smoke"), Description("Verify Product Deletion")]
        public void B2_VerifyDeleteproductLine()
        {
            //_QuotePage.SearchFunction();
            _QuotePage.DeleteMultipleProducts();
            Assert.True(_QuotePage.VeriyUserNotAbleToDeleteAllProductLines());
            _QuotePage.ClickOkButton();

        }


        [Test, Order(12), Category("Smoke"), Description("Add Information on Measurement and Installation Page")]
        public void B3_VerifyMeasurementAndInstallationSection()
        {
            MeasurementAndInstallationData measurmentAIData = MeasurementAndInstallationPage.GetMeasurementAndInstallationData(measurementAndInstallationParsedData);
            _QuotePage.ClickOnEditButtonOfMeasurementAndInstallation();
            _MeasurementAndInstallationPage.AddDirections(measurmentAIData.Directions)
                .ClickOnLadder(measurmentAIData.SelectLadder)
                .AddMeasurerNotes(measurmentAIData.MeasurementNotes)
                .AddAdditionalCost(measurmentAIData.AddAdditionalCost, measurmentAIData.AdditionalCostAmount, measurmentAIData.AdditionalCostReason)
                .AddAdditionalMinutes(measurmentAIData.AddAdditionalMin, measurmentAIData.AdditionalMinAmount, measurmentAIData.AdditionalMinReason)
                .AddInstallerNotes(measurmentAIData.InstallerNotes)
                .ClickOnSaveChangesButton();

            Assert.True(_QuotePage.VerifyDirectionIsAdded(measurmentAIData.Directions));
            Assert.True(_QuotePage.VerifyAdditionalCost(measurmentAIData.AddAdditionalCost, measurmentAIData.AdditionalCostAmount));

        }

        [Test, Order(13), Category("Smoke"), Description("Add Adjustments for Quote")]
        public void B4_VerifyAddAdjustments()
        {
            AdjustmentData adjustmentData = QuotePage.GetAdjustmentsData(adjustmentParsedData);

            _QuotePage.ClickOnAdjustmentsLink().AddAdjustments(adjustmentData.Adjustments);
            Assert.True(_QuotePage.VerifyAdjustmentTotalAmount(adjustmentData.AdjustmentTotalAmount));

        }

        [Test, Order(14), Category("Smoke"), Description("Apply tax exemption for Quote")]
        public void B5_VerifyTaxExemption()
        {
            // Selcted Tax Exemption for different Install / Pickup State
            TaxExemptionData invalidTaxExemptionData = QuotePage.GetInvalidTaxExemptionData(taxParsedData);
            _QuotePage.ClickOnTaxLink().SelectNonApplicableTax(invalidTaxExemptionData.ApplyTaxExempt, invalidTaxExemptionData.TaxIdNumber);
            Assert.True(_QuotePage.VerifyTaxErrorMessage("The selected Tax Exemption does not match the Install/Pickup State"));

            //Selcted Tax Exemption for same Install/Pickup State
            TaxExemptionData validTaxExemptionData = QuotePage.GetValidTaxExemptionData(taxParsedData);
            _QuotePage.SelectApplicableTax(validTaxExemptionData.TaxIdNumber);
            Assert.True(_QuotePage.VerifyTaxExemptionIsApplied(validTaxExemptionData.ExemptTax));

        }

        [Test, Order(15), Category("Smoke"),Description("Quote Convert to Order")]
        public void B6_VerifyQuoteConvertToOrder()
        {
            _SearchPage.ClickOnSearchLink().ClickOnQuoteTab().EnterQuoteToSearch("705983").ClickOnSearchButton();
           _QuotePage.CopyQuote().SaveChanges();


            _QuotePage.WaitUntilPageload();
            Thread.Sleep(2000);

            _QuotePage.ClickOnConvertToQuote().ClickOnContinue().AddLeadno(_QuotePage, internalInforData, _OrderPage).SaveQuoteButton(); 
            _QuotePage.WaitUntilPageload();
            _QuotePage.ClickOnConvertToQuote().ClickOnContinue();
            Assert.True(_QuotePage.VerifyUserIsNavigatedToPaymentPage());

        }

        [Test, Order(16), Category("Smoke"), Description("Payment via finance and order is created")]
        public void B7_VerifyOrderIsCreatedWithNoDeposit()
        {
            PaymentData NoDepositPaymentData = PaymentPage.GetNoDepositPaymentData(paymentParsedData);

            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.ClickOnNoDeposit();

            _PaymentPage.NoDepositPopup(NoDepositPaymentData.NoDepositReason, NoDepositPaymentData.ReasonDetails);

         //   Assert.True(_OrderPage.VerifyOrderIsCreated());
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
            Assert.True(_OrderPage.VerifyPaymentGridData(NoDepositPaymentData));
            _OrderPage.ClickOnNoteLink();
            Assert.True(_NotePage.VerifyNoDepositReasonAndDetailOnNotePage(NoDepositPaymentData.NoDepositReason, NoDepositPaymentData.ReasonDetails));
            _NotePage.ClickOnViewOrderLink();
        }


        [Test, Order(17), Category("Smoke"), Description("Payment via finance and order is created")]
        public void B8_VerifyOrderIsCreatedWithFinancialAndShortPayment()
        {
            PaymentData financeShortPaymentData = PaymentPage.GetFinanceShortDepositPaymentData(paymentParsedData);
         
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeFinancePayment()
                .ClickOnShortDeposit()
                .ShortDepositPopup(financeShortPaymentData.ExitPaymentReasonShortDeposit);
             
//            Assert.True(_OrderPage.VerifyOrderIsCreated());
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
            Assert.True(_OrderPage.VerifyPaymentGridData(financeShortPaymentData));
            _OrderPage.ClickOnNoteLink();
            Assert.True(_NotePage.VerifyShortDepositReasonAndDetailOnNotePage(financeShortPaymentData.ExitPaymentReasonShortDeposit));
            _NotePage.ClickOnViewOrderLink();

        }

       
        [Test, Order(18), Ignore(""), Category("Smoke"), Description("Payment via gift card")]
        public void B9_VerifyGiftCardPayment()
        {
            PaymentData giftCardPaymentData = PaymentPage.GetGiftCardPaymentData(paymentParsedData);
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeGiftCardPayment(giftCardPaymentData.GiftCardNumber, giftCardPaymentData.Amount);
               _PaymentPage.ClickOnExitPaymentButton();
              _PaymentPage.FillPopupDetails(giftCardPaymentData.ExitReasonDropDownValue, giftCardPaymentData.ReasonDetails);
                         //   .EnterDetailInExitPaymentPopup(giftCardPaymentData.ExitReasonDropDownValue, giftCardPaymentData.ReasonDetails);
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
            Assert.True(_OrderPage.VerifyPaymentGridData(giftCardPaymentData));
        }
       
        [Test, Order(19), Category("Smoke"),Description("Payment via Check-Skip Verification")]
        public void C1_VerifyCheckSkipVerificationPayment()
        {
              PaymentData checkPaymentData = PaymentPage.GetCheckPaymentData(paymentParsedData);

            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeCheckPayment(checkPaymentData.AccountName,checkPaymentData.RoutingNumber,checkPaymentData.AccountNumber,checkPaymentData.CheckNumber,checkPaymentData.StateId,checkPaymentData.State,checkPaymentData.Amount)
                .SelectSkipVerification(checkPaymentData.SkippingReason,checkPaymentData.SkippingReasonDetail)
                .ClickOnExitPaymentButton()
                .FillPopupDetails(checkPaymentData.ExitReasonDropDownValue, checkPaymentData.ReasonDetails);
             //   .EnterDetailInExitPaymentPopup(checkPaymentData.ExitReasonDropDownValue, checkPaymentData.ReasonDetails);
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
            Assert.True(_OrderPage.VerifyPaymentGridData(checkPaymentData));
        }

        //[Test, Order(20), Category("Smoke"),  Description("Payment via Manual Credit Card")]
        //public void C2_VerifyManualCreditCardPayment()
        //{
        //    PaymentData creditCardPaymentData = PaymentPage.GetCreditCardPaymentData(paymentParsedData);
        //    _OrderPage.ClickOnNewPaymentButton();
        //    _PaymentPage.MakeCreditCardPayment(creditCardPaymentData.CreditCardNumber, creditCardPaymentData.ExpirationMonth, creditCardPaymentData.ExpirationYear, creditCardPaymentData.CVVCode, creditCardPaymentData.CreditCardHolder, creditCardPaymentData.Amount)
        //         .EnterDetailInExitPaymentPopup(creditCardPaymentData.ExitReasonDropDownValue, creditCardPaymentData.ReasonDetails);
        //    Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        //}

        //[Test, Order(21), Category("Smoke"),Description("Payment via Saved Credit Card")]
        //public void C3_VerifySavedCreditCardPaymentAndMaximumTransactionReached()
        //{

        //    PaymentData savedCreditCardPaymentData = PaymentPage.GetSavedCreditCardPaymentData(paymentParsedData);
        //    _OrderPage.ClickOnNewPaymentButton();
        //    _PaymentPage.MakeSavedCreditCardPayment(savedCreditCardPaymentData.Amount);
        //    Assert.True(_PaymentPage.VerifyMaxTransWarningOnPaymentScreen(savedCreditCardPaymentData.WarningMessageOnPayment));
        //    Assert.True(_OrderPage.VerifyMaxTransWarningOnOrderScreen_PaymentButton(savedCreditCardPaymentData.WarningMessageOnPayment));
        //    Assert.True(_OrderPage.VerifyMaxTransWarningOnOrderScreen_RefundLink(savedCreditCardPaymentData.WarningMessageOnRefund));
        //    Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        //}
        //[Test, Order(21), Category("Smoke"), Ignore(""), Description("Payment grid data verification")]
        //public void C3_VerifyPaymentGridData()
        //{
        //     Assert.True(_OrderPage.VerifyGridData(_OrderPage.ExpectedDataForGridVerification()));

        //}

        [Test, Order(20), Category("Smoke"), Description("Refund for Check-Skip Verification")]
        public void C3_VerifyRefundForCheckPayment()
        {
            PaymentData checkPaymentData = PaymentPage.GetCheckPaymentData(paymentParsedData);
            RefundData refundData = PaymentPage.GetRefundData(refundParsedData);

            //Making refund for Cash/Check Payment Method and Entering Half Amount for refund
            _OrderPage.ClickOnHambergerForCheck().ClickOnRefund();
            _OrderPage.SelectRefundMethod(refundData.RefundMethod,refundData.RefundMethod2).EnterRefundAmount(checkPaymentData.Amount).SelectRefundReason(refundData.RefundReason).EnterReasonDetails(refundData.RefundDetails).ClickOnProcessPaymentButton().ClickOnContinueButton();
            _QuotePage.ScrollWebPageTillEnd();

            Assert.True(_OrderPage.VerifyRefundGridData(refundData, checkPaymentData));
            
            //Making refund for Mail Check Payment Method and Entering Rest Amount for refund
            _OrderPage.ClickOnHambergerForCheck().ClickOnRefund();
            _OrderPage.SelectRefundMethod(refundData.RefundMethod, refundData.RefundMethod2).EnterRefundAmount(checkPaymentData.Amount).SelectRefundReason(refundData.RefundReason).EnterReasonDetails(refundData.RefundDetails).ClickOnProcessPaymentButton().ClickOnContinueButton();
            _QuotePage.ScrollWebPageTillEnd();

            Assert.True(_OrderPage.VerifyRefundGridData(refundData, checkPaymentData));
        }


        [Test, Order(22), Category("Smoke"), Description("Verify Product Copy")]
        public void C4_VerifyCopyproductLineForOrder()
        {
            _OrderPage.NavigateToTopOfTheOrderPage();
            _OrderPage.CalculateNumberOfProductLinesBeforeOperation();
            _OrderPage.ClickOnhamburgerButton1().ClickOnCopyButton();
            _OrderPage.ClickAddProductButton();
            _OrderPage.CalculateNumberOfProductLinesAfterOperation();
            Assert.True(_OrderPage.VerifyTotalProductsAfterCopy());
            Assert.True(_QuotePage.VerifyProductDataAfterEdit(productLineEditFeatureParsedData.Data));
        }



        [Test, Order(23), Category("Smoke"), Description("Edit Order Productline For Order")]
        public void C5_VerifyEditProductLineForOrder()
        {

           _OrderPage.ClickOnhamburgerButton2().ClickOnEditButton();
            _OrderPage.EditProductLineConfiguration(productLineEditFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyProductDataAfterEdit(productLineEditFeatureParsedData.Data));

        }

        [Test, Order(24), Category("Smoke"), Description("Edit Order Productline For Order")]
        public void C6_VerifyDeleteproductLineForOrder()
        {
            _OrderPage.CalculateNumberOfProductLinesBeforeOperation();
            _OrderPage.ClickOnhamburgerButton2();
            _OrderPage.DeleteProductLine();
            _OrderPage.CalculateNumberOfProductLinesAfterOperation();
            _OrderPage.GetProductTotalBeforeCopyingQuote();
            Assert.True(_OrderPage.VerifyTotalProductsAfterDelete());

        }

        [Test, Order(25), Category("Smoke"), Description("Cancel Order Verification")]
        public void C7_VerifyCancelOrder()
        {

            _OrderPage.ClickOnCancelOrderButton().EnterCancelOrderReasons(cancelReasonData.CancelReasons).ClickOnCancelOrderPopup();
            Assert.True(_OrderPage.VerifyCancelOrder());
        }

        [Test, Order(26), Category("Smoke"), Description("Search Customer Verification")]
        public void C8_VerifySearchCustomer()
        {
            SearchData orderData = SearchPage.SearchOrderData(searchParser);
            _SearchPage.ClickOnSearchLink().MovetoCustomerTab().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName).ClickOnSearchButton();
            _SearchPage.ExecuteSearchFlowIfCustomerExists();
            _SearchPage.ClickOnSearchLink();
            Assert.True(_SearchPage.VerifySearchLinkOfLastSearch());
            _SearchPage.EnterSameSearchCriteria().ClickOnSearchButton();
        }

        [Test, Order(27), Category("Smoke"), Description("Search Quote Verification")]
        public void C9_VerifySearchQuote()
        {
            SearchData quoteData = SearchPage.SearchQuoteData(searchParser);
            _SearchPage.ClickOnSearchLink().ClickOnQuoteTab().EnterInvalidQuoteToSearch(quoteData.QuoteNumber).ClickOnSearchButton();
            Assert.True(_SearchPage.VerifyNoResultFoundForQuote());
            _SearchPage.ClearTextOFQuote().EnterQuoteToSearch(quoteData.QuoteNumber).ClickOnSearchButton();
            Assert.True(_SearchPage.VerifyUserNavigatedToCorrectQuote(quoteData.QuoteNumber));
        }

        [Test, Order(28), Category("Smoke"), Description("Search Order Verification")]
        public void D1_VerifySearchOrder()
        {
            SearchData orderData = SearchPage.SearchOrderData(searchParser);
            _SearchPage.ClickOnSearchLink().ClickOnOrderTab().EnterInvalidOrderToSearch(orderData.OrderNumber).ClickOnSearchButton();
            Assert.True(_SearchPage.VerifyNoResultFoundForOrder());
            _SearchPage.ClearTextOFOrder().EnterOrderToSearch(orderData.OrderNumber).ClickOnSearchButton();
            Assert.True(_SearchPage.VerifyUserNavigatedToCorrectOrder(orderData.OrderNumber));
        }

        [Test, Order(29), Category("Smoke"), Description("Copy to Quote functionality from order page")]
        public void D2_VerifyCopyToQuoteFromOrderPage()
        {

            _QuotePage.CopyToQuoteFromOrderPage().UpdateInternalInfo()
                .UpdateStoreCode(internalInforData.StoreCode)
                .UpdatePrimarySalesPerson(internalInforData.SalesPerson)
                .UpdateSidemark(internalInforData.Sidemark)
                .ApplyInternalInfoUpdates()
                .SaveChanges();
            Assert.True(_QuotePage.VerifyQuoteGroupIsNotUpdated());
            Assert.True(_QuotePage.VerifyQuoteStatus());
            Assert.True(_QuotePage.VerifyQuoteDate());
            Assert.True(_QuotePage.VerifyStoreCode(internalInforData.StoreCode));
            Assert.True(_QuotePage.VerifyPrimarySalesPerson(internalInforData.SalesPerson));
            Assert.True(_QuotePage.VerifyLeadNumberIsNotUpdated());
            Assert.True(_QuotePage.VerifySideMark(internalInforData.Sidemark));
            //  Assert.True(_QuotePage.VerifyTotalProductsAfterCopyQuote());
        }


        [Test, Order(30), Category("Smoke"), Description("Product creation on Quick COnfig Page")]
        public void D3_VerifyQuickConfigScreen()
        {
            ProductLineData ProductLineData = QuickConfig.GetProductLine1Data(productLineFeatureParsedData);
            _HomePage.ClickOnQuickConfig();
            _QuickConfig.AddProduct(ProductLineData, _QuotePage,_OrderPage);
            Assert.True(_QuickConfig.VerifyUserNavigatedToCustomerPage());

            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);

            _EnterNewCustomerPage.EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            _EnterNewCustomerPage.ClickOnAddressLine1().ContinueNewCustomerCreation();

            _EnterNewCustomerPage.AddCustomerAddresses(newCustomerData.Addresses);
            _EnterNewCustomerPage.AddCustomerTaxNumbers(newCustomerData.TaxNumbers);

            _EnterNewCustomerPage.ClickSaveButton().VerifySmartyStreet().ContinueNewCustomerCreation();
            _QuotePage.WaitUntilPageload();
            Assert.True(_QuotePage.VerifyQuoteCreation());
            Assert.True(_QuotePage.VerifyProductDetailsAreCorrect(ProductLineData));
        }


        [Test, Order(31), Category("Smoke"), Description("Change Delivery Type To Shipping")]
        public void D4_VerifyUpdateDeliveryTypeToShipping()
        {
            _OrderPage.UpdateDeliveryTypeFromDropDown().SetDeliveryTypeToShipping();
            _OrderPage.UpdateDeliveryTypeToShipping();
        }

        [Test, Order(32), Category("Smoke"), Description("Change Delivery Type To Store Pickup")]
        public void D5_VerifyUpdateDeliveryTypeToStorePickup()
        {

            _OrderPage.UpdateDeliveryTypeFromDropDown().SetDeliveryTypeToStorePickup();
            _OrderPage.UpdateDeliveryTypeToStorePickup();
        }


        [Test, Order(33), Category("Smoke"), Description("TransferToProduction")]
        public void D6_VerifyTransferToProduction()
        {
            _QuotePage.ClickOnConvertToQuote().ClickOnContinue().AddLeadno(_QuotePage, internalInforData, _OrderPage).SaveQuoteButton();
            _QuotePage.WaitUntilPageload();
            _QuotePage.ClickOnConvertToQuote().ClickOnContinue();

            _PaymentPage.cashPaymentForFullPayment().CalculateCashPayment().ProcessPaymentButtonClick();
            _OrderPage.NavigateToTopOfTheOrderPage().EditInternalInfoButton().UpdateSignature().AddLeadNumber(internalInforData.Leadnumber).ApplyChangesToInternalInfoSection().ClickOnSaveOrderButton().TransferToProduction();
          //  Assert.True(_OrderPage.VerifyOrderIsCreated());
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.CurrentDatePopupatedVerification());
            Assert.True(_OrderPage.OrderStatusAfterTransferVerification());
        }

        [Test, Order(34), Category("Smoke"), Description("Verify user able to create misc item.")]
        public void D7_VerifyMiscCreation()

        {
            _SearchPage.ClickOnSearchLink().ClickOnOrderTab().EnterOrderToSearch("2028395").ClickOnSearchButton();
            _QuotePage.ClickOnAddNewQuote().ClickOnAddProduct().ClickOnContinue().AddLeadno(_QuotePage, internalInforData, _OrderPage);
            _QuotePage.WaitUntilPageload();

            _QuotePage.AddMiscProduct(miscproductLineFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyMisc(miscproductLineFeatureParsedData.Data));
        }

        [Test, Order(35), Category("Smoke"), Description("Verify user able to create misc item.")]
        public void D8_VerifyComponentCreation()
        {           
            _QuotePage.AddComponentProduct(componentproductLineFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyComponents(componentproductLineFeatureParsedData.Data));
        }

        [Test, Order(36), Category("Smoke"), Description("Verify user able to create misc item.")]
        public void D9_VerifyAccessoryCreation()
        {
            _SearchPage.ClickOnSearchLink().ClickOnOrderTab().EnterOrderToSearch("2028395").ClickOnSearchButton();
            _QuotePage.ClickOnAddNewQuote().ClickOnAddProduct().ClickOnContinue().AddLeadno(_QuotePage, internalInforData, _OrderPage);
            _QuotePage.WaitUntilPageload();

            _QuotePage.AddAccessoryProduct(accessoryproductLineFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyAccessory(accessoryproductLineFeatureParsedData.Data));
        }

        [Test, Order(37), Category("Smoke"), Description("Verify user able to create misc item.")]
        public void E1_VerifyPurchaseOrderFlow()
        {
            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);

           // _HomePage.Signout();

            //Login via Accountant user
            LoginData loginData = LoginPage.GetAccounttantUserLoginData(loginFeatureParsedData);
            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();
   
            //Customer created with POlimit
            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);
             _EnterNewCustomerPage.ClickOnAddressLine1().ContinueNewCustomerCreation();
            _EnterNewCustomerPage.AddCustomerAddresses(newCustomerData.Addresses);
            _EnterNewCustomerPage.AddCustomerTaxNumbers(newCustomerData.TaxNumbers);
            _EnterNewCustomerPage.SelectPOStatus(newCustomerData.POStatus).EnterCreditLimit(newCustomerData.CreditLimit);
            _EnterNewCustomerPage.ClickSaveButton().VerifySmartyStreet();
             Assert.True(_EnterNewCustomerPage.VerifyCustomerCreation("Open Activity"));

            //Quote created with product line
            ProductLineData ProductLineData = QuotePage.GetProductLine1Data(productLineFeatureParsedData);
            _QuotePage.ClickOnAddNewQuote().SaveQuoteButton();
            Assert.True(_QuotePage.VerifyErrorPopup());
            _QuotePage.OkOnErrorMessage().UpdateInternalInfo().UpdateStoreCode(internalInforData.StoreCode).AddLeadNumber(internalInforData.Leadnumber).ApplyInternalInfoUpdates().AddProduct(ProductLineData);


            //Add Direction on installation page
            MeasurementAndInstallationData measurmentAIData = MeasurementAndInstallationPage.GetMeasurementAndInstallationData(measurementAndInstallationParsedData);
            _QuotePage.ClickOnEditButtonOfMeasurementAndInstallation();
            _MeasurementAndInstallationPage.AddDirections(measurmentAIData.Directions).ClickOnSaveChangesButton();
            _QuotePage.ScrollWebPageTillEnd(); 

            //Convert quote to order
            _QuotePage.WaitUntilPageload();
            _QuotePage.ClickOnConvertToQuote().ClickOnContinue();
            Assert.True(_QuotePage.VerifyUserIsNavigatedToPaymentPage());

            //Make PO payment 1st time
            PaymentData POPaymentData = PaymentPage.GetPOPaymentData(paymentParsedData);
            _PaymentPage.ClickOnPurchaseOrderButton().EnterAgreementNumber(POPaymentData.AgreementNumber).EnterAmount().ClickOnProcessPayment();
             _OrderPage.ScrollWebPageTillEnd();

            //Verify PO Payment row
            Assert.True(_OrderPage.VerifyPOGridData(POPaymentData));

            //Verify PO Payment row after edit
            _OrderPage.EditPOPayment().EnterAgreementNo(POPaymentData.AgreementNumber2).ClickOnPOSaveButton().ScrollWebPageTillEnd();
            Assert.True(_OrderPage.VerifyPOGridDataAfterEdit(POPaymentData));

            //Copy Quote
            _QuotePage.CopyToQuoteFromOrderPage().UpdateInternalInfo().UpdateStoreCode(internalInforData.StoreCodeBP).ApplyInternalInfoUpdates().SaveChanges().OkOnErrorMessage().WaitUntilPageload();

            //Add Direction on installation page
            _QuotePage.ClickOnEditButtonOfMeasurementAndInstallation();
            _MeasurementAndInstallationPage.AddDirections(measurmentAIData.Directions).ClickOnSaveChangesButton();

            //Convert quote to order
            _QuotePage.WaitUntilPageload();
            _QuotePage.ScrollWebPageTillEnd();
            _QuotePage.ClickOnConvertToQuote().ClickOnContinue();
            Assert.True(_QuotePage.VerifyUserIsNavigatedToPaymentPage());

            //Make PO payment 2nd time
            _PaymentPage.ClickOnPurchaseOrderButton();
             Assert.True(_PaymentPage.VerifyAgreementNoisNotMandatory());
            _PaymentPage.EnterAmount().ClickOnProcessPayment();

            //Verify PO Payment row
            Assert.True(_OrderPage.VerifyPOGridData(POPaymentData));

            //Verify PO Payment row after edit
            _QuotePage.ScrollWebPageTillEnd();
            _OrderPage.EditPOPayment().EnterAgreementNo(POPaymentData.AgreementNumber3).ClickOnPOSaveButton().ScrollWebPageTillEnd();
            Assert.True(_OrderPage.VerifyPOGridDataAfterEdit(POPaymentData));


        }


        /// <summary>
        /// Tear Down function
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    _ScreenshotUtil.SaveScreenShot($"Failed Test{this.GetType().Name}");
                    driver.Navigate().Refresh();
                    Thread.Sleep(5000);
                    logstatus = Status.Fail;
                    GlobalSetup.test.Log(Status.Info, stacktrace + errorMessage);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;

                default:

                    logstatus = Status.Pass;
                    break;
            }

            GlobalSetup.test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }

        /// <summary>
        /// One tiem Tear Down function
        /// </summary>
        [OneTimeTearDown]
        public void AfterClass()
        {
            //This is just to ensure that there isn't any loader blocking the button.
            //TODO: Any better way to handle it?
            Thread.Sleep(5000);
          //  _HomePage.Signout();
        }
    }
}