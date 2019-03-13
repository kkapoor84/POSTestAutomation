using NLog;
using OpenQA.Selenium;
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
        public static By ResourcesTabText = By.XPath("//h2[contains(text(),'POS DOCUMENTS')]");
        public static By SettingTabText = By.XPath("//h2[contains(text(),'DocuSign Consent')]");
        public static By title = By.XPath("//h1[contains(text(),'Point of Sale Home Page')]");
        public static By homeSignoutIcon = By.XPath("//i[@class='icon-account']");
        public static By signoutButton = By.XPath("//a[contains(text(),'Log Out')]");
        public static By SAPLead = By.XPath("//div[contains(text(),'LEADS')]");



        public void ClickDashBoardTab()
        {

            driver.WaitForElement(DashBoardTab);
            DashBoardTab.Clickme(driver);
        }

        public void ClickDepositSummaryTab()
        {
            driver.WaitForElement(DepositSummaryTab);
            DepositSummaryTab.Clickme(driver);
        }

        public void Signout()
        {
            homeSignoutIcon.Clickme(driver);
            driver.WaitForElement(signoutButton);
            signoutButton.Clickme(driver);
        }

        public void ClickShopAtHomeTab()
        {
            driver.WaitForElement(ShopAtHomeTab);
            ShopAtHomeTab.Clickme(driver);
            driver.WaitForElement(SAPLead);


        }


        public void ClickResourcesTab()
        {

            driver.WaitForElement(ResourcesTab);
            ResourcesTab.Clickme(driver);
        }

        public void ClickSettingTab()
        {

            driver.WaitForElement(Settings);
            Settings.Clickme(driver);
        }
        public bool VerifyHomePageTitle()
        {
            _logger.Info($"Valid Credentials");
            driver.WaitForElement(title);
            bool isTitlePresent = false;
            String ActualValue = title.GetText(driver);
            String ExpectedValue = "Point of Sale Home Page";
            if (ActualValue.Contains(ExpectedValue))
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
            _logger.Info($"Valid Credentials");
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
