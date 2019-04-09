using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Pages;
using UnitTestNDBProject.TestDataAccess;
using UnitTestNDBProject.Utils;

namespace UnitTestNDBProject.Tests
{
    /// <summary>
    /// Common class that comtains functions shared across multiple test classes
    /// </summary>
    public class CommonTest
    {
        /// <summary>
        /// Function to add customer phones
        /// </summary>
        /// <param name="enterNewCustomerPage"></param>
        /// <param name="phones"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> AddCustomerPhones(EnterNewCustomerPage enterNewCustomerPage, List<Phone> phones)
        {
            List<Tuple<string, string>> newPhones = new List<Tuple<string, string>>();

            //Input phones
            for (int counter = 0; counter < phones.Count; counter++)
            {
                string phone = CommonFunctions.AppendMaxRangeRandomString(phones[counter].PhoneNumber);
                string phoneType = phones[counter].PhoneType;
                enterNewCustomerPage.EnterPhone(phone, counter).SelectPhoneType(phoneType, counter);

                if (counter < phones.Count - 1)
                {
                    enterNewCustomerPage.AddPhone();
                }

                newPhones.Add(new Tuple<string, string>(phone, phoneType));
            }

            return newPhones;
        }

        /// <summary>
        /// Function to add customer emails
        /// </summary>
        /// <param name="enterNewCustomerPage"></param>
        /// <param name="emails"></param>
        /// <returns></returns>
        public List<string> AddCustomerEmails(EnterNewCustomerPage enterNewCustomerPage, List<Email> emails)
        {
            List<string> newEmails = new List<string>();

            for (int counter = 0; counter < emails.Count; counter++)
            {
                string email = CommonFunctions.RandomizeEmail(emails[counter].EmailText);
                enterNewCustomerPage.EnterEmailAddress(email, counter);

                if (counter < emails.Count - 1)
                {
                    enterNewCustomerPage.AddEmailAddress();
                }

                newEmails.Add(email);
            }

            return newEmails;
        }
    }
}
