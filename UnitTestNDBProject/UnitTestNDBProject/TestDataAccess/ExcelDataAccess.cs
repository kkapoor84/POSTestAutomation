using System.Configuration;
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
    }

    public static class JsonDataParser<T>
    {
        public static T ParseData(object jsonData)
        {
            return (T)JsonConvert.DeserializeObject(Convert.ToString(jsonData), typeof(T));
        }
    }
}