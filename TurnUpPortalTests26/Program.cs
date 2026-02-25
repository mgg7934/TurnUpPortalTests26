using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V143.Target;

internal class Program
{
    public static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();
        //Launch TurnUp Portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        //Identyify username textbox and enter valid username
        IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
        userNameTextBox.SendKeys("hari");

        //Identyify password textbox and enter valid password
        IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
        passwordTextBox.SendKeys("123123");

        //Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(5000);


        //Check is user has logged in successfully 
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if(helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed!");
        }

        // Create Time and Material record
        //Navitagte to Time and Material page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
        administrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        //Click on Create New button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        //Select Time from dropdown
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();
        Thread.Sleep(2000);

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

        //Click on Save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);

        //Check new entry has been created
        IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if(newCode.Text == "TA Programme")
        {
            Console.WriteLine("Time recorded succesfully");
        }
        else
        {
            Console.WriteLine("New time has not been created");
        }

        Thread.Sleep(6000);

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
        Thread.Sleep(3000);

        //Check Time record has been update
        IWebElement goToLastPage2 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage2.Click();

        IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")); 
        IWebElement editDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

        if (editCode.Text == "Edit" && editDescription.Text == "This is testing")
        {
            Console.WriteLine("Record edited successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Record was not edited correctly. Test Failed!");
        }

        Thread.Sleep(6000);

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
        Thread.Sleep(4000);

        //Check Time record has been deleted
        IWebElement goToLastPage3 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage3.Click();

        // Capture new last record
        IWebElement newLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        // Validate deletion
        if (newLastRecord.Text != recordCode)
        {
            Console.WriteLine("Record deleted successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Record was not deleted. Test Failed!");
        }
    }

}
