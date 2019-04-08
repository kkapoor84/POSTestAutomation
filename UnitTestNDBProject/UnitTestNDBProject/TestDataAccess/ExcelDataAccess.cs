﻿using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using Dapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace UnitTestNDBProject.TestDataAccess
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {

            //string fileName = Directory.GetCurrentDirectory() + "\\UnitTestNDBProject\\UnitTestNDBProject\\TestDataAccess\\TestData.xlsx";
            //string fileName = "..\\UnitTestNDBProject\\UnitTestNDBProject\\TestDataAccess\\TestData.xlsx";
             string fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
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

        //******* Functions added by Shiva Wahi *************//

        public static List<ParsedTestData> GetFullJsonData()
        {
            //TODO: Add code to dynamically read the path
            //TODO: Save the output of this function in a static variable so that it doesn't gets called everytime
            var fileName = @"D:\Projects\NextDayBlind\Repository\POS2TestAutomation\UnitTestNDBProject\UnitTestNDBProject\TestDataAccess\TestData.json";
            string json = File.ReadAllText(fileName);
            return (List<ParsedTestData>)JsonConvert.DeserializeObject(json, typeof(List<ParsedTestData>));
        }

        public static ParsedTestData GetFeatureData(string feature)
        {
            List<ParsedTestData> fullParsedJsonData = GetFullJsonData();
            
            return fullParsedJsonData.FirstOrDefault(x => x.Feature == feature);           
        }

        public static object GetKeyJsonData(ParsedTestData featureParsedData, string key)
        {
            return featureParsedData.Data.FirstOrDefault(x => x.Key == key).Value;
        }
        
        public static LoginData ParseLoginData(object jsonData)
        {
            return (LoginData)JsonConvert.DeserializeObject(Convert.ToString(jsonData), typeof(LoginData));
        }
    }
}