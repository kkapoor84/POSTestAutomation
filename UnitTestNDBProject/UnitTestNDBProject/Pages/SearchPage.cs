using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
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
        public IWebElement ReadEmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-results']/div[1]/div[1]/div[1]/div[1]")]
        public IWebElement ReadNameOnSearchPage { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='no-result-text']")]
        public IWebElement NoCustomer { get; set; }

        [FindsBy(How = How.ClassName, Using = "recent-search-link")]
        public IWebElement recentSearch { get; set; }

        [FindsBy(How = How.Id, Using = "show-all-phone-numbers")]
        public IWebElement showMorePhone { get; set; }

        [FindsBy(How = How.Id, Using = "show-all-email-addresses")]
        public IWebElement showMoreEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/h3[1]")]
        public IWebElement customerWidget { get; set; }

        public static string phoneNumberOnSearchPageStaticVariable = "";
        public static string emailAddressOnSearchPageStaticVariable = "";
        public static string NameOnSearchPageStaticVariable = "";

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

        public SearchPage WaitPolling()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            return this;
        }
        /// <summary>
        /// wait for polling
        /// </summary>
        /// <returns></returns>
        public SearchPage WaitPolling()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
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

        /// <summary>
        /// Function to Enter First Name for search
        /// </summary>
        /// <param name="fname"></param>
        /// <returns></returns>
        public SearchPage EnterFirstName(String fname)
        {
            FirstName.EnterText(fname);
            _logger.Info($" Entered first Name Of Customer To be searched.");
            return this;
        }

        /// <summary>
        /// Function to Enter last Name for search
        /// </summary>
        /// <param name="lname"></param>
        /// <returns></returns>
        public SearchPage EnterLastName(String lname)
        {
            LastName.EnterText(lname);
            _logger.Info($" Entered last Name Of Customer To be searched.");
            return this;
        }

        /// <summary>
        /// Function To Click On required searched customer
        /// </summary>
        /// <returns></returns>
        public SearchPage ClickOnSearchResultForCustomer()
        {
            WaitUntilPageload();
            phoneNumberOnSearchPageStaticVariable =  ReadPhone();
            emailAddressOnSearchPageStaticVariable = ReadEmail();
            NameOnSearchPageStaticVariable = ReadName();
            ClickOnSearchResult.Clickme(driver);
            _logger.Info($" Selected Customer from Search result.");
            return this;
        }

        /// <summary>
        /// Function to verify last search link exists
        /// </summary>
        /// <returns></returns>
        public bool VerifySearchLinkOfLastSearch()
        {
            WaitUntilPageload();
            bool linkIsAvailable = false;
            if (recentSearch.Displayed)
                linkIsAvailable = true;
            return linkIsAvailable;
        }

        /// <summary>
        /// Function to read name on search page
        /// </summary>
        /// <returns></returns>

        public string ReadName()
        {
            string phone = ReadNameOnSearchPage.GetText(driver);
            _logger.Info($" Read Name Of the customer.");
            return phone;
        }

        /// <summary>
        /// Function to read phone number on search page
        /// </summary>
        /// <returns></returns>
        public string ReadPhone()
        {
            string phone = ReadPhoneNumber.GetText(driver);
            _logger.Info($" Read Phone Of the customer.");
            return phone;
        }

        /// <summary>
        /// Function to read email address on search page
        /// </summary>
        /// <returns></returns>
        public string ReadEmail()
        {
            string email = ReadEmailAddress.GetText(driver);
            return email;
        }

        /// <summary>
        /// Verify First Name and Last name
        /// </summary>
        /// <returns></returns>
        public bool VerifyFirstNameLastName()
        {
            bool correctNameIsDisplayed = false;
            String nameOnSearchPage = NameOnSearchPageStaticVariable;
            String nameOnCustomerPage = customerWidget.GetText(driver);
            if (nameOnCustomerPage.Equals(nameOnSearchPage))
            {
                correctNameIsDisplayed = true;
                _logger.Info($" Name " + nameOnSearchPage + " exists for on customer page.");
            }
            return correctNameIsDisplayed;
        }

        /// <summary>
        /// Function to verify correct phone is displayed.
        /// </summary>
        /// <returns></returns>
        public bool VerifyCorrectPhoneNumber()
        {

            WaitUntilPageload();
            int counter = 0;
            String phoneNumberOnSearchPage = phoneNumberOnSearchPageStaticVariable;
            WaitPolling();
            string[] phoneNumberArray = new string[100];
            if (showMorePhone.Displayed)
            {
                WaitPolling();
                showMorePhone.Clickme(driver);
            }
            
                do
                {
                    WaitPolling();
                    string phoneNumber = driver.FindElement(By.XPath("//div[@id='customer-info-phone-" + counter + "']")).GetText(driver);
                    phoneNumberArray[counter] = phoneNumber;
                    counter++;
                } while (By.XPath("//div[@id='customer-info-phone-" + counter + "']").isPresent(driver));
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

        /// <summary>
        /// Function to verify correct email is displayed.
        /// </summary>
        /// <returns></returns>
        public bool VerifyCorrectEmailAddress()
        {
            WaitUntilPageload();
            int counter = 0;
            String emailAddressOnSearchPage = emailAddressOnSearchPageStaticVariable;
            string[] emailAddressArray = new string[100];
            if (showMoreEmail.Displayed)
            {
                WaitPolling();
                showMoreEmail.Clickme(driver);
            }
            do
            {
                WaitPolling();
                string emailAddress = driver.FindElement(By.XPath("//div[@id='customer-info-email-"+ counter + "']")).GetText(driver);
                emailAddressArray[counter] = emailAddress;
                counter++;
            } while (By.XPath("//div[@id='customer-info-email-" + counter + "']").isPresent(driver));
            bool emailAddressIsCorrect = false;
            int j = 0;
            do
            {
                if (emailAddressOnSearchPage.Contains((emailAddressArray[j])))
                {
                    emailAddressIsCorrect = true;
                    _logger.Info($" Email " + emailAddressOnSearchPage + " exists for the customer");
                    break;
                }
                j++;
            } while (emailAddressArray[j] != null);
            return emailAddressIsCorrect;

        }

        /// <summary>
        /// Function to verify customer flow executes only if customers are displayed in search result.
        /// </summary>
        public void ExecuteSearchFlowIfCustomerExists()
        {
            if (By.XPath("//div[@class='no-result-text']").isPresent(driver))
            {
                WaitPolling();
                _logger.Info($"No Customer exists for this search criteria.");
            }
            else
            {
                WaitPolling();
                ClickOnSearchResultForCustomer();
                Assert.True(VerifyCorrectPhoneNumber());
                Assert.True(VerifyCorrectEmailAddress());
                Assert.True(VerifyFirstNameLastName());
            }
        }

        public SearchPage EnterSameSearchCriteria()
        {
            recentSearch.Clickme(driver);
            return this;
        }
    }
}
