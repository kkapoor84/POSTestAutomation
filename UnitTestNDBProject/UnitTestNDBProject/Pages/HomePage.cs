﻿using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Pages
{
    public class HomePage
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public static By DashBoardTab = By.XPath("//button[@name='Dashboard']");
        public static By DepositSummaryTab = By.XPath("//button[@name='Deposit_Summary']");
        public static By ShopAtHomeTab = By.XPath("//button[@name='Shop_At_Home']");
        public static By ResourcesTab = By.XPath("//button[@name='Resources']");
        public static By Settings = By.XPath("//button[@id='settingsTab']");
        public static By DashBoardTabText = By.XPath("//div[contains(text(),'QUOTES')]");
        public static By DepositSummaryText = By.XPath("//h2[contains(text(),'DEPOSIT SUMMARY')]");



        public void ClickDashBoardTab()
        {
            driver.WaitForElement(DashBoardTab);
            DashBoardTab.Clickme(driver);
        }


        public bool VerifyDashBoardTabIsClicked()
        {
            bool IsTextPresent = false;

            String Expected = "QUOTES";
            String Actual = DashBoardTabText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
            }
            return IsTextPresent;


        }

        public void ClickDepositSummaryTab()
        {
            driver.WaitForElement(DepositSummaryTab);
            DepositSummaryTab.Clickme(driver);
        }


        public bool VerifyDepositSummaryTabIsClicked()
        {
            bool IsTextPresent = false;

            String Expected = "DEPOSIT SUMMARY";
            String Actual = DepositSummaryText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
            }
            return IsTextPresent;


        }

        public void ClickShopAtHomeTab()
        {
            driver.WaitForElement(DepositSummaryTab);
            DepositSummaryTab.Clickme(driver);
        }


        public bool VerifyShopAtHomeTabIsClicked()
        {
            bool IsTextPresent = false;

            String Expected = "DEPOSIT SUMMARY";
            String Actual = DepositSummaryText.GetText(driver);

            if (Actual.Contains(Expected))
            {
                IsTextPresent = true;
            }
            return IsTextPresent;


        }

    }
}
