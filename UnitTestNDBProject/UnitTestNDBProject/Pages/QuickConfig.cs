using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Page;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;
using UnitTestNDBProject.Base;
using System.Threading;

namespace UnitTestNDBProject.Pages
{
    public class QuickConfig
    {
        public IWebDriver driver;
        private Logger _logger = LogManager.GetCurrentClassLogger();
        private int implicitWait;

        public QuickConfig(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "//div[@class='customer-tab active']/h3")]
        public IWebElement AddQuoteCustomerText { get; set; }



        public static ProductLineData GetProductLine1Data(ParsedTestData featureData)
        {
            object ProductLine1Value = DataAccess.GetKeyJsonData(featureData, "Product1");
            return JsonDataParser<ProductLineData>.ParseData(ProductLine1Value);
        }

        public QuickConfig WaitUntilPageload()
        {

            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }

        public void AddProduct(ProductLineData data,QuotePage _QuotePage, OrderPage _OrderPage)
        {
            _QuotePage.EnterWidth(data.Width).EnterHeight(data.Height).EnterRoomLocation(data.NDBRoomLocation)
                .SelectProduct(data.ProductType).SelectProductOptions(data.ProductDetails);
                
                _OrderPage.ClickAddProductButton().WaitUntilPageload();

        }

        public bool VerifyUserNavigatedToCustomerPage()
        {
            bool IsTextPresent = false;

            driver.WaitForElement(AddQuoteCustomerText);
            String Expected = Constants.AddQuoteToCustomer;
            String Actual = AddQuoteCustomerText.GetText(driver);

            if (Actual.Equals(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that User navigated from quick config page to customer page");
            }
            return IsTextPresent;


        }

        public bool VerifyQuoteIsCreated()
        {
            bool IsTextPresent = false;

            new System.Threading.ManualResetEvent(false).WaitOne(3000);
            WaitUntilPageload();
            String Expected = Constants.AddQuoteToCustomer;
            String Actual = AddQuoteCustomerText.GetText(driver);

            if (Actual.Equals(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that User navigated from quick config page to customer page");
            }
            return IsTextPresent;


        }
    }
}
