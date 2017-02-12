using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace TrashPoints.Test.Commom
{
    public abstract class BaseTest
    {
        public static IWebDriver Driver { get; set; }

        [SetUp]
        public void SetUpTest()
        {
            if (Driver == null)
                Driver = new ChromeDriver();

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
            Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            //Driver.Manage().Window.Maximize();
        }

        //[TearDown]
        //public void TearDownTest()
        //{
        //    try
        //    {
        //        Driver.Quit();
        //        Driver = null;
        //        Driver.Close();
        //    }
        //    catch (Exception)
        //    { }
        //}


    }

}
