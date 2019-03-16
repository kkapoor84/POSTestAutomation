using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;


namespace UnitTestNDBProject.Utils
{
    public static class WaitHelpers
    {
        public static void WaitForElement(this IWebDriver driver, IWebElement element)
        {
            // int timeOut = 12000;
            bool var;
            var = true;

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement searchResult = fluentWait.Until(x => element);

        }

        public static void WaitForElementToBecomeVisibleWithinTimeout(this IWebDriver driver, IWebElement element, int timeout)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ActionHelper.ElementIsVisible(element));
        }



        // Explicit Wait
        public static void ExplicitWait()
        { 
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
        IWebElement navList = wait.Until<IWebElement>((d) =>
        {
            return d.FindElement(By.Id("navlist"));
        });
      }
       // Implicit Wait
        public static void ImplicitWaitMethod()
        {
           //PropertiesCollection.driver.Manage().Timeouts().ImplicitWait(new TimeSpan(0, 0, 0, 10));
           // PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(10000));
        }


        public static void waitForElementtobevisible( this IWebDriver driver, By bylocator, long timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(bylocator));
            //	Log.info("element found..."+element.getText());
        }

    }
}
