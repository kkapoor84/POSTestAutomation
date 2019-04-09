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
            Thread.Sleep(10000);
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

        public AddQuotePage EnterWidth()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Width, 10000);
            Width.SendKeys("22");
            return this;
        }

        public AddQuotePage EnterHeight()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(Height, 10000);
            Height.SendKeys("22");
            return this;
        }

        public AddQuotePage EnterRoomLocation()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(roomlocation, 10000);
            roomlocation.SendKeys("Cordlock");
            roomlocation.SendKeys(Keys.Enter);
            return this;
        }

        

        public AddQuotePage SelectProduct()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(ProductCode, 10000);
            ProductCode.SendKeys("Faux Wood Blinds");
            ProductCode.SendKeys(Keys.Enter);
            return this;
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
            foreach (Tuple<string, string> product in productDetails)
            {

                Thread.Sleep(4000);
                // string check = productDetails[0].Item1;
                driver.FindElement(By.Id(product.Item1)).SendKeys(product.Item2);
                Thread.Sleep(4000);
                driver.FindElement(By.Id(product.Item1)).SendKeys(Keys.Enter);
                Thread.Sleep(4000);
            }
            return this;
        }

     
        public AddQuotePage SelectMounting()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Mounting, 10000);
            Mounting.SendKeys("Inside Mount");
            Mounting.SendKeys(Keys.Enter);
            return this;
        }

        public AddQuotePage SelectColor()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Color, 10000);
            Color.SendKeys("Cloud");
            Color.SendKeys(Keys.Enter);
            return this;
        }

        public AddQuotePage SelectNumberOnHeadrails()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(NumberOnHeadrail, 10000);
            NumberOnHeadrail.SendKeys("Standard");
            NumberOnHeadrail.SendKeys(Keys.Enter);
            return this;
        }

        public AddQuotePage SelectLiftSystem()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(LiftSystem, 10000);
            LiftSystem.SendKeys("Cordlock");
            LiftSystem.SendKeys(Keys.Enter);

            return this;
        }

        public AddQuotePage SelectTiltControl()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(TiltControl, 10000);
            TiltControl.SendKeys("Cord Tilt");
            TiltControl.SendKeys(Keys.Enter);
            OkButton.Clickme(driver);
            return this;
        }

        public AddQuotePage SelectControlPosition()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(ControlLocation, 10000);
            ControlLocation.SendKeys("Til Left/Lift Right");
            ControlLocation.SendKeys(Keys.Enter);
            return this;
        }

        public AddQuotePage SelectValance()
        {
            Thread.Sleep(4000);
            driver.WaitForElementToBecomeVisibleWithinTimeout(Valance, 10000);
            Valance.SendKeys("Standard");
            Valance.SendKeys(Keys.Enter);
            return this;
        }
    }
}
