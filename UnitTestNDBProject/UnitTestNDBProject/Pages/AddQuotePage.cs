using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestNDBProject.Utils;
using UnitTestNDBProject.Tests;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestNDBProject.Pages
{
    public class AddQuotePage
    {
        public IWebDriver driver;
        public AddQuotePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        private Logger _logger = LogManager.GetCurrentClassLogger();


        //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");

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


        [FindsBy(How = How.Id, Using = "Mounting")]
        public IWebElement Mounting { get; set; }

        [FindsBy(How = How.Id, Using = "Color")]
        public IWebElement Color { get; set; }

        [FindsBy(How = How.Id, Using = "NumberOnHeadrail")]
        public IWebElement NumberOnHeadrail { get; set; }

        [FindsBy(How = How.Id, Using = "LiftSystem")]
        public IWebElement LiftSystem { get; set; }


        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }



        [FindsBy(How = How.Id, Using = "TiltControl")]
        public IWebElement TiltControl { get; set; }

        [FindsBy(How = How.Id, Using = "ControlLocation")]
        public IWebElement ControlLocation { get; set; }

        [FindsBy(How = How.Id, Using = "Valance")]
        public IWebElement Valance { get; set; }

        private static ParsedTestData productLineFeatureParsedData;
        private static ParsedTestData loginFeatureParsedData;
        CommonTest commonTest;

        List<Tuple<string, string>> productDetails;

        public AddQuotePage SearchFunction()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Search, 10000);
            Search.Clickme(driver);
            SearchOrder.Clickme(driver);
            EnterOrder.EnterText("2013047");
            Enter.Clickme(driver);
            return this;
        }

        public AddQuotePage ClickOnAddNewQuote()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddNewQuote, 10000);
            AddNewQuote.Clickme(driver);
            _logger.Info($": NEW QUOTE button clicked");
            return this;
        }

        public AddQuotePage ClickOnAddProduct()
        {
            //Do not remove below Wait. This is essential to ensure that spinner is gone on Quote/Order page and ADD PRODUCTS button is clickable
            Thread.Sleep(5000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            _logger.Info($": ADD PRODUCTS button clicked");
            return this;
        }

        public AddQuotePage EnterWidth(string WidthEntered)
        {
            //Do not remove below Wait. This is essential to ensure that page has loaded
            Thread.Sleep(1000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.EnterText(WidthEntered);
            _logger.Info($": Successfully entered width {WidthEntered}");
            return this;
        }

        public AddQuotePage EnterHeight(string HeightEntered)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
            Height.EnterText(HeightEntered);
            _logger.Info($": Successfully entered height {HeightEntered}");
            return this;
        }

        public AddQuotePage EnterRoomLocation(string RoomLocation)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.EnterText(RoomLocation);
            roomlocation.EnterText(Keys.Enter);
            _logger.Info($": Successfully entered room location {RoomLocation}");
            return this;
        }

        public AddQuotePage SelectProduct(string ProductType)
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

        public void GetProductDetails()
        {
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

            productDetails = AddProductDetails(productLine.ProductDetails);
        }

        public AddQuotePage SelectProductOptions(List<ProductDetail> productDetails)
        {
            GetProductDetails();
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

        public AddQuotePage ClickAddProductButton()
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
