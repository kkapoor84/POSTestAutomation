using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using Dapper;

namespace UnitTestNDBProject.TestDataAccess
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {

           //string fileName = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\UnitTestNDBProject\\TestDataAccess\\TestData.xlsx";
            string fileName = "..\\NDBPOS_GITHUB_INTEGRATION\\UnitTestNDBProject\\UnitTestNDBProject\\TestDataAccess\\TestData.xlsx";
           // string fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties=\"Excel 8.0; HDR=Yes;\";";

            return con;
        }

        public static SheetData GetTestData(string sheetname, string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [{0}] where key='{1}'", sheetname, keyName);
                var value = connection.Query<SheetData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
