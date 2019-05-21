using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.TestDataAccess;
using SeleniumExtras.PageObjects;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;

namespace UnitTestNDBProject.Page
{
    public class QuotePage
    {

        public IWebDriver driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //private static ParsedTestData productLineFeatureParsedData;
        //private static ParsedTestData productLineEditFeatureParsedData;
        //List<Tuple<string, string>> productDetails;
       // List<Tuple<string, string>> editProductDetails;

        public QuotePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='focus-on-edit']")]
        public IWebElement InternalInfo { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='text-undefined']")]
        public IWebElement Sidemark { get; set; }

        [FindsBy(How = How.Id, Using = "text-nickName")]
        public IWebElement NickName { get; set; }



        [FindsBy(How = How.Id, Using = "applyQuote")]
        public IWebElement InternalInfoApply { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'SEARCH')]")]
        public IWebElement Search { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'ORDER NUMBER')]")]
        public IWebElement SearchOrder { get; set; }

        [FindsBy(How = How.Id, Using = "orderNumber")]
        public IWebElement EnterOrder { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Search')]")]
        public IWebElement Enter { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn-outline-big quote-btn enterNewQuote pointer')]")]
        public IWebElement AddNewQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='addProductButtonId']")]
        public IWebElement AddProductLine { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='SelectedWidth']")]
        public IWebElement Width { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='SelectedHeight']")]
        public IWebElement Height { get; set; }

        [FindsBy(How = How.Id, Using = "roomlocation")]
        public IWebElement roomlocation { get; set; }

        [FindsBy(How = How.Id, Using = "ProductCode")]
        public IWebElement ProductCode { get; set; }

        [FindsBy(How = How.Id, Using = "doneProductLine")]
        public IWebElement AddProductLineButton { get; set; }

        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.Id, Using = "save-quote")]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "scroll-quote-actions")]
        public IWebElement QuoteActions { get; set; }

        [FindsBy(How = How.ClassName, Using = "total-product")]
        public IWebElement TotalProducts { get; set; }

        [FindsBy(How = How.ClassName, Using = "//li[2]//div[3]")]
        public IWebElement ProductNameOnScreen { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='dot-btn'])[1]")]
        public IWebElement HamburgerClick { get; set; }

        [FindsBy(How = How.XPath, Using = "(//ul[@class='action-popup']//span[text()='COPY'])[1]")]
        public IWebElement CopyProductLine { get; set; }

        [FindsBy(How = How.XPath, Using = "(//ul[@class='action-popup']//span[text()='EDIT'])[1]")]
        public IWebElement EditProductLine { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'You cannot delete all products.')]")]
        public IWebElement DeleteAllProductLine { get; set; }

        [FindsBy(How = How.Id, Using = "addressAndContact")]
        public IWebElement EditButtonOfAddress { get; set; }



        [FindsBy(How = How.XPath, Using = "(//span[@class='user-info'])[2]")]
        public IWebElement DirectionText { get; set; }

        [FindsBy(How = How.Id, Using = "btnDone")]
        public IWebElement AdjustmentsDoneButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//li[@class='row'])[2]//span[2]")]
        public IWebElement AdditionalCostView { get; set; }

        [FindsBy(How = How.Id, Using = "btnAdjustments")]
        public IWebElement AdjustmentsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row full-height']//li[2]//span")]
        public IWebElement AdjustmentVIew { get; set; }

        


        [FindsBy(How = How.Id, Using = "btnTax")]
        public IWebElement TaxButton { get; set; }

        [FindsBy(How = How.Id, Using = "Tax-Exempt")]
        public IWebElement TaxExemptCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "ddlTaxId")]
        public IWebElement TaxNumberDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement DoneButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='has-error-message']")]
        public IWebElement TaxErrorMessage { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='row full-height']//li[3]//span[1]")]
        public IWebElement TaxView { get; set; }

        [FindsBy(How = How.Id, Using = "btnConvertToOrder")]
        public IWebElement ConvertToOrderButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@class='btn-outline']")]
        public IWebElement ContinueButton { get; set; }

        [FindsBy(How = How.Id, Using = "radio-btn-convert")]
        public IWebElement ConvertToPOS { get; set; }

        [FindsBy(How = How.Id, Using = "idBtnContinueConvertToOrder")]
        public IWebElement ContinueConvertToOrder { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'PAYMENT TYPE')]")]
        public IWebElement PaymentScreenText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'QUOTE NUMBER')]")]
        public IWebElement SearchQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='quoteNumber']")]
        public IWebElement EnterOuote { get; set; }

        [FindsBy(How = How.Id, Using = "quoteGrp")]
        public IWebElement QuoteGroup { get; set; }

        [FindsBy(How = How.Id, Using = "leadNumberInput")]
        public IWebElement LeadNo { get; set; }

        

        public List<Tuple<string, string>> editedDataForProductLine;

        public int implicitWait = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWait"]);

        public QuotePage SearchFunction()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            Thread.Sleep(3000);
            SearchQuote.Clickme(driver);
            EnterOuote.EnterText("704098");
            Enter.Clickme(driver);
            Thread.Sleep(3000);
            return this;
        }


        /// <summary>
        /// Function to parse internal info data.
        /// </summary>
        /// <param name="featureData"></param>
        /// <returns></returns>

        public static InternalInfoData GetInternalInfoData(ParsedTestData featureData)
        {
            object internalInfoFeatureData = DataAccess.GetKeyJsonData(featureData, "InternalInfoSection");
            return JsonDataParser<InternalInfoData>.ParseData(internalInfoFeatureData);
        }

        public static AdjustmentData GetAdjustmentsData(ParsedTestData featureData)
        {
            object adjustmentPopData = DataAccess.GetKeyJsonData(featureData, "AdjustmentKey");
            return JsonDataParser<AdjustmentData>.ParseData(adjustmentPopData);
        }

        public static TaxExemptionData GetValidTaxExemptionData(ParsedTestData featureData)
        {
            object validTaxData = DataAccess.GetKeyJsonData(featureData, "ValidTax");
            return JsonDataParser<TaxExemptionData>.ParseData(validTaxData);
        }

        public static TaxExemptionData GetInvalidTaxExemptionData(ParsedTestData featureData)
        {
            object validTaxData = DataAccess.GetKeyJsonData(featureData, "InvalidTax");
            return JsonDataParser<TaxExemptionData>.ParseData(validTaxData);
        }



        /// <summary>
        /// Function to click save quote button.
        /// </summary>
        /// <returns></returns>
        public QuotePage SaveQuoteButton()
        {
            Thread.Sleep(4000);
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, SaveButton, 120);
            SaveButton.Clickme(driver);
            _logger.Info($": Successfully clicked save quote button.");
            return this;
        }

        /// <summary>
        /// Warning popup Ok button click.
        /// </summary>
        /// <returns></returns>
        public QuotePage OkOnErrorMessage()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, OkButton, 60);
            OkButton.Clickme(driver);
            return this;
        }


        /// <summary>
        /// Verifying Error popup is displayed.
        /// </summary>
        /// <returns></returns>
        public bool VerifyErrorPopup()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, OkButton, 60);
            bool errorPopup = false;
            if (OkButton.Displayed)
            {
                errorPopup = true;
                _logger.Info($" Error Popup Is Displayed.");
            }

            return errorPopup;

        }

        /// <summary>
        /// Function to provide nickname
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>


        public QuotePage UpdateNickname(String nickname)
        {
            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(NickName, 10000);
            NickName.EnterText(nickname);
            _logger.Info($": Successfully added quote nickname as {nickname}");
            return this;
        }

        /// <summary>
        /// Function to provide quote group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>

        public QuotePage UpdateGroup(String group)
        {

            driver.WaitForElement(QuoteGroup);
            Actions actions = new Actions(driver);
            actions.SendKeys(QuoteGroup, group).Build().Perform();
            QuoteGroup.SendKeys(Keys.Enter);
            _logger.Info($": Successfully Selected Quote Group {group}");
            return this;
        }

        public QuotePage AddLeadNumber(String leadno)
        {

            driver.WaitForElement(LeadNo);
            LeadNo.SendKeys(leadno);
            _logger.Info($": Successfully Entered Lead Number {leadno}");
            return this;
        }


        /// <summary>
        /// Function to edit  inter info section.
        /// </summary>
        /// <returns></returns>
        public QuotePage UpdateInternalInfo()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(InternalInfo, 10000);
            InternalInfo.Clickme(driver);
            _logger.Info($": Start Internal Information section update.");
            return this;
        }


        /// <summary>
        /// Function to provide updated sidemark.
        /// </summary>
        /// <param name="sidemark"></param>
        /// <returns></returns>
        public QuotePage UpdateSidemark(String sidemark)
        {
            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Sidemark, 10000);
            Sidemark.EnterText(sidemark);
            _logger.Info($": Successfully updated sidemark as {sidemark}");
            return this;
        }

        /// <summary>
        ///  Function to apply inter info section changes.
        /// </summary>
        /// <returns></returns>

        public QuotePage ApplyInternalInfoUpdates()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-200)");
            new System.Threading.ManualResetEvent(false).WaitOne(3000);
           driver.WaitForElementToBecomeVisibleWithinTimeout(InternalInfoApply, 10000);
            InternalInfoApply.Clickme(driver);
            _logger.Info($": Apply Internal Info changes");
            return this;
        }

        /// <summary>
        /// Function to click Add New Quote Button.
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnAddNewQuote()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddNewQuote, 10000);
            AddNewQuote.Clickme(driver);
            _logger.Info($": NEW QUOTE button clicked");
            return this;
        }

        /// <summary>
        /// Function to Click on Add Product Button.
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnAddProduct()
        {
            //Do not remove below Wait. This is essential to ensure that spinner is gone on Quote/Order page and ADD PRODUCTS button is clickable
            // Thread.Sleep(10000);
            driver.WaitForElement(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            _logger.Info($": ADD PRODUCTS button clicked");

            return this;
        }

        /// <summary>
        /// Function to enter product width
        /// </summary>
        /// <param name="WidthEntered"></param>
        /// <returns></returns>

        public QuotePage WaitUntilPageload()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loader-overlay-section']")));
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }
       

    public QuotePage EnterWidth(string WidthEntered)
        {
            //Do not remove below Wait. This is essential to ensure that page has loaded
            new System.Threading.ManualResetEvent(false).WaitOne(3000);

            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.EnterText(WidthEntered);
            _logger.Info($": Successfully entered width {WidthEntered}");
            return this;
        }

        /// <summary>
        /// Function to enter product height.
        /// </summary>
        /// <param name="HeightEntered"></param>
        /// <returns></returns>
        public QuotePage EnterHeight(string HeightEntered)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(1000);
            driver.WaitForElement(Height, 10000);
            Height.EnterText(HeightEntered);
            _logger.Info($": Successfully entered height {HeightEntered}");
            return this;
        }

        /// <summary>
        /// Function to enter product room location.
        /// </summary>
        /// <param name="RoomLocation"></param>
        /// <returns></returns>
        public QuotePage EnterRoomLocation(string RoomLocation)
        {

            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.EnterText(RoomLocation);
            _logger.Info($": Successfully entered room location {RoomLocation}");
            return this;
        }

        /// <summary>
        /// Function to select product to be configured
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public QuotePage SelectProduct(string ProductType)
        {
            //Do not remove below Wait. This is essential to ensure that products have loaded as per updated dimensions
            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(ProductCode, 10000);
            ProductCode.EnterText(ProductType);
            Thread.Sleep(200);
            ProductCode.SendKeys(Keys.Enter);
            _logger.Info($": Successfully selected the product {ProductType}");
            return this;
        }


        /// <summary>
        /// Function to select options read from getproductdetails function for configuring product.
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        public QuotePage SelectProductOptions(List<ProductDetail> productDetails)
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Mounting")));

            foreach (ProductDetail product in productDetails)
            {
                driver.FindElement(By.Id(product.OptionTypeId)).EnterText(product.Option);
                driver.FindElement(By.Id(product.OptionTypeId)).SendKeys(Keys.Enter);
                _logger.Info($": Successfully entered Option {product.Option} for Option Type {product.OptionTypeId}");

                try
                {
                    WebDriverWait customWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                    customWait2.Until(ExpectedConditions.ElementIsVisible(By.Id("idBtnOK")));
                    OkButton.Clickme(driver);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                Thread.Sleep(500);
            }
            return this;
        }


        /// <summary>
        /// Function to select options read from getproductdetails function for configuring product.
        /// </summary>
        /// <param name="editProductDetails"></param>
        /// <returns></returns>
        public QuotePage SelectProductOptionsEdit(List<EditProductDetail> editProductDetails)
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

        /// <summary>
        /// Function to click on add product line button on product page.
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickAddProductButton()
        {
            Thread.Sleep(5000);
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("doneProductLine")));
            AddProductLineButton.Clickme(driver);
            _logger.Info($": ADD LINE button clicked");
            return this;
        }

        /// <summary>
        /// Function to read option id and option from json
        /// </summary>
        /// <param name="ProductDetails"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> AddProductDetails(List<ProductDetail> ProductDetails)
        {
            List<Tuple<string, string>> addedProducts = new List<Tuple<string, string>>();

            //Input product details
            for (int counter = 0; counter < ProductDetails.Count; counter++)
            {
                string optiontype = ProductDetails[counter].OptionTypeId;
                string option = ProductDetails[counter].Option;

                addedProducts.Add(new Tuple<string, string>(optiontype, option));
            }

            return addedProducts;
        }


        /// <summary>
        /// Function to add multiple product lines.
        /// </summary>
        /// <param name="productLineData"></param>
        public void AddMultipleProducts(List<DataDictionary> productLineData)
        {
            foreach (DataDictionary data in productLineData)
            {
                WaitUntilPageload();
                ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(data.Value);
                // Thread.Sleep(4000);
                new System.Threading.ManualResetEvent(false).WaitOne(implicitWait);
                ClickOnAddProduct().WaitUntilPageload().EnterWidth(productLine.Width).EnterHeight(productLine.Height).EnterRoomLocation(productLine.NDBRoomLocation)
                    .SelectProduct(productLine.ProductType).SelectProductOptions(productLine.ProductDetails).ClickAddProductButton().WaitUntilPageload();
            }
        }
       

        /// <summary>
        /// Function to verify quote creation.
        /// </summary>
        /// <returns></returns>
        public bool VerifyQuoteCreation()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, QuoteActions, 60);
            bool quoteActions = false;
            if (QuoteActions.Displayed)
            {
                quoteActions = true;
                _logger.Info($" Verifying Quote Creation.");
            }

            return quoteActions;

        }


        /// <summary>
        /// Function to verify all products are added.
        /// </summary>
        /// <returns></returns>

        public int CountProductLineEntered()
        {
            Thread.Sleep(10000);
            int count = 0;
            int j = 2;
            while ((By.XPath("//li["+j+"]//div[3]")).isPresent(driver))
                {
                count++;
                j++;
                Thread.Sleep(10000);
            }
            _logger.Info($"Count{count}");
            return count;

        }

        /// <summary>
        /// Function to Verify Products Entered
        /// </summary>
        /// <param name="productLineData"></param>
        /// <returns></returns>
        public bool VerifyProductsEntered(List<DataDictionary> productLineData)
        {
           // Thread.Sleep(10000);
            int totalProductsOnScreen = CountProductLineEntered();
            int totalCountOfProducts = productLineData.Count;
            bool productQuantity = false;
            if (totalProductsOnScreen.Equals(totalCountOfProducts))
            {
                productQuantity = true;
                _logger.Info($"Verifying quantity Of Products Entered was {totalCountOfProducts} and product quantity on screen is {totalProductsOnScreen}");
            }
            return productQuantity;

        }


        /// <summary>
        /// Function to Click on Hamburger
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnhamburgerButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(HamburgerClick, 60);
            Thread.Sleep(4000);
            HamburgerClick.Clickme(driver);
            _logger.Info($" Click on hamburger.");
            return this;
        }

        /// <summary>
        /// Function to Click on Copy To Quote Button
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnCopyButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(CopyProductLine, 60);
            CopyProductLine.Clickme(driver);
            _logger.Info($" Clicked on Copy Product Line.");
            return this;
        }
    
        /// <summary>
        /// Function to Verify copy Quote
        /// </summary>
        /// <param name="productLineData"></param>
        /// <returns></returns>
        public bool VerifyTotalProductsAfterCopy(List<DataDictionary> productLineData)
        {

            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, TotalProducts, 60);
            int totalProductsOnScreen = CountProductLineEntered();
            int totalCountOfProducts = productLineData.Count+1;
            bool productQuantity = false;
            if (totalProductsOnScreen.Equals(totalCountOfProducts))
            {
                productQuantity = true;
                _logger.Info($"Verifying quantity Of Products After Copy was {totalCountOfProducts} and product quantity on screen is {totalProductsOnScreen}");
            }
            return productQuantity;

        }

        /// <summary>
        /// Function to click on Edit button.
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnEditButton()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditProductLine, 60);
            EditProductLine.Clickme(driver);
            _logger.Info($" Clicked on Edit Product Line.");
            return this;
        }


        /// <summary>
        /// Function to read option and option id while editing product configuration.
        /// </summary>
        /// <param name="EditProductDetails"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> EditProductDetails(List<EditProductDetail> EditProductDetails)
        {
            List<Tuple<string, string>> editProducts = new List<Tuple<string, string>>();

            //Input product details
            for (int counter = 0; counter < EditProductDetails.Count; counter++)
            {
                string optiontype = EditProductDetails[counter].OptionTypeId;
                string option = EditProductDetails[counter].Option;

                editProducts.Add(new Tuple<string, string>(optiontype, option));
            }

            return editProducts;
        }

        /// <summary>
        /// Function to edit product line configurations.
        /// </summary>
        /// <param name="editproductLineData"></param>
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

       

            /// <summary>
            /// Function to verify data in product summary after edit.
            /// </summary>
            /// <param name="EditProductDetails"></param>
            /// <returns></returns>

            public bool VerifyProductDataAfterEdit(List<DataDictionary> editproductLineData)
        {
            WaitUntilPageload();
            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(InternalInfo, implicitWait);
            int i = 2;
            int count = 0;
            string[] productLineDataArray = new string[100];
            do
            {
                WaitUntilPageload();
                string productColumn = driver.FindElement(By.XPath("//li[2]//div[" + i + "]")).GetText(driver);
                productLineDataArray[count] = productColumn;
                i++; count++;
                _logger.Info(productLineDataArray[count]);
            } while (By.XPath("//li[2]//div[" + i + "]").isPresent(driver));


            bool roomLocation = false;
            bool color = false;
            int returnedTrue = 0;

            foreach (DataDictionary data in editproductLineData)
            {
                EditProductLineData editProductLine = JsonDataParser<EditProductLineData>.ParseData(data.Value);
                String ndbRoomLocationString = editProductLine.NDBRoomLocation;
                List<EditProductDetail> editProductDetails = editProductLine.EditProductDetails;

                int j = 0;
                
                do
                {
                    if (ndbRoomLocationString.Contains(productLineDataArray[j]))
                    {
                        roomLocation = true;
                        _logger.Info($" Room Location " + ndbRoomLocationString + " After Edit Is Correct.");
                        returnedTrue++;
                        //break;
                    }

                    if (editProductLine.EditProductDetails[1].Option.Contains(productLineDataArray[j]))
                    {

                        color = true;
                        _logger.Info($" Color Entered " + editProductLine.EditProductDetails[1].Option + " After Edit Is Correct.");
                        returnedTrue++;
                        break;
                        
                    }
                    j++;
                } while (productLineDataArray[j] != null);
            
            }
            if (roomLocation == true && color == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifying data entered on product summary grid is correct.
        /// </summary>
        /// <param name="productLineData"></param>
        /// <returns></returns>
        public bool VerifyProductDataAfterAdd(List<DataDictionary> productLineData)
        {

            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(InternalInfo, implicitWait);
            WaitUntilPageload();
            int i = 2;
            int count = 0;
            string[] productLineDataArray = new string[100];
            for (int j = 2; j <= 4; j++)
            {
                do
                {
                    string productColumn = driver.FindElement(By.XPath("//li[" + j + "]//div[" + i + "]")).GetText(driver);
                    productLineDataArray[count] = productColumn;
                    i++; count++;
                    _logger.Info(productLineDataArray[count]);
                } while (By.XPath("//li[2]//div[" + i + "]").isPresent(driver));
                i = 2;
            }


            bool roomLocation = false;
            bool color = false;
            bool liftsystem = false;

            foreach (DataDictionary data in productLineData)
            {
                ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(data.Value);
                String ndbRoomLocationString = productLine.NDBRoomLocation;
                List<ProductDetail> addedProductDetails = productLine.ProductDetails;

                int j = 0;

                do
                {
                    if (ndbRoomLocationString.Contains(productLineDataArray[j]))
                    {
                        roomLocation = true;
                        _logger.Info($"Added  Room Location " + ndbRoomLocationString + " Is Correct.");
                        //break;
                    }

                    if (productLine.ProductDetails[1].Option.Contains(productLineDataArray[j]))
                    {

                        color = true;
                        _logger.Info($"Added Color " + productLine.ProductDetails[1].Option + " Is Correct.");
                        //  break;

                    }

                    if (productLine.ProductDetails[3].Option.Contains(productLineDataArray[j]))
                    {

                        liftsystem = true;
                        _logger.Info($"Added  Lift System " + productLine.ProductDetails[3].Option + " Is Correct.");
                        break;

                    }
                    j++;
                } while (productLineDataArray[j] != null);

            }
            if (roomLocation == true && color == true && liftsystem == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            /// <summary>
            /// Function to delete multiple product lines.
            /// </summary>
            public void DeleteMultipleProducts()
        {
            int i = 2;
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, HamburgerClick, implicitWait);
            while ((By.XPath("(//div[@class='dot-btn'])[" + i + "]")).isPresent(driver))

            {
                //Thread.Sleep(5000);
                WaitUntilPageload();
                driver.FindElement(By.XPath("(//div[@class='dot-btn'])[" + i + "]")).Clickme(driver);
                WaitUntilPageload();
                driver.FindElement(By.XPath("(//ul[@class='action-popup']//span[text()='DELETE'])[" + i + "]")).Clickme(driver);
                _logger.Info($" Clicked on Delete Product Line.");
                OkButton.Clickme(driver);
                WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, TotalProducts, 60);
                WaitUntilPageload();
            }
            Thread.Sleep(8000);
            i = 1;
            if ((By.XPath("(//div[@class='dot-btn'])[" + i + "]")).isPresent(driver))
            {

                WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, driver.FindElement(By.XPath("(//div[@class='dot-btn'])[" + i + "]")), 60);
                driver.FindElement(By.XPath("(//div[@class='dot-btn'])[" + i + "]")).Clickme(driver);
                driver.FindElement(By.XPath("(//ul[@class='action-popup']//span[text()='DELETE'])[" + i + "]")).Clickme(driver);
                _logger.Info($" Tried to Delete Last Product Line.");

            }
        }

       

        /// <summary>
        /// Function to verify all product lines are deleted.
        /// </summary>
        /// <returns></returns>
        public bool VeriyUserNotAbleToDeleteAllProductLines()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, HamburgerClick, 60);
            bool lastProductLine = false;
            if (DeleteAllProductLine.Displayed)
            {
                lastProductLine = true;
            }

            return lastProductLine;
        }
        /// <summary>
        /// Function to escape warning popup.
        /// </summary>
        /// <returns></returns>

        public QuotePage ClickOkButton()
        {
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, OkButton, 60);
            OkButton.Clickme(driver);
            return this;
        }
       



        /// <summary>
        /// Click on edit button of measruement and installtion page
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnEditButtonOfMeasurementAndInstallation()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(3000);
            driver.WaitForElement(EditButtonOfAddress);
            EditButtonOfAddress.Clickme(driver);
            return this;
        }


        /// <summary>
        /// Function to asserting if direction is added
        /// </summary>
        /// <param name="ExpectedDirectionText"></param>
        /// <returns></returns>
        public bool VerifyDirectionIsAdded(String ExpectedDirectionText)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButtonOfAddress, 5000);
            bool ifDirectionAdded = false;
            String ActualValue = DirectionText.GetText(driver);
            if (ActualValue.Contains(ExpectedDirectionText))
            {
                ifDirectionAdded = true;
                _logger.Info($" Direction is Added");
            }
            return ifDirectionAdded;
        }

        /// <summary>
        /// Function to Verify addtional cost on quote page
        /// </summary>
        /// <param name="SelectCost"></param>
        /// <param name="ExpectedCostAmount"></param>
        /// <returns></returns>
        public bool VerifyAdditionalCost(Boolean SelectCost, String ExpectedCostAmount)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(5000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(EditButtonOfAddress, 5000);
            bool isCostAdded = false;
            if (SelectCost is true)
            {
                String ActualAmount = AdditionalCostView.GetText(driver);
                String ExpectedAmount = "$" + ExpectedCostAmount;
                if (ActualAmount.Equals(ExpectedAmount))
                {
                    isCostAdded = true;
                    _logger.Info($" Cost is added and same as entered");
                }
            }
            else if (SelectCost is false)
            {
                isCostAdded = true;
                _logger.Info($" Cost is not selected");
            }


            return isCostAdded;
        }
        /// <summary>
        /// Function to click on adjustment link
        /// </summary>
        /// <returns></returns>

        public QuotePage ClickOnAdjustmentsLink()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(10000);
            driver.WaitForElement(AdjustmentsLink);
            AdjustmentsLink.Clickme(driver);
            return this;
        }


        /// <summary>
        /// Function to Add adjustment main Fucntion
        /// </summary>
        /// <param name="adjustments"></param>
        /// <returns></returns>
        public QuotePage AddAdjustments(List<Adjustment> adjustments)
        {
            for (int counter = 0; counter < adjustments.Count; counter++)

            {
                string adjustmentType = adjustments[counter].AdjustmentType;
                string adjustmentCode = adjustments[counter].AdjustmentCode;
                string amount = adjustments[counter].Amount;

                SelectAdjustmentType(adjustmentType, counter).SelectAdjustmentCode(adjustmentCode, counter).AddAmount(amount, counter);

            }
            AdjustmentsDoneButton.Clickme(driver);
            return this;

        }



        /// <summary>
        /// Function to select adjustment type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public QuotePage SelectAdjustmentType(String type, int i)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            string MyID = "adjustmentOption" + i;
            string AdjustmentXpath = "//input[@id='adjustmentOption" + i + "']/ancestor::div[@class='Select-control']/following-sibling::div/div[1]";
           // driver.WaitForElement(driver.FindElement(By.Id(MyID)));
            Actions actions_ = new Actions(driver);
            actions_.SendKeys(driver.FindElement(By.Id(MyID)), type).Build().Perform();
            driver.FindElement(By.XPath(AdjustmentXpath)).Clickme(driver);


            _logger.Info($": Successfully Selected Adjustment Type {type}");

            return this;

        }

        /// <summary>
        /// Function to select adjustment code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public QuotePage SelectAdjustmentCode(String code, int i)
        {
            string MyID = "adjustmentType" + i;
            driver.WaitForElement(driver.FindElement(By.Id(MyID)));        
            Actions actions = new Actions(driver);
            actions.SendKeys(driver.FindElement(By.Id(MyID)), code).Build().Perform();
            driver.FindElement(By.Id(MyID)).SendKeys(Keys.Enter);
            _logger.Info($": Successfully Selected Adjustment Code {code}");
            return this;

        }

        /// <summary>
        /// Function to Add ajustment amount on quote page
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public QuotePage AddAmount(String amount, int i)
        {
            string MyID = "adjustmentAmount" + i;
            driver.WaitForElement(driver.FindElement(By.Id(MyID)));
            driver.FindElement(By.Id(MyID)).EnterText(amount);
            _logger.Info($": Successfully Entered Amount {amount}");
            return this;

        }
        /// <summary>
        /// Function to Click on Tax Link
        /// </summary>
        /// <returns></returns>

        public QuotePage ClickOnTaxLink()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            driver.WaitForElement(TaxButton);
            TaxButton.Clickme(driver);
            return this;
        }

        /// <summary>
        /// Function to Select Non-applicable tax from drop down on tax popup
        /// </summary>
        /// <param name="SelectTaxExempt"></param>
        /// <param name="TaxIdNumber"></param>
        /// <returns></returns>
        public QuotePage SelectNonApplicableTax(bool SelectTaxExempt,String TaxIdNumber)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            driver.WaitForElement(driver.FindElement(By.XPath("//h2[contains(text(),'Taxes')]")));
            if (SelectTaxExempt is true) 
            {
              //  driver.WaitForElement(TaxExemptCheckBox);
                TaxExemptCheckBox.Clickme(driver);
                Actions actions = new Actions(driver);
                actions.SendKeys(TaxNumberDropDown, TaxIdNumber).Build().Perform();
                TaxNumberDropDown.SendKeys(Keys.Enter);
                _logger.Info($": Select {TaxIdNumber} not applicable for the given customer address");

            }
            else if (SelectTaxExempt is false)
            {
                DoneButton.Clickme(driver);
            }

           return this;
        }

        /// <summary>
        /// Function to Select applcable tax from tax popup
        /// </summary>
        /// <param name="TaxIdNumber"></param>
        /// <returns></returns>
        public QuotePage SelectApplicableTax(String TaxIdNumber)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            Actions actions = new Actions(driver);
            actions.SendKeys(TaxNumberDropDown, TaxIdNumber).Build().Perform();
            TaxNumberDropDown.SendKeys(Keys.Enter);
            _logger.Info($": Select {TaxIdNumber} applicable for the given customer address");
            DoneButton.Clickme(driver);
            return this;
        }
        /// <summary>
        /// Function to click on convert to order  button and wait untill loders gets loaded
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickOnConvertToQuote()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)");
            ConvertToOrderButton.Clickme(driver);
            _logger.Info($" User clicked on convert to order button");
            driver.WaitForElement(ContinueButton);
            ContinueButton.Clickme(driver);
            _logger.Info($" User clicked on contiue button");
            return this;
        }

        /// <summary>
        /// Function to Select Convert to POS on order page
        /// </summary>
        /// <returns></returns>
        public QuotePage SelectConvertToPOS()
        {
            ConvertToPOS.Clickme(driver);
            _logger.Info($" User clicked onconvert to POS button");
            ContinueConvertToOrder.Clickme(driver);
            _logger.Info($" User clicked on contiue button");
            return this;
        }

        /// <summary>
        /// Function to  Verify that user is navigated to payment page
        /// </summary>
        /// <returns></returns>
        public bool VerifyUserIsNavigatedToPaymentPage()
        {
            driver.WaitForElement(PaymentScreenText);
            bool isPaymentPageDisplayed = false;
            if (PaymentScreenText.Displayed)
            {
                isPaymentPageDisplayed = true;
                _logger.Info($" User is navigated to payment page");

            }

           return isPaymentPageDisplayed;
        }


        /// <summary>
        /// Function to  Verify error message while selecting invalid taxid for the given customer addres
        /// </summary>
        /// <param name="ExpetectedErrorMessage"></param>
        /// <returns></returns>
        public bool VerifyTaxErrorMessage(String ExpetectedErrorMessage)
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            driver.WaitForElement(TaxErrorMessage);
            bool isMessageCorrect = false;
            String ActualErrorMessage = TaxErrorMessage.GetText(driver);

            if (ActualErrorMessage.Equals(ExpetectedErrorMessage))
            {
                isMessageCorrect = true;
                _logger.Info($" Tax Exempt Error message is verified");
            }
            return isMessageCorrect;

        }

        /// <summary>
        /// Verifying total adjustment amount
        /// </summary>
        /// <param name="expectedTotalAmountOfAddedAdjustments"></param>
        /// <returns></returns>
        public bool VerifyAdjustmentTotalAmount(String expectedTotalAmountOfAddedAdjustments)
        {
            driver.WaitForElement(AdjustmentVIew);
            bool isAdjustmentAmountCorrect = false;
            String ActualAmount = AdjustmentVIew.GetText(driver);

            if (ActualAmount.Equals(expectedTotalAmountOfAddedAdjustments))
            {
                isAdjustmentAmountCorrect = true;
                _logger.Info($" Adjustment amount is verified and populated correctly");
            }
            return isAdjustmentAmountCorrect;

        }

        /// <summary>
        /// Function to verify tax exemption is applied
        /// </summary>
        /// <param name="expectedTotalTaxExempt"></param>
        /// <returns></returns>
        public bool VerifyTaxExemptionIsApplied(String expectedTotalTaxExempt)
        {

            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            driver.WaitForElement(TaxView);
            bool isTaxExempt = false;
            String ActualTaxExempt = TaxView.GetText(driver);

            if (ActualTaxExempt.Equals(expectedTotalTaxExempt))
            {
                isTaxExempt = true;
                _logger.Info($" Tax Exemption is applied succesfully");
            }
            return isTaxExempt;

        }

        /// <summary>
        /// Function to Search function for quote
        /// </summary>
        /// <returns></returns>
        public QuotePage SearchFunctionForQuote()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            _logger.Info($" User clicked on search button on top navigation panel");
            SearchQuote.Clickme(driver);
            _logger.Info($" User clicked on search for quote tab on search page");
            EnterOuote.EnterText("703895");
            _logger.Info($" User entered quote{703895}");
            Enter.Clickme(driver);
            _logger.Info($" User clicked on search button");
            WaitUntilPageload();
            _logger.Info($" Waited for loader gets loaded");
            new System.Threading.ManualResetEvent(false).WaitOne(3000);

            return this;
        }

        /// <summary>
        /// Function to  Search function for order
        /// </summary>
        /// <returns></returns>
        public QuotePage SearchFunctionForOrder()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            _logger.Info($" User clicked on search button on top navigation panel");
            SearchOrder.Clickme(driver);
            _logger.Info($" User clicked on search for order tab on search page");
            //  EnterOrder.EnterText("2013543");
            EnterOrder.EnterText("2013671");
            _logger.Info($" User entered quote{2013671}");
            Enter.Clickme(driver);
            _logger.Info($" User clicked on search button");
            WaitUntilPageload();
            _logger.Info($" Waited for loader gets loaded");
            Thread.Sleep(1000);
            return this;
        }
      

        public QuotePage CopyQuoteAndSave()
        {
            IWebElement copytoquote = driver.FindElement(By.XPath("//a[contains(text(),'Copy Quote')]"));
           // driver.WaitForElement(copytoquote);
            new System.Threading.ManualResetEvent(false).WaitOne(3000);
            copytoquote.Clickme(driver);
            _logger.Info($" User clicked on copy to quote button");
            new System.Threading.ManualResetEvent(false).WaitOne(3000);
            SaveButton.Clickme(driver);
            _logger.Info($" User clicked on save button");
            return this;
        }

       
    }
}
