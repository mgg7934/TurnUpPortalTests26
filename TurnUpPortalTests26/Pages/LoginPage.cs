using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TurnUpPortalTests26.Utilities;


namespace TurnUpPortalTests26.Pages
{
    public class LoginPage
    {
        //Functions that allow users to login in to TurnUp Portal
        public void LoginActions(IWebDriver driver)

        {
            
            //Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Wait.WaitToBeClickable(driver, "Id", "UserName", 3);

            //Identyify username textbox and enter valid username
            IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys("hari");


            //Identyify password textbox and enter valid password
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("123123");

            Wait.WaitToBeVisible(driver, "Id", "Password", 30);

            //Identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            

            

        }

    }
}
