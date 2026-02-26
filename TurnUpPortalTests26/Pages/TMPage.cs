using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V143.WebAuthn;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortalTests26.Utilities;

namespace TurnUpPortalTests26.Pages
{
    public class TMPage
    {
        public void NavigateToLastPage(IWebDriver driver)
        {
            Thread.Sleep(3000);

            //Check new entry has been created
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
        }
        public void CreateTimeRecord(IWebDriver driver)
        {
           
            // Create Time and Material record
            //Navitagte to Time and Material page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationTab.Click();

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();

            //Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 3);

            //Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 3);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Type Code
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("TA Programme");

            //Type Description 
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("This is description");

            //Type Price  
            IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);

            //Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            NavigateToLastPage(driver);
            

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "TA Programme", "New Time has not been created");

            //if (newCode.Text == "TA Programme")
            //{
            //    Assert.Pass("Time record created succesfully");
            //}
            //else
            //{
            //    Assert.Fail("New Time has not been created");
            //}

            Thread.Sleep(2000);
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            
            //Edit Time and Material record
            //Click on Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit and type new Code input
            IWebElement codeEditTextBox = driver.FindElement(By.Id("Code"));
            codeEditTextBox.Clear();
            codeEditTextBox.SendKeys("Edit");

            //Edit and type new Description input
            IWebElement descriptionEditTextBox = driver.FindElement(By.Id("Description"));
            descriptionEditTextBox.Clear();
            descriptionEditTextBox.SendKeys("This is testing");

            //Click Save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            NavigateToLastPage(driver);

            
            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));


            if (editCode.Text == "Edit" && editDescription.Text == "This is testing")
            {
                Assert.Pass("Record edited successfully. Test Passed!");
            }
            else
            {
                Assert.Fail("Record was not edited correctly. Test Failed!");
            }

            Thread.Sleep(2000);

        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
                        
            //Delete Time and Material record
            // Capture the code of the last record before deleting
            IWebElement recordToDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string recordCode = recordToDelete.Text;

            //Click Delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);
         
            //Click the Confirm button on pop-up
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            NavigateToLastPage(driver); 

           
            IWebElement newLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newLastRecord.Text != recordCode)
            {
                Assert.Pass("Record deleted successfully. Test Passed!");
            }
            else
            {
                Assert.Fail("Record was not deleted. Test Failed!");
            }

        }
    }
}
