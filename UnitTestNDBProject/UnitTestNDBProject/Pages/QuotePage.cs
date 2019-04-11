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

        [FindsBy(How = How.Id, Using = "Mounting")]
        public IWebElement Mounting { get; set; }

        [FindsBy(How = How.Id, Using = "Color")]
        public IWebElement Color { get; set; }

        [FindsBy(How = How.Id, Using = "NumberOnHeadrail")]
        public IWebElement NumberOnHeadrail { get; set; }

        [FindsBy(How = How.Id, Using = "LiftSystem")]
        public IWebElement LiftSystem { get; set; }

        [FindsBy(How = How.Id, Using = "TiltControl")]
        public IWebElement TiltControl { get; set; }

        [FindsBy(How = How.Id, Using = "ControlLocation")]
        public IWebElement ControlLocation { get; set; }

        [FindsBy(How = How.Id, Using = "Valance")]
        public IWebElement Valance { get; set; }

        public QuotePage SearchFunction()
        {
            //Thread.Sleep(10000);
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
            return this;
        }

        public QuotePage ClickOnAddProduct()
        {
            //Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            return this;
        }

        public QuotePage EnterWidth(string WidthEntered)
        {
            //Do not remove below Wait. This is essential to ensure that page has loaded
            Thread.Sleep(1000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.EnterText(WidthEntered);
            return this;
        }

        public QuotePage EnterHeight(string HeightEntered)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
            Height.EnterText(HeightEntered);
            return this;
        }

        public QuotePage EnterRoomLocation(string RoomLocation)
        {
            //Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.EnterText(RoomLocation);
            roomlocation.EnterText(Keys.Enter);
            return this;
        }

        public QuotePage SelectProduct(string ProductType)
        {
            //Do not remove below Wait. This is essential to ensure that products have loaded as per updated dimensions
            Thread.Sleep(2000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(ProductCode, 10000);
            ProductCode.EnterText(ProductType);
            Thread.Sleep(200);
            ProductCode.SendKeys(Keys.Enter);
            return this;
        }

        public void GetProductDetails()
        {
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

            productDetails = AddProductDetails(productLine.ProductDetails);
        }
        
        public QuotePage SelectMountingDynamic(List<ProductDetail> productDetails)
        {
            GetProductDetails();
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Mounting")));

            foreach (ProductDetail product in productDetails)
            {
                driver.FindElement(By.Id(product.OptionTypeId)).EnterText(product.Option);
                driver.FindElement(By.Id(product.OptionTypeId)).SendKeys(Keys.Enter);

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

        //public QuotePage SelectMounting()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(Mounting, 10000);
        //    Mounting.SendKeys("Inside Mount");
        //    Mounting.SendKeys(Keys.Enter);
        //    return this;
        //}

        //public QuotePage SelectColor()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(Color, 10000);
        //    Color.SendKeys("Cloud");
        //    Color.SendKeys(Keys.Enter);
        //    return this;
        //}

        //public QuotePage SelectNumberOnHeadrails()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(NumberOnHeadrail, 10000);
        //    NumberOnHeadrail.SendKeys("Standard");
        //    NumberOnHeadrail.SendKeys(Keys.Enter);
        //    return this;
        //}

        //public QuotePage SelectLiftSystem()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(LiftSystem, 10000);
        //    LiftSystem.SendKeys("Cordlock");
        //    LiftSystem.SendKeys(Keys.Enter);

        //    return this;
        //}

        //public QuotePage SelectTiltControl()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(TiltControl, 10000);
        //    TiltControl.SendKeys("Cord Tilt");
        //    TiltControl.SendKeys(Keys.Enter);
        //    OkButton.Clickme(driver);
        //    return this;
        //}

        //public QuotePage SelectControlPosition()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(ControlLocation, 10000);
        //    ControlLocation.SendKeys("Til Left/Lift Right");
        //    ControlLocation.SendKeys(Keys.Enter);
        //    return this;
        //}

        //public QuotePage SelectValance()
        //{
        //    Thread.Sleep(4000);
        //    driver.WaitForElementToBecomeVisibleWithinTimeout(Valance, 10000);
        //    Valance.SendKeys("Standard");
        //    Valance.SendKeys(Keys.Enter);
        //    return this;
        //}

        // Add Product Details
    }
}