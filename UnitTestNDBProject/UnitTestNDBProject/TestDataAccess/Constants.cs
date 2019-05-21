using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestNDBProject.TestDataAccess
{
    public class Constants
    {
        static String ShippingDeliveryType;
        private IWebDriver driver;

        //public Constants(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        public string  ShippingDetails()
        {
            ShippingDeliveryType = "SHIPPING";
            return ShippingDeliveryType;
    }
       
    }
}
