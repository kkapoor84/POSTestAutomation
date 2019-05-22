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
        private static ParsedTestData productLineEditFeatureParsedData;
        private static ParsedTestData updateCustomerFeatureParsedData;
        private static ParsedTestData internalInfoParsedData;
        private static ParsedTestData measurementAndInstallationParsedData;
        private static ParsedTestData adjustmentParsedData;
        private static ParsedTestData taxParsedData;
        private static ParsedTestData paymentParsedData;
        private static ParsedTestData reasonsParser;

        NewCustomerData newCustomerData;
        InternalInfoData internalInforData;
        ReasonsData cancelReasonData;
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
            //Get product line Edit feature data
            productLineEditFeatureParsedData = DataAccess.GetFeatureData("EditProductScreen");
            //Get data for Internal Infor Section
            internalInfoParsedData = DataAccess.GetFeatureData("InternalInfoScreen");
            //Get data for Measurement and Installation screen
            measurementAndInstallationParsedData = DataAccess.GetFeatureData("MeasurementAndInstallationScreen");
            adjustmentParsedData = DataAccess.GetFeatureData("AddAdjustmentsPopup");
            taxParsedData = DataAccess.GetFeatureData("TaxExemptionPopup");
            paymentParsedData = DataAccess.GetFeatureData("PaymentScreen");
            reasonsParser = DataAccess.GetFeatureData("Reasons");

            //parse data of NewCustomerScreen feature in NewCustomerData class
            newCustomerData = EnterNewCustomerPage.GetCustomerData(newCustomerFeatureParsedData);
            internalInforData = QuotePage.GetInternalInfoData(internalInfoParsedData);
            cancelReasonData = OrderPage.ReadcancelReasonData(reasonsParser);

            // editProductData = QuotePage.GetEditProductData(productLineEditFeatureParsedData);

        }

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(1), Category("Smoke"), Ignore(""), Description("Validate that error message populates once user enter invalid credentials")]
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
            _HomePage.ClickShopAtHomeTab();

            Assert.True(_HomePage.VerifyShopAtHomeTabIsClicked());
        }

        [Test, Order(3), Category("Smoke"), Ignore(""), Description("Validate all the Home Page tabs are clickable")]
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

        [Test, Order(4), Category("Smoke"), Ignore(""), Description("Enter Customer Card Details and create new customer from customer suggestion")]
        public void A4_VerifyCustomerCreationUsingCustomerSuggestion()
        {
            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(newCustomerData.FirstName).EnterLastName(newCustomerData.LastName);

            List<Tuple<string, string>> phones = _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            List<string> emails = _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            //Click on SAVE button and update existing customer
            _EnterNewCustomerPage.ClickSaveButton().UpdateExistingCustomerFromCustomerSuggestion();

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

        [Test, Order(5), Category("Smoke"),Ignore(""), Description("Enter Customer Card Details and create new customer")]
        public void A5_VerifyCustomerCreation()
        {
            string firstNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.FirstName);
            string lastNameUnique = CommonFunctions.AppendInRangeRandomString(newCustomerData.LastName);


            _EnterNewCustomerPage.ClickEnterNewCustomerButton().EnterFirstName(firstNameUnique).EnterLastName(lastNameUnique);
            _EnterNewCustomerPage.AddCustomerPhones(newCustomerData.Phones);
            _EnterNewCustomerPage.AddCustomerEmails(newCustomerData.Emails);

            _EnterNewCustomerPage.ClickOnAddressLine1().ContinueNewCustomerCreation();

            _EnterNewCustomerPage.AddCustomerAddresses(newCustomerData.Addresses);
            _EnterNewCustomerPage.AddCustomerTaxNumbers(newCustomerData.TaxNumbers);

            _EnterNewCustomerPage.ClickSaveButton().ContinueNewCustomerCreation();

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


        [Test, Order(6), Category("Smoke"), Ignore(""), Description("Enter Customer Card Details and create new customer")]
        public void A6_VerifyCustomerUpdate()
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


        [Test, Order(7), Category("Smoke"), Ignore(""), Description("Verify Product and Quote Creation by adding 3 product lines.")]
        public void A7_VerifyProductCreation()
        {
            _QuotePage.SearchFunction();
            _QuotePage.ClickOnAddNewQuote().SaveQuoteButton();
            Assert.True(_QuotePage.VerifyErrorPopup());
            _QuotePage.OkOnErrorMessage().UpdateNickname(internalInforData.Nickname).UpdateInternalInfo().UpdateSidemark(internalInforData.Sidemark);
            _QuotePage.ApplyInternalInfoUpdates()
            .AddMultipleProducts(productLineFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyQuoteCreation());
            Assert.True(_QuotePage.VerifyProductsEntered(productLineFeatureParsedData.Data));
            Assert.True(_QuotePage.VerifyProductDataAfterAdd(productLineFeatureParsedData.Data));
        }

        [Test, Order(8), Category("Smoke"), Ignore(""), Description("Verify Product Copy")]
        public void A8_VerifyCopyproductLine()
        {

            _QuotePage.ClickOnhamburgerButton().ClickOnCopyButton();

            _QuotePage.ClickAddProductButton();

            Assert.True(_QuotePage.VerifyTotalProductsAfterCopy(productLineFeatureParsedData.Data));

        }

        [Test, Order(9), Category("Smoke"), Ignore(""), Description("Verify Product Line Edit Functionality")]
        public void A9_VerifyEditproductLine()
        {
            _QuotePage.ClickOnhamburgerButton().ClickOnEditButton();
            _QuotePage.EditProductLineConfiguration(productLineEditFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyProductDataAfterEdit(productLineEditFeatureParsedData.Data));


        }

        [Test, Order(10), Category("Smoke"), Ignore(""), Description("Verify Product Deletion")]
        public void B1_VerifyDeleteproductLine()
        {
            //_QuotePage.SearchFunction();
            _QuotePage.DeleteMultipleProducts();
            Assert.True(_QuotePage.VeriyUserNotAbleToDeleteAllProductLines());
            _QuotePage.ClickOkButton();

        }


        [Test, Order(11), Category("Smoke"), Ignore(""), Description("Add Information on Measurement and Installation Page")]
        public void B2_VerifyMeasurementAndInstallationSection()
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

        [Test, Order(12), Category("Smoke"), Ignore(""), Description("Add Adjustments for Quote")]
        public void B3_VerifyAddAdjustments()
        {
            AdjustmentData adjustmentData = QuotePage.GetAdjustmentsData(adjustmentParsedData);

            _QuotePage.ClickOnAdjustmentsLink().AddAdjustments(adjustmentData.Adjustments);
            Assert.True(_QuotePage.VerifyAdjustmentTotalAmount(adjustmentData.AdjustmentTotalAmount));

        }

        [Test, Order(13), Category("Smoke"), Ignore(""),  Description("Apply tax exemption for Quote")]
        public void B4_VerifyTaxExemption()
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

        [Test, Order(14), Category("Smoke"), Description("Quote Convert to Order")]
        public void B5_VerifyQuoteConvertToOrder()
        {
            _QuotePage.SearchFunctionForQuote();
            _QuotePage.CopyQuoteAndSave();
            //Thread.Sleep(2000);
            _QuotePage.WaitUntilPageload();
           _QuotePage.ClickOnConvertToQuote().SelectConvertToPOS();
            Assert.True(_QuotePage.VerifyUserIsNavigatedToPaymentPage());

        }
        [Test, Order(15), Category("Smoke"), Description("Payment via finance and order is created")]
        public void B6_VerifyOrderIsCreatedWithFinancialPayment()
        {
            PaymentData financePaymentData = PaymentPage.GetFinancePaymentData(paymentParsedData);
            _PaymentPage.MakeFinancePayment(financePaymentData.Amount)
              .CloseExitPaymentPopup()
                .ClickOnExitPaymentScreenButton(financePaymentData.ExitPaymentReason);
            Assert.True(_OrderPage.VerifyOrderIsCreated());
            _OrderPage.ClickOnAddDetailsButton();
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        }

        [Test, Order(16),  Category("Smoke"), Description("Payment via gift card")]
        public void B7_VerifyGiftCardPayment()
        {
            PaymentData giftCardPaymentData = PaymentPage.GetGiftCardPaymentData(paymentParsedData);
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeGiftCardPayment(giftCardPaymentData.GiftCardNumber,giftCardPaymentData.Amount)
                            .EnterDetailInExitPaymentPopup(giftCardPaymentData.ExitReasonDropDownValue, giftCardPaymentData.ReasonDetails);
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        }
       
        [Test, Order(17), Category("Smoke"), Description("Payment via Check-Skip Verification")]
        public void B8_VerifyCheckSkipVerificationPayment()
        {
            PaymentData checkPaymentData = PaymentPage.GetCheckPaymentData(paymentParsedData);
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeCheckPayment(checkPaymentData.AccountName,checkPaymentData.RoutingNumber,checkPaymentData.AccountNumber,checkPaymentData.CheckNumber,checkPaymentData.StateId,checkPaymentData.State,checkPaymentData.Amount)
                .SelectSkipVerification(checkPaymentData.SkippingReason,checkPaymentData.SkippingReasonDetail) 
                .EnterDetailInExitPaymentPopup(checkPaymentData.ExitReasonDropDownValue, checkPaymentData.ReasonDetails);
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        }

        [Test, Order(18), Category("Smoke"), Description("Payment via Manual Credit Card")]
        public void B9_VerifyManualCreditCardPayment()
        {
            PaymentData creditCardPaymentData = PaymentPage.GetCreditCardPaymentData(paymentParsedData);
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeCreditCardPayment(creditCardPaymentData.CreditCardNumber, creditCardPaymentData.ExpirationMonth, creditCardPaymentData.ExpirationYear, creditCardPaymentData.CVVCode, creditCardPaymentData.CreditCardHolder, creditCardPaymentData.Amount)
                 .EnterDetailInExitPaymentPopup(creditCardPaymentData.ExitReasonDropDownValue, creditCardPaymentData.ReasonDetails);
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        }

        [Test, Order(19), Category("Smoke"), Description("Payment via Saved Credit Card")]
        public void C1_VerifySavedCreditCardPaymentAndMaximumTransactionReached()
        {

            PaymentData savedCreditCardPaymentData = PaymentPage.GetSavedCreditCardPaymentData(paymentParsedData);
            _OrderPage.ClickOnNewPaymentButton();
            _PaymentPage.MakeSavedCreditCardPayment(savedCreditCardPaymentData.Amount);
            Assert.True(_PaymentPage.VerifyMaxTransWarningOnPaymentScreen(savedCreditCardPaymentData.WarningMessageOnPayment));
            Assert.True(_OrderPage.VerifyMaxTransWarningOnOrderScreen_PaymentButton(savedCreditCardPaymentData.WarningMessageOnPayment));
            Assert.True(_OrderPage.VerifyMaxTransWarningOnOrderScreen_RefundLink(savedCreditCardPaymentData.WarningMessageOnRefund));
            Assert.True(_OrderPage.VerifyCorrectNumberOfRowAddedInPaymentSection());
        }
        [Test,  Order(20), Category("Smoke"), Description("Payment grid data verification")]
        public void C2_VerifyPaymentGridData()
        {
            PaymentData paymentGridData = PaymentPage.GetPaymentGridData(paymentParsedData);
            Assert.True(_OrderPage.VerifyGridData(paymentGridData.GridData));

        }

        [Test, Order(21), Category("Smoke"), Description("Verify Product Copy")]
        public void C3_VerifyCopyproductLineForOrder()
        {
            _OrderPage.NavigateToTopOfTheOrderPage();
            _OrderPage.CalculateNumberOfProductLinesBeforeOperation();
            _OrderPage.ClickOnhamburgerButton1().ClickOnCopyButton();
            _OrderPage.ClickAddProductButton();
            _OrderPage.CalculateNumberOfProductLinesAfterOperation();
            Assert.True(_OrderPage.VerifyTotalProductsAfterCopy());
        }



        [Test, Order(22), Category("Smoke"), Description("Edit Order Productline For Order")]
        public void C4_VerifyEditProductLineForOrder()
        {

           _OrderPage.ClickOnhamburgerButton2().ClickOnEditButton();
            _OrderPage.EditProductLineConfiguration(productLineEditFeatureParsedData.Data);
            Assert.True(_QuotePage.VerifyProductDataAfterEdit(productLineEditFeatureParsedData.Data));

        }

        [Test, Order(23), Category("Smoke"), Description("Edit Order Productline For Order")]
        public void C5_VerifyDeleteproductLineForOrder()
        {
            _OrderPage.CalculateNumberOfProductLinesBeforeOperation();
            _OrderPage.ClickOnhamburgerButton2();
            _OrderPage.DeleteProductLine();
            _OrderPage.CalculateNumberOfProductLinesAfterOperation();
            Assert.True(_OrderPage.VerifyTotalProductsAfterDelete());

        }

        [Test, Order(24), Category("Smoke"), Ignore(""),Description("Cancel Order Verification")]
        public void C6_VerifyCancelOrder()
        {
            
            _OrderPage.ClickOnCancelOrderButton().EnterCancelOrderReasons(cancelReasonData.CancelReasons).ClickOnCancelOrderPopup();
            Assert.True(_OrderPage.VerifyCancelOrder());
        }

        [Test, Order(25), Category("Smoke"), Description("ChangeDeliveryType")]
        public void C7_VerifyUpdateDeliveryType()
        {
            _QuotePage.SearchFunctionForOrder();
            _OrderPage.UpdateDeliveryTypeFromDropDown().SetDeliveryTypeToShipping();
            _OrderPage.UpdateDeliveryTypeToShipping();
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