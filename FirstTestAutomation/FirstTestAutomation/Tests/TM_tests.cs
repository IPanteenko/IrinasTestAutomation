using FirstTestAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using FirstTestAutomation.Utilities;

namespace FirstTestAutomation.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_tests : CommonDriver
    {
        [SetUp]
        public void SetupTM() 
        {
            // Open the Browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMpage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // Time&material page initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver, "August2023");

        }

        [Test]
        public void EditTime_Test() 
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver, "something", "something2", "something3");
        }

        [Test]
        public void DeleteTime_Test() 
        {
            // Creating two records to make sure they have different codes for assertion
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver, "August2023");
            tMPageObj.CreateTimeRecord(driver, "AnotherAugust2023"); 
            tMPageObj.DeleteTimeRecord(driver);
        }   

        [TearDown]
        public void CloseTestRun()
        {
            TMPage tMPageObj = new TMPage();
            driver.Quit();
        }
    }
}
