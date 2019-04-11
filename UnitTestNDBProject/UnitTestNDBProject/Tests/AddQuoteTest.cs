using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.TestDataAccess;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class AddQuoteTest : BaseTestClass
    {
        private Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private static ParsedTestData productLineFeatureParsedData;
        private static ParsedTestData loginFeatureParsedData;
        CommonTest commonTest;

        [SetUp]
        public void Setup()
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            commonTest = new CommonTest();
            loginFeatureParsedData = DataAccess.GetFeatureData("LoginScreen");
            object accountingLoginData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "SAHUserValidCredentails");
            LoginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
            _LoginPage.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            //SheetData sheetData1 = ExcelDataAccess.GetTestData("LoginScreen$", "SAHUserValidCredentails");
            //LoginPage_.EnterUserName(sheetData1.Username).EnterPassword(sheetData1.Password).ClickLoginButton();
            //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");



            // object productLineData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "AccountUserValidCredentails");
            //oginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A5_VerifyProductCreation()
        {
            Thread.Sleep(6000);
            _AddQuotePage.SearchFunction().ClickOnAddNewQuote();

            _AddQuotePage.AddMultipleProducts(productLineFeatureParsedData.Data);


            //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            //object productLineData1 = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            //ProductLineData productLine1 = JsonDataParser<ProductLineData>.ParseData(productLineData1);

            //object productLineData2 = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product2");
            //ProductLineData productLine2 = JsonDataParser<ProductLineData>.ParseData(productLineData2);

            //object productLineData3 = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product3");
            //ProductLineData productLine3 = JsonDataParser<ProductLineData>.ParseData(productLineData3);


            //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            //object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            //ProductLineData productLine = JsonDataParser<productLineData>.ParseData(productLineData);

            //List<Tuple<string, string>> productLists = commonTest.AddProductDetails(AddQuotePage_, productLine.ProductDetails);
            //foreach (Tuple<string, string> product in productLists)
            //{
            //    _logger.Info($": Successfully Entered Option Type {product.Item1} , Option {product.Item2}");
            //}
         /*   _AddQuotePage.SearchFunction().ClickOnAddNewQuote().ClickOnAddProduct().EnterWidth(productLine1.Width).EnterHeight(productLine1.Height)
                .EnterRoomLocation(productLine1.NDBRoomLocation).SelectProduct(productLine1.ProductType).SelectMountingDynamic().ClickAddProductButton();

            _AddQuotePage.ClickOnAddProduct().EnterWidth(productLine2.Width).EnterHeight(productLine2.Height)
               .EnterRoomLocation(productLine2.NDBRoomLocation).SelectProduct(productLine2.ProductType).SelectMountingDynamic().ClickAddProductButton();

            _AddQuotePage.ClickOnAddProduct().EnterWidth(productLine3.Width).EnterHeight(productLine3.Height)
               .EnterRoomLocation(productLine3.NDBRoomLocation).SelectProduct(productLine3.ProductType).SelectMountingDynamic().ClickAddProductButton();
               */
            //AddQuotePage_.getProductDetails();


            //AddQuotePage_.ClickOnAddProduct().EnterWidth().EnterHeight().EnterRoomLocation().SelectHoneycombShade();
            //AddQuotePage_.getProductDetails();
            //AddQuotePage_.SelectMountingDynamic().ClickAddProductButton();

            //AddQuotePage_.ClickOnAddProduct().EnterWidth().EnterHeight().EnterRoomLocation().SelectDeluxeBlinds();
            //AddQuotePage_.getProductDetails();
            //AddQuotePage_.SelectMountingDynamic().ClickAddProductButton();

        }
    }
}
