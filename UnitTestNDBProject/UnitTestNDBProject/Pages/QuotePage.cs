using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using SeleniumExtras.PageObjects;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

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

        //I believe we should keep all search related fucntion in SearchPage instead of QuotePage
        public QuotePage SearchFunction()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            SearchOrder.Clickme(driver);
            EnterOrder.EnterText("2013047");
            Enter.Clickme(driver);
            return this;
        }

        public QuotePage ClickOnAddNewQuote()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddNewQuote, 10000);
            AddNewQuote.Clickme(driver);
            _logger.Info($": NEW QUOTE button clicked");
            return this;
        }

        public QuotePage ClickOnAddProduct()
        {
            //Do not remove below Wait. This is essential to ensure that spinner is gone on Quote/Order page and ADD PRODUCTS button is clickable
            Thread.Sleep(5000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            _logger.Info($": ADD PRODUCTS button clicked");
            return this;
        }

        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
        public QuotePage EnterWidth(string WidthEntered)
        {
            //Do not remove below Wait. This is essential to ensure that page has loaded
            Thread.Sleep(1000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.EnterText(WidthEntered);
            _logger.Info($": Successfully entered width {WidthEntered}");
            return this;
        }

        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
        public QuotePage EnterHeight(string HeightEntered)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
            Height.EnterText(HeightEntered);
            _logger.Info($": Successfully entered height {HeightEntered}");
            return this;
        }

        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
        public QuotePage EnterRoomLocation(string RoomLocation)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.EnterText(RoomLocation);
            roomlocation.EnterText(Keys.Enter);
            _logger.Info($": Successfully entered room location {RoomLocation}");
            return this;
        }

        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
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

        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
        public void GetProductDetails()
        {
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

            productDetails = AddProductDetails(productLine.ProductDetails);
        }
       
        //I believe we should keep all product add related fucntion in ProductPage instead of QuotePage
        public QuotePage SelectProductOptions(List<ProductDetail> productDetails)
        {
            //GetProductDetails();
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

        public QuotePage ClickAddProductButton()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("doneProductLine")));
            AddProductLineButton.Clickme(driver);
            _logger.Info($": ADD LINE button clicked");
            return this;
        }

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
        
        public void AddMultipleProducts(List<DataDictionary> productLineData)
        {
            foreach (DataDictionary data in productLineData)
            {
                ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(data.Value);

                ClickOnAddProduct().EnterWidth(productLine.Width).EnterHeight(productLine.Height).EnterRoomLocation(productLine.NDBRoomLocation)
                    .SelectProduct(productLine.ProductType).SelectProductOptions(productLine.ProductDetails).ClickAddProductButton();
            }
        }
    }
}