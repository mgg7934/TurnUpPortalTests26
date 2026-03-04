using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortalTests26.Pages;
using TurnUpPortalTests26.Utilities;

namespace TurnUpPortalTests26.StepDefinition
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
           

            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            

            HomePage homePageObj = new HomePage();
            homePageObj.CheckUserLogIn(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [When(@"I create a time record")]
        public void WhenICreateATimeRecord()
        {
            

            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);

        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            

            TMPage tMPageObj = new TMPage();
            
            string newCode = tMPageObj.GetCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);

            Assert.That(newCode == "TA Programme", "Actual Code and expected Code do not match.");
            Assert.That(newDescription == "This is a description", "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "12.00", "Actual Price and expected Price do not match.");
        }

        [When(@"I update the '([^']*)' on an existing Time record")]
        public void WhenIUpdateTheOnAnExistingTimeRecord(string code)
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.NavigateToLastPage(driver);
            tMPageObj.EditTimeRecord(driver, code);
        }

        [Then(@"the record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string code)
        {
            TMPage tMPageObj = new TMPage();

            string editedCode = tMPageObj.GetEditedCode(driver);

            Assert.That(editedCode == code, "Expected Edited Code does not match with the Actual Edited Code.");

        }
    }
}
