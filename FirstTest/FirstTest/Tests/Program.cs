using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using FirstTest.Pages;

internal class Program
{
    private static void Main(string[] args)
    {
        // Open Google Chrome browser
        IWebDriver driver = new ChromeDriver();
        Thread.Sleep(1500);

        // LOGIN PAGE OJECT INITIALIZATION & DEFENITION
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginSteps(driver);

        //HOME PAGE OBJECT INITIALIZATION & DEFENITION
        HomePage homePageObj = new HomePage();
        homePageObj.GotoTMPage(driver);

        //TM PAGE OBJECT INITIALIZATION & DEFENITION
        TM_Page tmPageObj = new TM_Page();
        tmPageObj.CreateTimeRecord(driver);

        //EDIT TIME RECORD
        tmPageObj.EditTimeRecord(driver);

        //DELETE TIME RECORD
        tmPageObj.DeleteTimeRecod(driver);



        

       
        

    }
}





