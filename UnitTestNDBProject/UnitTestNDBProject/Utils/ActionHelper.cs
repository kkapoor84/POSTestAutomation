﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
   public static class ActionHelper
    {
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

        public static bool isPresent(this IWebDriver driver, By bylocator)
        {

            bool variable = false;
            try
            {
                IWebElement element = driver.FindElement(bylocator);
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

     

    }
}
