using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnitTestNDBProject.Utils.PropertiesCollection;

namespace UnitTestNDBProject.Utils
{
    public static class ActionHelper

    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static String QuoteManagementButton1 = ".//*[contains(text(),'%s')]";


        public static Func<IWebDriver, bool> ElementIsVisible(this IWebElement element)
        {
            return driver => {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;

                }
            };


        }


        public static bool isPresent(this By bylocator)
        {

            bool variable = false;
            try
            {
                IWebElement element = PropertiesCollection.driver.FindElement(bylocator);
                variable = element != null;
            }
            catch (NoSuchElementException)
            {

            }
            return variable;
        }

        public static bool DoesWebElementExist(string linkexist)
        {
            try
            {
                PropertiesCollection.driver.FindElement(By.XPath(linkexist));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
        public static bool IsElementDisplayed_Generic_Login(this IWebDriver driver, By bylocator)
        {
            try
            {
                bool elementPresent = false;
                for (int i = 0; i < 10; i++)
                {
                    try { elementPresent = driver.FindElement(bylocator).Displayed; }
                    catch (Exception) { }
                    if (elementPresent) { break; }
                    System.Threading.Thread.Sleep(1000);
                }
                return elementPresent;
            }
            catch (Exception)
            { return false; }
        }


        public static bool isElementPresent(By fieldLocator)
        {
            try
            {
                _logger.Debug("Element: " + fieldLocator);
                PropertiesCollection.driver.FindElement(fieldLocator);

            }
            catch (Exception Ex)
            {
                _logger.Debug("Unable to locate Element: " + fieldLocator);
                return false;
            }
            return true;
        }


        public static By DynamicXpath(String xpathValue, String subtitutionValue)
        {
            return By.XPath(string.Format(xpathValue, subtitutionValue));
        }





        public static bool CheckButtonFunctionalityEnabled(String LocatorName)
        {
            By text = DynamicXpath(QuoteManagementButton1, LocatorName);
            return PropertiesCollection.driver.FindElement(text).Enabled;

        }



    }
}
