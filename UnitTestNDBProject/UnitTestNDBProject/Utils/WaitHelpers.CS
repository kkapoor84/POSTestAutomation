using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;
using SeleniumExtras.PageObjects;
using SeleniumExtras;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace UnitTestNDBProject.Utils
{
    public static class WaitHelpers
    {
        //public static void WaitForElement1(this IWebDriver driver, IWebElement element)
        //{
        //    // int timeOut = 12000;

        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(30);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    IWebElement searchResult = fluentWait.Until(x => element);

        //}

        public static void WaitForElementToBecomeVisibleWithinTimeout(this IWebDriver driver, IWebElement element, int timeout)
        {
           // Thread.Sleep(5000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ActionHelper.ElementIsVisible(element));
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, By locator, int timeout=30)
        {
            // Thread.Sleep(5000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(locator));

        }

        public static void WaitForElementToBeVisible(this IWebDriver driver, By locator, int timeout = 30)
        {
            // Thread.Sleep(5000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementIsVisible(locator));

        }


        // Explicit Wait
        public static void ExplicitWait(IWebDriver driver)
        { 
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement navList = wait.Until<IWebElement>((d) =>
        {
            return d.FindElement(By.Id("navlist"));
        });
      }




        // Implicit Wait
        public static void ImplicitWaitMethod()
        {
           //PropertiesCollection.driver.Manage().Timeouts().ImplicitWait(new TimeSpan(0, 0, 0, 10));
         // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(10000));
        }


        //public static void waitForElementtobevisible( this IWebDriver driver, By bylocator, long timeout)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        //    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(bylocator));
        //    //	Log.info("element found..."+element.getText());
        //}

        public static String waitForElementNotVisible( this IWebDriver driver, String elementXPath)
        {
            if ((driver == null) || (elementXPath == null) )
            {

                return "Wrong usage of WaitforElementNotVisible()";
            }
            try
            {
             
                (new WebDriverWait(driver, TimeSpan.FromSeconds(45))).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(elementXPath)));
                return null;
            }
            catch (TimeoutException e)
            {
                return e.StackTrace;
            }
        }
        //
        public static void WaitForElement( this IWebDriver driver,IWebElement element, int timeout = 1)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(timeout));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(IWebDriver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }



    }
}
