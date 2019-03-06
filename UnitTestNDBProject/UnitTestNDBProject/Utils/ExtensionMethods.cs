using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
    public static class ExtensionMethods
    {
        public static void EnterText(this By bylocator, IWebDriver driver, String value)
        {
            driver.FindElement(bylocator).SendKeys(value);
        }


        public static void Clickme(this By bylocator, IWebDriver driver)
        {
            driver.FindElement(bylocator).Click();
        }


        public static void SelectDropDown(this By bylocator, IWebDriver driver, String value)
        {
            new SelectElement(driver.FindElement(bylocator)).SelectByText(value);
        }

        public static String GetText(this By bylocator, IWebDriver driver)
        {
            return driver.FindElement(bylocator).Text;
        }

        public static String GetTextDD(this By bylocator, IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(bylocator)).AllSelectedOptions.SingleOrDefault().Text;
        }
    }

}
