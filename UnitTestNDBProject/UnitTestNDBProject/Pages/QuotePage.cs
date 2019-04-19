using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.TestDataAccess;
using SeleniumExtras.PageObjects;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace UnitTestNDBProject.Pages
{
    public class QuotePage
    {

        public IWebDriver driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static ParsedTestData productLineFeatureParsedData;
        List<Tuple<string, string>> productDetails;

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

        [FindsBy(How = How.XPath, Using = "//input[@id='orderNumber']")]
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
            Thread.Sleep(10000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            _logger.Info($": ADD PRODUCTS button clicked");
            return this;
        }

        /// <summary>
        /// Function to enter product width
        /// </summary>
        /// <param name="WidthEntered"></param>
        /// <returns></returns>
        public QuotePage EnterWidth(string WidthEntered)
        {
            //Do not remove below Wait. This is essential to ensure that page has loaded
            Thread.Sleep(1000);
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
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
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
        /// Function to read options for configuring product.
        /// </summary>
        //Not using this function hence can be removed
        //public void GetProductDetails()
        //{
        //    productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
        //    object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
        //    ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

        //    productDetails = AddProductDetails(productLine.ProductDetails);
        //}

        /// <summary>
        /// Function to select options read from getproductdetails function for configuring product.
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        public QuotePage SelectProductOptions(List<ProductDetail> productDetails)
        {
            // As we already discused this function is not required to call here as we are picking all the products from the parameter passsed in this function instead of single product hence commenting it
           // GetProductDetails();
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
        /// Function to click on add product line button on product page.
        /// </summary>
        /// <returns></returns>
        public QuotePage ClickAddProductButton()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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
                ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(data.Value);
                Thread.Sleep(4000);
                ClickOnAddProduct().EnterWidth(productLine.Width).EnterHeight(productLine.Height).EnterRoomLocation(productLine.NDBRoomLocation)
                    .SelectProduct(productLine.ProductType).SelectProductOptions(productLine.ProductDetails).ClickAddProductButton();
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
        /// Function to count product lines added from JSON.
        /// 
        /// </summary>
        /// <param name="productLineData"></param>
        /// <returns></returns>
        //This function is not required as we have inbuild function to get the list count
        //public string countproducts(List<DataDictionary> productLineData)
        //{
        //    int count = 0;
        //    foreach (DataDictionary data in productLineData)
        //    {
        //        count++;
        //    }
        //    String totalCount = "TOTAL PRODUCTS" + count.ToString();
        //    return totalCount;
        //}

        /// <summary>
        /// Function to verify all products are added.
        /// </summary>
        /// <returns></returns>
        //Passed the expected count of Product in the form of parameter
        public bool VerifyTotalProducts(List<DataDictionary> productLineData)
        {
            Thread.Sleep(5000);
            WaitHelpers.WaitForElementToBecomeVisibleWithinTimeout(driver, TotalProducts, 60);
            String totalProductsOnScreen = TotalProducts.GetText(driver);
            //productLineFeatureParsedData.Data used in below statement will pass the null value now as function GetProductDetails() which is not required and commented was passing the value into this
            //  String totalproductsEntered = countproducts(productLineFeatureParsedData.Data);
            
             //Instead of above, we can get the count of list directly (All these comments are added for PR purpose to let the reviwer know the reason of changin/deleting/updating the code after/before PR merege will remove all)
            int totalCountOfProducts = productLineData.Count;
            String totalProductsEntered = "TOTAL PRODUCTS" + totalCountOfProducts.ToString();
            bool productQuantity = false;
            if (totalProductsOnScreen.Contains(totalProductsEntered))
            {
                productQuantity = true;
                _logger.Info($"Verifying quantity Of Products Entered was {totalProductsEntered} and product quantity on screen is {totalProductsOnScreen}");
            }
            return productQuantity;

        }
    }
}