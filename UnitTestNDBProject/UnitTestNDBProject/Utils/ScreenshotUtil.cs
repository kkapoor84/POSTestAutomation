using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Base;

namespace UnitTestNDBProject.Utils
{
    public class ScreenshotUtil 
    {

        public IWebDriver driver;

        public ScreenshotUtil(IWebDriver driver)
        {
            this.driver = driver;

        }

        /// <summary>
        /// This will Take the screen shot of the webpage and will save it at particular location
        /// </summary>     
        public void SaveScreenShot(string screenshotFirstName)
        {
             var folderLocation = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\ScreenShot\\";
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            filename.Append(screenshotFirstName);
            filename.Append(DateTime.Now.ToString("MM-dd-yyyy HH_mm_ss"));
          
            filename.Append(".jpg");
            screenshot.SaveAsFile(filename.ToString());
        }
    }
}
