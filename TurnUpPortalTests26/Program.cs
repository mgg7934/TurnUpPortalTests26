using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V143.Target;
using OpenQA.Selenium.Support.UI;
using TurnUpPortalTests26.Pages;

internal class Program
{
    public static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        
        //Login page object initialisation and definition 
        LoginPage loginPageobj = new LoginPage();
        loginPageobj.LoginActions(driver);

        //Home page object initialisation and definition
        HomePage homePageobj = new HomePage();
        homePageobj.CheckUserLogIn(driver);
        homePageobj.NavigatePage(driver);        

        //TMpage object initialisation and definition
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);
        tMPageObj.EditTimeRecord(driver);
        tMPageObj.DeleteTimeRecord(driver);



    }

}
