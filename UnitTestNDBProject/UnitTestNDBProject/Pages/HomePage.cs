﻿using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Pages
{
    public class HomePage
    {
        public IWebDriver driver;
        private Logger _logger = LogManager.GetCurrentClassLogger();
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//button[@name='Dashboard']")]
        public IWebElement DashBoardTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='Deposit_Summary']")]
        public IWebElement DepositSummaryTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='Shop_At_Home']")]
        public IWebElement ShopAtHomeTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='Resources']")]
        public IWebElement ResourcesTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='settingsTab']")]
        public IWebElement Settings { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'QUOTES')]")]
        public IWebElement DashBoardTabText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'DEPOSIT SUMMARY')]")]
        public IWebElement DepositSummaryText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'POS DOCUMENTS')]")]
        public IWebElement ResourcesTabText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'DocuSign Consent')]")]
        public IWebElement SettingTabText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Point of Sale Home Page')]")]
        public IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-account']")]
        public IWebElement homeSignoutIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Log Out')]")]
        public IWebElement signoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'LEADS')]")]
        public IWebElement SAPLead { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'QUICK CONFIG')]")]
        public IWebElement QuickConfigLink { get; set; }

        public void ClickDashBoardTab()
        {
           DashBoardTab.Clickme(driver);
            _logger.Info($": Successfully Clicked on Dashboard Tab on homepage");
        }

        public void ClickDepositSummaryTab()
        {
            DepositSummaryTab.Clickme(driver);
            _logger.Info($": Successfully Clicked on Deposit Summary Tab on homepage");
        }

        public void Signout()
        {
            homeSignoutIcon.Clickme(driver);
            _logger.Info($": Successfully Clicked on Signout button");
            driver.WaitForElement(signoutButton);
            signoutButton.Clickme(driver);
        }

        public HomePage ClickShopAtHomeTab()
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(ShopAtHomeTab, 5000);
            ShopAtHomeTab.Clickme(driver);
            _logger.Info($": Successfully Clicked on Shop at Home Tab on homepage");
            driver.WaitForElementToBecomeVisibleWithinTimeout(SAPLead, 7000);
            return this;
        }


        public HomePage ClickOnQuickConfig()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(5000);
            driver.WaitForElement(QuickConfigLink);
            QuickConfigLink.Clickme(driver);
            _logger.Info($": Successfully Clicked on QuickConfig link on homepage");
            return this;
        }



        public void ClickResourcesTab()
        {
            ResourcesTab.Clickme(driver);
            _logger.Info($": Successfully Clicked on Resources Tab on homepage");
        }

        public void ClickSettingTab()
        {
           Settings.Clickme(driver);
            _logger.Info($": Successfully Clicked on Setting Tab on homepage");
        }

        public bool VerifyHomePageTitle(String ExpectedTitle)
        {
            driver.WaitForElementToBecomeVisibleWithinTimeout(title,5000);
            bool isTitlePresent = false;
            String ActualValue = title.GetText(driver);
            if (ActualValue.Contains(ExpectedTitle))
            {
                isTitlePresent = true;
                _logger.Info($" :Verified the home page title on {this.GetType().Name}");
            }
            return isTitlePresent;

        }

        public bool VerifyDashBoardTabIsClicked()
        {
            bool IsTextPresent = false;

            String Expected = "QUOTES";
            String Actual = DashBoardTabText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that Dashboard tab is clicked and accessible on{this.GetType().Name}");
            }
            return IsTextPresent;


        }

        public bool VerifyDepositSummaryTabIsClicked()
        {
            bool IsTextPresent = false;

            String Expected = "DEPOSIT SUMMARY";
            String Actual = DepositSummaryText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that Deposit Summary tab is clicked and accessible on{this.GetType().Name}"); ;
            }
            return IsTextPresent;


        }

        public bool VerifyShopAtHomeTabIsClicked()
        {
            bool IsTextPresent1 = false;

            String Expected = "LEADS";
            String Actual = SAPLead.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent1 = true;
                _logger.Info($" :Verified that Shop At Home tab is clicked and accessible on {this.GetType().Name}");
            }
            return IsTextPresent1;
        }

        public bool VerifyResourceTabIsClicked()
        {

            bool IsTextPresent = false;

            String Expected = "POS DOCUMENTS";
            String Actual = ResourcesTabText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that Resource tab is clicked and accessible on {this.GetType().Name}");
            }
            return IsTextPresent;
        }

        public bool VerifySettingTabIsClicked()
        {

            bool IsTextPresent = false;

            String Expected = "DocuSign Consent";
            String Actual = SettingTabText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
                _logger.Info($" :Verified that Setting tab is clicked and accessible on {this.GetType().Name}");
            }
            return IsTextPresent;
        }

    }
}
