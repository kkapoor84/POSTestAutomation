using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
    class ScreenshotUtil
    {
        
/// <summary>
/// This will Take the screen shot of the webpage and will save it at particular location
/// </summary>      ///
public static void SaveScreenShot(string screenshotFirstName)
        {
          //  var folderLocation = Environment.CurrentDirectory.Replace("Out", "\\ScreenShot\\");
            var folderLocation = @"D:\Next Day Blinds\UnitTestNDBProject\UnitTestNDBProject\UnitTestNDBProject\ScreenShot\";
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
            var screenshot = ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            filename.Append(screenshotFirstName);
            filename.Append(DateTime.Now.ToString("dd-mm-yyyy HH_mm_ss"));
            filename.Append(".jpg");
            screenshot.SaveAsFile(filename.ToString());
        }
    }
}
