using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestNDBProject.Base;

namespace UnitTestNDBProject.Tests
{
    [TestFixture]
    class HomePageTest : BaseTestClass
    {
        public HomePageTest() : base(BrowserType.Chrome)
        {

        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            LP.Login("LoginScreen$", "AccountUserValidCredentails");

        }

        [Description("Validate all the Home Page tabs are clickable"),Category("Smoke"),Category("Regression")]
        public void A3_VerifyHomePageTabs()
        {
            HP.VerifyHomePageTitle();
            HP.ClickDashBoardTab();
            Assert.True(HP.VerifyDashBoardTabIsClicked());
            HP.ClickDepositSummaryTab();
            Assert.True(HP.VerifyDepositSummaryTabIsClicked());
            HP.ClickResourcesTab();
            Assert.True(HP.VerifyResourceTabIsClicked());
            HP.ClickSettingTab();
            Assert.True(HP.VerifySettingTabIsClicked());

        }








    }
}
