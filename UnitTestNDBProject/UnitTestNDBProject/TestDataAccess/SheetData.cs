using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.TestDataAccess
{
    public class SheetData
    {
        Random random = new Random();
        public string Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneType1 { get; set; }
        public string EmailAddress1 { get; set; }

        
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }

        public string taxidnumber { get; set; }

        public string taxstate { get; set; }


        public String FistNameUnique()
        {
            String FirstUniqueName = firstName + random.Next(1, 100); ;
            return FirstUniqueName;
        }

        public String LastNameUnique()
        {
            String LastUniqueName = lastName + random.Next(1, 100);
            return LastUniqueName;
        }

        public String EmailAddressUnique()
        {
            String EmailAddressUnique = EmailAddress1 + new Random().Next(1000) + "@nextdayblinds.com";

            return EmailAddressUnique;

        }

    }

    public class PreservedCustomerInformation
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

}

