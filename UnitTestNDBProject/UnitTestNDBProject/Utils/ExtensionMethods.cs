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
        public static void EnterText(this IWebElement element, IWebDriver driver, String value)
        {
            element.SendKeys(value);
        }

        public static void Clickme(this IWebElement element, IWebDriver driver)
        {
            element.Click();
        }


        public static void SelectDropDown(this By bylocator, IWebDriver driver, String value)
        {
            new SelectElement(driver.FindElement(bylocator)).SelectByText(value);
        }

        public static String GetText(this IWebElement element, IWebDriver driver)
        {
            return element.Text;
        }

        public static String GetTextDD(this IWebElement element, IWebDriver driver)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }

}
