using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
    public class CommonFunctions
    {
        static Random random = new Random();

        /// <summary>
        /// Appends random string within specified range to the text passed in parameter
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Randomized text</returns>
        public static string AppendInRangeRandomString(string text)
        {
            string randomText = text + random.Next(1, 100);
            return randomText;
        }

        public static string AppendMaxRangeRandomString(string text, int? range = null)
        {
            int finalRange = range != null ? (int)range : 1000000000;
            string randomText = text + random.Next(finalRange);
            return randomText;
        }

        public static string RandomizeEmail(string email)
        {
            string randomText = email + random.Next(1000000000) + "@nextdayblinds.com";
            return randomText;
        }

        /// <summary>
        /// Returns the web element by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public IWebElement GetElementById(string id, IWebDriver driver)
        {
            if(string.IsNullOrEmpty(id))
            {
                return null;
            }

            IWebElement element = driver.FindElement(By.Id(id));
            return element;
        }
    }
}
