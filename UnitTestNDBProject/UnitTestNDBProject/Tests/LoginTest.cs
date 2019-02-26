using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;
using UnitTestNDBProject.Base;
using UnitTestNDBProject.Pages;
using log4net;
using log4net.Config;
using UnitTestNDBProject.Utils;
using static UnitTestNDBProject.Utils.TestConstant;


[TestFixture]
public class LoginTest 
    {
    //  ILog log = LogManager.GetLogger(typeof(LoginTest));
   

    [Test, Order(1), Category("Regression")]
    public void VerifyLoginWithInValidCrdentails()
    {
        try
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginInValidCredentials");
            PropertiesCollection.LP.Login(InvalidUser, Validpwd);
            Assert.True(PropertiesCollection.LP.VerifyMessageInvalidCredentials(), "These credentials are correct");
        }
        catch(NoSuchElementException e)
        {
            GlobalSetup.test.Fail(e.StackTrace);
        }

    }

          [Test, Order(2), Category("Regression"), Category("Smoke")]
        public void VerifyLoginWithValidCrdentails()
    {
        try
        {
            //log.Info("test valid started");
            GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginValidCredentials");
            PropertiesCollection.LP.Login(ValidUser, Validpwd);
            Assert.True(PropertiesCollection.LP.VerifyHomePageTitle());
         
            PropertiesCollection.LP.Signout();
        }
        catch (NoSuchElementException e)
        {
            GlobalSetup.test.Fail(e.StackTrace);
        }


    }

}
    


