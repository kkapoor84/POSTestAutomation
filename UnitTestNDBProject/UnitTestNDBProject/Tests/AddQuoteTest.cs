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
            LoginPage_.EnterUserName(loginData.Username).EnterPassword(loginData.Password).ClickLoginButton();

            //SheetData sheetData1 = ExcelDataAccess.GetTestData("LoginScreen$", "SAHUserValidCredentails");
            //LoginPage_.EnterUserName(sheetData1.Username).EnterPassword(sheetData1.Password).ClickLoginButton();
            //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");



            // object productLineData = DataAccess.GetKeyJsonData(loginFeatureParsedData, "AccountUserValidCredentails");
            //oginData loginData = JsonDataParser<LoginData>.ParseData(accountingLoginData);
        }

        [Test, Category("Regression"), Category("Smoke"), Description("Enter Customer Card Details and create new customer")]
        public void A5_VerifyProductCreation()
        {
            productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            ProductLineData productLine = JsonDataParser<ProductLineData>.ParseData(productLineData);
            //productLineFeatureParsedData = DataAccess.GetFeatureData("ProductLineScreen");
            //object productLineData = DataAccess.GetKeyJsonData(productLineFeatureParsedData, "Product1");
            //ProductLineData productLine = JsonDataParser<productLineData>.ParseData(productLineData);

            //List<Tuple<string, string>> productLists = commonTest.AddProductDetails(AddQuotePage_, productLine.ProductDetails);
            //foreach (Tuple<string, string> product in productLists)
            //{
            //    _logger.Info($": Successfully Entered Option Type {product.Item1} , Option {product.Item2}");
            //}
            AddQuotePage_.SearchFunction().ClickOnAddNewQuote().ClickOnAddProduct().EnterWidth().EnterHeight().EnterRoomLocation().SelectProduct();
                
                //.SelectProduct().SelectMounting().SelectColor()
            //  .SelectNumberOnHeadrails().SelectLiftSystem().SelectTiltControl().SelectControlPosition().SelectValance();
            AddQuotePage_.getProductDetails();
            AddQuotePage_.SelectMountingDynamic();

        }
    }
}
