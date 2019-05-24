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
        private IWebDriver driver;
        public static String ProductTotal { get; set; }
        public static String ShippingDeliveryType = "SHIPPING";
        public static String QuoteGroup = "A";
        public static String QuoteStatus = "OPEN";
        public static String StorePickup = "STORE PICKUP";




    }
}
