using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Base
{
   public class BasePageClass

    {
         
    
        public static void Initialization()
            {
     			PropertiesCollection.driver = new ChromeDriver();
                PropertiesCollection.LP = new LoginPage();



        }

       	public static void OpenURL()
           {

            PropertiesCollection.driver.Navigate().GoToUrl("https://3puser:N3xtD@y0@pos-stage-major.nextdayblinds.com");
            PropertiesCollection.driver.Navigate().GoToUrl("https://pos-stage-major.nextdayblinds.com/login");
            PropertiesCollection.driver.Manage().Window.Maximize();
       
           }

        
    }
}