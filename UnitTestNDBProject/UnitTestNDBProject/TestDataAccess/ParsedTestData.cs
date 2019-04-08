using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNDBProject.TestDataAccess
{
    public class ParsedTestData
    {
        public string Feature { get; set; }
        public List<DataDictionary> Data { get; set; }
    }

    public class DataDictionary
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class NewCustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<TaxNumber> TaxNumbers { get; set; }
    }

    public class Phone
    {
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }

    public class Email
    {
        public string EmailText { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }        
    }

    public class TaxNumber
    {
        public string TaxIdNumber { get; set; }
        public string TaxState { get; set; }
    }
}
