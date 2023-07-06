using FirstTest.Pages;
using FirstTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void TM_SetUp()
        {
            // open chrome browser
            driver = new ChromeDriver();
            Thread.Sleep(1000);

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object intialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // TM page object initialization and definition
            TM_Page tmPageObj = new TM_Page();
            tmPageObj.CreateTimeRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            TM_Page tmPageObj = new TM_Page();
            // Edit Time record
            tmPageObj.EditTimeRecord(driver);
        }

        [Test]
        public void DeleteTime_Test()
        {
            TM_Page tmPageObj = new TM_Page();
            // Delete Time record
            tmPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }
    }
}
