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

public class LoginTest : BaseTestClass
{
    public LoginTest() : base(BrowserType.Chrome)
    {
    }


    [Test, Category("Regression"),Category("Smoke"),Description("Validate that error message populates once user enter invalid credentials")]
    public void A1_VerifyLoginWithInValidCrdentails()
    {

        try
        {
            GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginInValidCredentials");
            LP.Login("LoginScreen$", "InValidCredentials");


            Assert.True(LP.VerifyMessageInvalidCredentials(), "These credentials are correct");
        }
        catch (NoSuchElementException e)
        {
            GlobalSetup.test.Fail(e.StackTrace);
            SS.SaveScreenShot($"Failed Test{this.GetType().Name}");


        }
    }

    [Test,Category("Regression"), Category("Smoke"),Description("Validate that user is able to navigate to Home page using valid credentials")]
    public void A2_VerifyLoginWithValidCrdentails()
    {

        try
        {

            GlobalSetup.test = GlobalSetup.extent.CreateTest("LoginValidCredentials");
            LP.Login("LoginScreen$", "SAHUserValidCredentails");
            HP.ClickShopAtHomeTab();
            Assert.True(HP.VerifyShopAtHomeTabIsClicked());
            HP.Signout();
        }
        catch (NoSuchElementException e)
        {

            GlobalSetup.test.Fail(e.StackTrace);
            SS.SaveScreenShot($"Failed Test{this.GetType().Name}");
        }


    }


}



