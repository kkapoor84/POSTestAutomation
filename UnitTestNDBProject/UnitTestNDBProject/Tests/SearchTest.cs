using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Utils;
using static UnitTestNDBProject.Utils.TestConstant;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class SearchTest
    {
        [OneTimeSetUp]
        public void SetupBeforeClass()
        {
            PropertiesCollection.LP.Login("LoginScreen$", "Valid"); ;

        }
        
        [Test]
        public void SearchCustomerwithValidCUstomerName()
        {
         
        }

        public void SetupAfterClass()
        {
            PropertiesCollection.LP.Signout();
           
        }

    }
}
