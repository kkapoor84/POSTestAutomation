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
       
        public static String ProductTotal { get; set; }
        public static String ShippingDeliveryType = "SHIPPING";
        public static String QuoteGroup = "A";
        public static String QuoteStatus = "OPEN";
        public static String StorePickup = "STORE PICKUP";
        public static String NoQuoteMessage = "No quote found.";
        public static String NoOrderMessage = "No order found.";
        public static String AddQuoteToCustomer = "ADD QUOTE TO CUSTOMER";
        public static String OrderStatusAfterTransfer = "TRANSFERRED TO PRODUCTION";
        public static String ExpFirstName = "- First Name";
        public static String ExpLastName = "- Last Name";
        public static String ExpPhone = "- Phone";
        public static String ExpEmail = "- Email";
        public static String ExpAddress = "- Address";
        public static String NoMainSelectdMessageForPhone = "A phone number must be selected as Main";
        public static String NoMainSelectdMessageForEmail = "An email address must be selected as Main";
        public static String InvalidPhone = "Please enter a phone number (e.g., (555) 555-1234)";
        public static String InvalidEmail = "Please enter a valid email address (e.g. name@domain.com)";
        public static String NoCustomerMessage = "No customer found. Create new customer?";



    }
}
