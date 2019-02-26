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
        public static void EnterText( this By bylocator,String value)
        {
            PropertiesCollection.driver.FindElement(bylocator).SendKeys(value);
        }


        public static void Clickme(this By bylocator)
        {
            PropertiesCollection.driver.FindElement(bylocator).Click();
        }


        public static void SelectDropDown(this By bylocator, String value)
        {
            new SelectElement(PropertiesCollection.driver.FindElement(bylocator)).SelectByText(value);
        }

        public static String GetText(this By bylocator)
        {
           return PropertiesCollection.driver.FindElement(bylocator).Text;
        }

        public static String GetTextDD(this By bylocator)
        {
            return new SelectElement(PropertiesCollection.driver.FindElement(bylocator)).AllSelectedOptions.SingleOrDefault().Text;
        }
    }

}
