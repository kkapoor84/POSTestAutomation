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
    public static class DataAccess
    {
        public static List<ParsedTestData> GetFullJsonData()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataPath"];

            #region Commented Code - DO NOT REMOVE
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            //path = path.Substring(6);
            //var path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            //string solution_dir = Path.GetDirectoryName( Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            #endregion

            var applicationDirectoryPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var fullFileName = Path.Combine(applicationDirectoryPath, fileName);

            string json = File.ReadAllText(fullFileName);
            return (List<ParsedTestData>)JsonConvert.DeserializeObject(json, typeof(List<ParsedTestData>));
        }

        public static ParsedTestData GetFeatureData(string feature)
        {
            //Get complete json data
            List<ParsedTestData> fullParsedJsonData = GetFullJsonData();
            
            return fullParsedJsonData.FirstOrDefault(x => x.Feature == feature);           
        }

        //Repretetive function below hence commented out,we are using "GetFeatureData" fucntion for the same

        //public static ParsedTestData GetFeatureDataFromJson(List<ParsedTestData> json, string feature)
        //{
        //    return json.FirstOrDefault(x => x.Feature == feature);
        //}

        public static object GetKeyJsonData(ParsedTestData featureParsedData, string key)
        {
            return featureParsedData.Data.FirstOrDefault(x => x.Key == key).Value;
        }
    }

    /// <summary>
    /// Generic class to parse dynamic json data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class JsonDataParser<T>
    {
        /// <summary>
        /// Function to parse dynamic json data
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T ParseData(object jsonData)
        {
            return (T)JsonConvert.DeserializeObject(Convert.ToString(jsonData), typeof(T));
        }
    }
}