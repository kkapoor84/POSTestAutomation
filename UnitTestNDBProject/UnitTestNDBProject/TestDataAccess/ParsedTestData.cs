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
}
