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

        public static string RandomString()
        {
            String randomText = random.Next(1, 100000).ToString();
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
            string randomText = email + GenerateRandomString() + random.Next(100000) + "@nextdayblinds.com";
            return randomText;
        }

        public static string RandomizeQuote(string order)
        {
            string randomText = order + random.Next(10000);
            return randomText;
        }
        public static string GenerateRandomString()
        {
            int length = 10;
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
