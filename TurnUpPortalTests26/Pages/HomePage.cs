using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TurnUpPortalTests26.Utilities;

namespace TurnUpPortalTests26.Pages
{
    public class HomePage
    {
        public void CheckUserLogIn(IWebDriver driver)
        {
            Thread.Sleep(3000);
            //Check is user has logged in successfully 
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test failed!");
            }
        }

        public void NavigatePage(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/a/span", 5);

            //Navitagte to Time and Material page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();
        }

        


    } 


}
