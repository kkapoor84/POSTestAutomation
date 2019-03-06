using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Base
{

    public class BasePageClass

    {
        public IWebDriver driver;

        public BasePageClass(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void OpenURL()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["AuthURL"]);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            driver.Manage().Window.Maximize();

        }


    }
}