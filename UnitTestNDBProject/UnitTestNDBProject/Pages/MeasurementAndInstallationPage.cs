using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestNDBProject.Pages
{
    public class MeasurementAndInstallationPage
    {
        public IWebDriver driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MeasurementAndInstallationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='idAddDirections']//i[@class='icon-plus-circle']")]
        public IWebElement AddDirectionButton { get; set; }


        [FindsBy(How = How.Id, Using = "idDirections")]
        public IWebElement DirectionTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "idBtnOK")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.Id, Using = "doneInstallation")]
        public IWebElement SaveChangesButtonOnInstallationPage { get; set; }

        [FindsBy(How = How.Id, Using = "checkbox-Ladder")]
        public IWebElement LadderCheckBox { get; set; }


        [FindsBy(How = How.Id, Using = "idAddMeasureNotes")]
        public IWebElement MeasurementNotesButton { get; set; }

        [FindsBy(How = How.Id, Using = "idMeasureNotes")]
        public IWebElement MeasurementNotesTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='add-phone']//i[@class='icon-plus-circle']")]
        public IWebElement InstallerNotesButton { get; set; }

        [FindsBy(How = How.Id, Using = "textAreaInstaller")]
        public IWebElement InstallerNotesTextBox { get; set; }


        [FindsBy(How = How.Id, Using = "checkbox-isAdditionalCosts")]
        public IWebElement AdditionalCostCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "otherInstallCharges")]
        public IWebElement AdditionalCostAmount { get; set; }

        [FindsBy(How = How.Id, Using = "otherInstallCostSurchargeReasonId")]
        public IWebElement AdditionalCostReason { get; set; }


        [FindsBy(How = How.Id, Using = "checkbox-isAdditionalMin")]
        public IWebElement AdditionalMinCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "additionalInstallationMinutes")]
        public IWebElement AdditionalMinAmount { get; set; }

        [FindsBy(How = How.Id, Using = "otherInstallMinSurchargeReasonId")]
        public IWebElement AdditionalMinReason { get; set; }




        public static MeasurementAndInstallationData GetMeasurementAndInstallationData(ParsedTestData featureData)
        {
            object measurementAndInstallationPageData = DataAccess.GetKeyJsonData(featureData, "MeasurementAndInstallationScreenKey");
            return JsonDataParser<MeasurementAndInstallationData>.ParseData(measurementAndInstallationPageData);
            
        }

        public MeasurementAndInstallationPage AddDirections(String dirction)
        {
            WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            customWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='idAddDirections']//i[@class='icon-plus-circle']")));
            AddDirectionButton.Clickme(driver);
            DirectionTextBox.EnterText(dirction);
            return this;
           
        }
        public MeasurementAndInstallationPage ClickOnLadder(Boolean ladder)
        {

            if (ladder is true)
            {
                LadderCheckBox.Clickme(driver);
            }
            else
            {
                _logger.Info("Do not click on ladder chceckbox");
            }
        
            return this;

        }
        public MeasurementAndInstallationPage AddMeasurerNotes(String notes)
        {
            MeasurementNotesButton.Clickme(driver);
            MeasurementNotesTextBox.EnterText(notes);
            return this;

        }

        public MeasurementAndInstallationPage AddAdditionalCost(Boolean addcost,String costAmount, String costReason)
        {
            if (addcost is true)
            {
                AdditionalCostCheckBox.Clickme(driver);
                AdditionalCostAmount.EnterText(costAmount);
                AdditionalCostReason.EnterText(costReason);
            }
            else
            {
                _logger.Info("Do not add additional cost");
            }
            return this;
        }

        public MeasurementAndInstallationPage AddAdditionalMinutes(Boolean addMin, String minAmount, String minReason)
        {
            if (addMin is true)
            {
                AdditionalMinCheckBox.Clickme(driver);
                AdditionalMinAmount.EnterText(minAmount);
                AdditionalMinReason.EnterText(minReason);
            }
            else
            {
                _logger.Info("Do not add additional minute");
            }
            return this;
        }
        public MeasurementAndInstallationPage AddInstallerNotes(String notes)
        {
            InstallerNotesButton.Clickme(driver);
            InstallerNotesTextBox.EnterText(notes);
            return this;

        }
  



        public MeasurementAndInstallationPage ClickOnSaveChangesButton()
        {
            SaveChangesButtonOnInstallationPage.Clickme(driver);
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                customWait.Until(ExpectedConditions.ElementIsVisible(By.Id("idBtnOK")));
                OkButton.Clickme(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return this;

        }




    }
}
