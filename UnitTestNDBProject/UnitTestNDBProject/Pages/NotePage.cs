using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading;
using UnitTestNDBProject.TestDataAccess;
using SeleniumExtras.PageObjects;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using System.Globalization;

namespace UnitTestNDBProject.Page
{
    public class NotePage
    {

        public IWebDriver driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public List<string> Products;

        public NotePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='focus-on-edit']")]
        public IWebElement InternalInfo { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@class='btn-blue-link-arrow']")]
        public IWebElement ViewOrderLink { get; set; }


        /// <summary>
        /// Wait until page is loaded
        /// </summary>
        /// <returns></returns>
        public NotePage WaitUntilPageload()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='loader-overlay-section']")));
            driver.waitForElementNotVisible("//div[@class='loader-overlay-section']");
            _logger.Info($" Wait until loader is loaded");
            return this;
        }

        /// <summary>
        /// Verifying details for no deposit on notes page
        /// </summary>
        /// <param name="ExpReason"></param>
        /// <param name="ExpDetail"></param>
        /// <returns></returns>
        public Boolean VerifyNoDepositReasonAndDetailOnNotePage(String ExpReason, String ExpDetail)
        {
            Boolean IsDetailCorrect = false;
            String NoDepositHeader = driver.FindElement(By.XPath("//span[@class='form-label note-type-header']")).GetText(driver);
            String ActualReason = driver.FindElement(By.XPath("//span[@class='form-value text-line-break']")).GetText(driver);
            String ActualDetail = driver.FindElement(By.XPath("//span[@class='form-value user-name-value text-line-break']")).GetText(driver);

            if (NoDepositHeader.Contains("No Deposit Note"))
            {
                if (ActualReason.Equals(ExpReason) && ActualDetail.Equals(ExpDetail))
                {
                    IsDetailCorrect = true;
                }
            }


            return IsDetailCorrect;
        }

        public Boolean VerifyShortDepositReasonAndDetailOnNotePage(String ExpDetail)
        {
            Boolean IsDetailCorrect = false;
            String ShortDepositHeader = driver.FindElement(By.XPath("//div[@class='notes-right-panel']//span[contains(text(),'Short Deposit Note')]")).GetText(driver);
            String ActualDetail = driver.FindElement(By.XPath("//span[contains(text(),'Short Deposit Note')]/following-sibling::span")).GetText(driver);

            if (ShortDepositHeader.Contains("Short Deposit Note"))
            {
                if (ActualDetail.Equals(ExpDetail))
                {
                    IsDetailCorrect = true;
                }
            }


            return IsDetailCorrect;
        }

        

        public NotePage ClickOnViewOrderLink()

        {
            driver.WaitForElement(ViewOrderLink);
            ViewOrderLink.Clickme(driver);
            WaitUntilPageload();
            new System.Threading.ManualResetEvent(false).WaitOne(2000);
            return this;

        }

    }

}

