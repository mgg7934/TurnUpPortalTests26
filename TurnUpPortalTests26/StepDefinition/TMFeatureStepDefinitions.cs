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

        [When(@"I update the '([^']*)' and '([^']*)' on an existing Time record")]
        public void WhenIUpdateTheOnAnExistingTimeRecord(string code, string description)
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.NavigateToLastPage(driver);
            tMPageObj.EditTimeRecord(driver, code, description);
        }

        [Then(@"the record should have the updated '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string code, string description)
        {
            TMPage tMPageObj = new TMPage();

            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedDescription = tMPageObj.GetEditedDescription(driver);

            
            Assert.That(editedCode == code, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescription == description, "Expected Edited Description and actual edited description do not match.");

        }

        [When("I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.NavigateToLastPage(driver);
            tMPageObj.DeleteTimeRecord(driver);
        }

        [Then("the record should not be present on the table")]
        public void ThenTheRecordShouldNotBePresentOnTheTable()
        {
            TMPage tMPageObj = new TMPage();

            string newRecord = tMPageObj.GetDeletedCode(driver);
            

            Assert.That(newRecord == newRecord, "Record hasn't been deleted.");
            
        }


        [AfterScenario]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}

