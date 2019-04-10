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
            Thread.Sleep(15000);
            Search.Clickme(driver);
            SearchOrder.Clickme(driver);
            EnterOrder.SendKeys("2013047");
            Enter.Clickme(driver);
            return this;
        }

        public AddQuotePage ClickOnAddNewQuote()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddNewQuote, 10000);
            AddNewQuote.Clickme(driver);
            return this;
        }

        public AddQuotePage ClickOnAddProduct()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(AddProductLine, 10000);
            AddProductLine.Clickme(driver);
            return this;
        }

        public AddQuotePage EnterWidth(string WidthEntered)
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.SendKeys(WidthEntered);
            return this;
        }

        public AddQuotePage EnterHeight(string HeightEntered)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
            Height.SendKeys(HeightEntered);
            return this;
        }

        public AddQuotePage EnterRoomLocation(string RoomLocation)
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.SendKeys(RoomLocation);
            roomlocation.SendKeys(Keys.Enter);
            return this;
        }



        public AddQuotePage SelectProduct(string ProductType)
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(ProductCode, 10000);
            ProductCode.SendKeys(ProductType);
            Thread.Sleep(2000);
            ProductCode.SendKeys(Keys.Enter);
            return this;
        }


        public void getAllProductDetails()
        {

            CommonTest ct = new CommonTest();
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

            productDetails = ct.AddProductDetails(productLine.ProductDetails);

            //return productLists;
        }


        public void getProductDetails()
        {
            CommonTest ct = new CommonTest();
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);

            productDetails = ct.AddProductDetails(productLine.ProductDetails);

            //return productLists;
        }

        //productDetails = getProductDetails();
        public AddQuotePage SelectMountingDynamic()
        {
            getProductDetails();
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Mounting")));
            foreach (Tuple<string, string> product in productDetails)
            {

                driver.FindElement(By.Id(product.Item1)).SendKeys(product.Item2);
                driver.FindElement(By.Id(product.Item1)).SendKeys(Keys.Enter);

                try
                {
                    WebDriverWait customWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                    customWait2.Until(ExpectedConditions.ElementIsVisible(By.Id("idBtnOK")));
                    OkButton.Clickme(driver);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                Thread.Sleep(4000);
            }
            return this;
        }

        public AddQuotePage ClickAddProductButton()
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("doneProductLine")));
            AddProductLineButton.Clickme(driver);
            return this;
        }

       
    }
}
