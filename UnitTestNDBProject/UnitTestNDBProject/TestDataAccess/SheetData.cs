using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.TestDataAccess
{
    public class SheetData
    {
        public string Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneType1 { get; set; }

        public string PhoneNumber2 { get; set; }
        public string PhoneType2 { get; set; }

        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string TaxIdNumber1 { get; set; }

        public string TaxState1 { get; set; }

        public string TaxIdNumber2 { get; set; }

        public string TaxState2 { get; set; }

        Random random = new Random();

        public string PhoneNumber1Unique()
        {
            string PhoneNumber1Unique = PhoneNumber1 + random.Next(1000000000);
            return PhoneNumber1Unique;
        }

        public string PhoneNumber2Unique()
        {
            string PhoneNumber2Unique = PhoneNumber2 + random.Next(1000000000);
            return PhoneNumber2Unique;
        }

        public string EmailAddress1Unique()
        {
            string EmailAddress1Unique = EmailAddress1 + +random.Next(1000) + "@nextdayblinds.com";
            return EmailAddress1Unique;
        }

        public string EmailAddress2Unique()
        {
            string EmailAddress2Unique = EmailAddress2 + +random.Next(10000) + "@nextdayblinds.com";
            return EmailAddress2Unique;
        }

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

        public String addressline1_2Unique()
        {
            String addressLine1Unique = AddressLine1 + random.Next(1, 100);

            return addressLine1Unique;

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

