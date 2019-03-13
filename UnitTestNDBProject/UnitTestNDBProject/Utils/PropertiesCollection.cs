using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Pages;

namespace UnitTestNDBProject.Utils
{
    public class PropertiesCollection
    {
       

        public static IWebDriver driver { get; set; }
        public static LoginPage LP { get; set; }
    }
}
