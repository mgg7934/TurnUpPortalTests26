using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortalTests26.Pages;
using TurnUpPortalTests26.Utilities;


namespace TurnUpPortalTests26.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            // Login page object initialisation and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            // Home page object initialisation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.CheckUserLogIn(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // TM page object initialisation and definition
            //Create Time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);

        }

        [Test]
        public void EditTime_Test()
        {
            
            // Edit Time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.NavigateToLastPage(driver);
            tMPageObj.EditTimeRecord(driver);

           
        }

        [Test]
        public void DeleteTime_Test()
        {
            // Delete Time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.NavigateToLastPage(driver);
            tMPageObj.DeleteTimeRecord(driver);

        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
