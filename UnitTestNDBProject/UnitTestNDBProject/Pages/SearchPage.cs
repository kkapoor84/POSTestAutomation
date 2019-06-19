using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestNDBProject.Pages
{
    public class SearchPage
    {
        public IWebDriver driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public List<Tuple<string, string>> newPhones;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'SEARCH')]")]
        public IWebElement Search { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'ORDER NUMBER')]")]
        public IWebElement SearchOrder { get; set; }

        [FindsBy(How = How.Id, Using = "orderNumber")]
        public IWebElement EnterOrder { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Search')]")]
        public IWebElement SearchButtonClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'QUOTE NUMBER')]")]
        public IWebElement SearchQuote { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name='quoteNumber']")]
        public IWebElement EnterQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'QUOTE')]")]
        public IWebElement QuoteNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'ORDER')]")]
        public IWebElement OrderNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='no-result-text']")]
        public IWebElement NoResult { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-results']/div[1]/div[1]/div[1]/div[1]/div[1]")]
        public IWebElement ClickOnSearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-results']//div[1]//div[1]//div[1]//li[1]//span[2]")]
        public IWebElement ReadPhoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-results']//div[1]//div[1]//div[1]//li[2]//span[2]")]
        public IWebElement ReadEmail { get; set; }

        [FindsBy(How = How.ClassName, Using = "recent-search-link")]
        public IWebElement recentSearch { get; set; }

        public static SearchData SearchQuoteData(ParsedTestData featureData)
        {
            object quoteNumber = DataAccess.GetKeyJsonData(featureData, "QuoteNumberForSearch");
            return JsonDataParser<SearchData>.ParseData(quoteNumber);
        }
        public static SearchData SearchOrderData(ParsedTestData featureData)
        {
            object orderNumber = DataAccess.GetKeyJsonData(featureData, "OrderNumberForSearch");
            return JsonDataParser<SearchData>.ParseData(orderNumber);
        }

        /// <summary>
        /// wait until page load in not complete
        /// </summary>
        /// <returns></returns>
        public SearchPage WaitUntilPageload()
        {

            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }

        /// <summary>
        /// Click On search link
        /// </summary>
        /// <returns></returns>

        public SearchPage ClickOnSearchLink()
        {
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            autoEvent.WaitOne(4000);
            WaitUntilPageload();
            Search.Clickme(driver);
            _logger.Info($" User clicked on search button on top navigation panel");
            return this;
        }

        /// <summary>
        /// Click On Quote Tab of search page
        /// </summary>
        /// <returns></returns>
        public SearchPage ClickOnQuoteTab()
        {
            WaitUntilPageload();
            SearchQuote.Clickme(driver);
            _logger.Info($" Clicked on search for quote tab successfully.");
            return this;
        }

        /// <summary>
        /// Click On Order Tab of search page
        /// </summary>
        /// <returns></returns>
        public SearchPage ClickOnOrderTab()
        {
            WaitUntilPageload();
            SearchOrder.Clickme(driver);
            _logger.Info($" Clicked on search for order tab successfully.");
            return this;
        }

        /// <summary>
        /// Enter the quote number to be searched.
        /// </summary>
        /// <param name="QuoteNumber"></param>
        /// <returns></returns>
        public SearchPage EnterQuoteToSearch(String QuoteNumber)
        {
            WaitUntilPageload();
            EnterQuote.EnterText(QuoteNumber);
            _logger.Info($" User entered quote{QuoteNumber}");
            return this;
        }

        /// <summary>
        /// Search for an invalid quote number
        /// </summary>
        /// <param name="QuoteNumber"></param>
        /// <returns></returns>
        public SearchPage EnterInvalidQuoteToSearch(String QuoteNumber)
        {
            WaitUntilPageload();
            string  invalidQuoteNumber = CommonFunctions.RandomizeQuote(QuoteNumber);
            EnterQuote.EnterText(invalidQuoteNumber);
            _logger.Info($" User entered quote{invalidQuoteNumber}");
            return this;
        }

        /// <summary>
        /// Search for an invalid order number
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public SearchPage EnterInvalidOrderToSearch(String OrderNumber)
        {
            WaitUntilPageload();
            string invalidOrderNumber = CommonFunctions.RandomizeQuote(OrderNumber);
            EnterOrder.EnterText(invalidOrderNumber);
            _logger.Info($" User entered quote{invalidOrderNumber}");
            return this;
        }

        /// <summary>
        /// Enter the order number to be searched.
        /// </summary>
        /// <param name="QuoteNumber"></param>
        /// <returns></returns>
        public SearchPage EnterOrderToSearch(String OrderNumber)
        {
            WaitUntilPageload();
            EnterOrder.EnterText(OrderNumber);
            _logger.Info($" User entered quote{OrderNumber}");
            return this;
        }

        /// <summary>
        /// Click On Enter Button to search required quote
        /// </summary>
        /// <returns></returns>
        public SearchPage ClickOnSearchButton()
        {
            WaitUntilPageload();
            SearchButtonClick.Clickme(driver);
            _logger.Info($" User clicked on search button");
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            autoEvent.WaitOne(6000);
            return this;
        }

        /// <summary>
        /// Verify User Navigated to correct page.  
        /// </summary>
        /// <param name="expectedQuoteNumber"></param>
        /// <returns></returns>
        public Boolean VerifyUserNavigatedToCorrectQuote(String expectedQuoteNumber)
        {
            WaitUntilPageload();
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            autoEvent.WaitOne(4000);
            Boolean quoteNumberIsCorrect = false;
            String quoteNumberOnScreen = QuoteNumber.GetText(driver);
            if (quoteNumberOnScreen.Contains(expectedQuoteNumber))
                quoteNumberIsCorrect = true;
            return quoteNumberIsCorrect;
        }

        /// <summary>
        /// Verify user navigated no correct order
        /// </summary>
        /// <param name="expectedOrderNumber"></param>
        /// <returns></returns>
        public Boolean VerifyUserNavigatedToCorrectOrder(String expectedOrderNumber)
        {
            WaitUntilPageload();
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            autoEvent.WaitOne(4000);
            Boolean orderNumberIsCorrect = false;
            String orderNumberOnScreen = OrderNumber.GetText(driver);
            if (orderNumberOnScreen.Contains(expectedOrderNumber))
                orderNumberIsCorrect = true;
            return orderNumberIsCorrect;

        }

        /// <summary>
        /// Verify No Result Message for quote
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyNoResultFoundForQuote()
        {
            Boolean noResultFoundText = false;
            String textOFNoResultFound = NoResult.GetText(driver);
            String expectedText = Constants.NoQuoteMessage;
            if (textOFNoResultFound.Equals(expectedText))
                noResultFoundText = true;
            return noResultFoundText;
        }

        /// <summary>
        /// Verify No Result Message for order
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyNoResultFoundForOrder()
        {
            Boolean noResultFoundText = false;
            String textOFNoResultFound = NoResult.GetText(driver);
            String expectedText = Constants.NoOrderMessage;
            if (textOFNoResultFound.Equals(expectedText))
                noResultFoundText = true;
            return noResultFoundText;
        }

        /// <summary>
        /// Clear Text Before entering valid order
        /// </summary>
        /// <returns></returns>
        public SearchPage ClearTextOFOrder()
        {
            WaitUntilPageload();
            EnterOrder.Clear();
            return this;
        }

        /// <summary>
        /// Clear Text Before entering valid quote
        /// </summary>
        /// <returns></returns>
        public SearchPage ClearTextOFQuote()
        {
            WaitUntilPageload();
            EnterQuote.Clear();
            return this;
        }

        public SearchPage EnterFirstName(String fname)
        {
            FirstName.EnterText(fname);
            return this;
        }
        public SearchPage EnterLastName(String lname)
        {
            LastName.EnterText(lname);
            return this;
        }

        public SearchPage ClickOnSearchResultForCustomer()
        {
            WaitUntilPageload();
            ClickOnSearchResult.Clickme(driver);
            return this;
        }

        public bool VerifySearchLinkOfLastSearch()
        {
            WaitUntilPageload();
            bool linkIsAvailable = false;
            if (recentSearch.Displayed)
                linkIsAvailable = true;
            return linkIsAvailable;
        }

        public string ReadPhone()
        {
            string phone = ReadPhoneNumber.GetText(driver);
            return phone;
        }
        public bool VerifyCorrectPhoneNumber()
        {
            WaitUntilPageload();
            int i = 0;
            String phoneNumberOnSearchPage = ReadPhone();
            string[] phoneNumberArray = new string[100];
            do
            {
                string phoneNumber = driver.FindElement(By.Id("phoneLists[" + i + "].Phone")).GetAttribute("value");
                string actualPhoneNumber = string.Concat(phoneNumber.Substring(1, 3), phoneNumber.Substring(6, 3), phoneNumber.Substring(10, 4));
                phoneNumberArray[i] = actualPhoneNumber;
                i++;
            } while (By.Id("phoneLists[" + i + "].Phone").isPresent(driver));
            bool phoneNumberIsCorrect = false;
            int j = 0;
            do
            {
                if (phoneNumberOnSearchPage.Contains((phoneNumberArray[j])))
                {
                    phoneNumberIsCorrect = true;
                    _logger.Info($" Phone " + phoneNumberOnSearchPage + " exists for the customer");
                    break;
                }
                j++;
            } while (phoneNumberArray[j] != null);
            return phoneNumberIsCorrect;

        }
    }
}
