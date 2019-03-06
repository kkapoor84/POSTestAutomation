using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestNDBProject.Utils
{
    class SeleniumUtils
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        public static void checkPageIsReady(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            {

                return;
            }
            for (int i = 0; i < 25; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    _logger.Info("caught");
                }
                if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    break;
                }
            }
        }







    }











}