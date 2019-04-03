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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneType1 { get; set; }
        public string EmailAddress1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneType2 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string TaxIdNumber { get; set; }

        public string TaxState { get; set; }


        public String FistNameUnique()
        {
            String FirstUniqueName = FirstName + random.Next(1, 100); ;
            return FirstUniqueName;
        }

        public String LastNameUnique()
        {
            String LastUniqueName = LastName + random.Next(1, 100);
            return LastUniqueName;
        }

        public String EmailAddressUnique()
        {
            String EmailAddressUnique = EmailAddress1 + new Random().Next(1000) + "@nextdayblinds.com";

            return EmailAddressUnique;

        }

        public String addressline1_2Unique()
        {
            String addressLine1Unique = AddressLine1 + random.Next(1, 100);

            return addressLine1Unique;

        }


    }

    public class PreservedCustomerInformation
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

}

