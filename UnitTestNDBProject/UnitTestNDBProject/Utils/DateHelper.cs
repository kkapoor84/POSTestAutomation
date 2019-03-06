using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
    public static class DateHelper
    {
        private static IWebElement datePicker;
        /// <summary>
        /// Gets the tomorrow date.
        /// </summary>
        /// <value>
        /// The tomorrow date.
        /// </value>
        public static string TomorrowDate
        {
            get
            {
                return DateTime.Now.AddDays(1).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current time stamp.
        /// </summary>
        /// <value>
        /// The current time stamp.
        /// </value>
        public static string CurrentTimeStamp
        {
            get
            {
                return DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        public static string CurrentDate
        {
            get
            {
                return DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the future date.
        /// </summary>
        /// <param name="numberDaysToAddToNow">The number days to add from current date.</param>
        /// <returns>Date in future depends on parameter: numberDaysToAddToNow</returns>
        public static string GetFutureDate(int numberDaysToAddToNow)
        {
            return DateTime.Now.AddDays(numberDaysToAddToNow).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
        }

        public static void selectDate(String date, IWebDriver driver)
        {
            datePicker = driver.FindElement(By.Id("ui-datepicker-div"));

            IList<IWebElement> columns = datePicker.FindElements(By.TagName("td"));
            foreach (IWebElement cell in columns)
            {
                //Select the date from date picker when condition match.
                if (cell.Text.Equals(date))
                {
                    cell.FindElement(By.LinkText(date)).Click();
                    break;
                }
            }
        }

    }
}
