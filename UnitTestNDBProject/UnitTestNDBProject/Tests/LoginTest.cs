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
[Parallelizable]
public class LoginTest : BaseTestClass
{
    ILog log = LogManager.GetLogger(typeof(LoginTest));
    public LoginTest() : base(BrowserType.Chrome)
    {
    }

    [Test, Order(1), Category("Regression")]
    public void VerifyLoginWithInValidCrdentails()
    {

        try
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginInValidCredentials");
            LP.Login("LoginScreen$", "InValid");


            Assert.True(LP.VerifyMessageInvalidCredentials(), "These credentials are correct");
        }
        catch (Exception e)
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
            LP.Login("LoginScreen$", "Valid");

            Assert.True(LP.VerifyHomePageTitle());

            LP.Signout();
        }
        catch (NoSuchElementException e)
        {
            GlobalSetup.test.Fail(e.StackTrace);
        }


    }

}



