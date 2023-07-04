﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;


internal class Program
{
    private static void Main(string[] args)
    {
        // Open Google Chrome browser
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        // Lauch Turn up portal

        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        Thread.Sleep(1500);

        // Identify the username textbox and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");


        // Identify the password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");


        // Click Login button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();


        // Check if the user has logged in successfully

        IWebElement HelloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (HelloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has log in successfully");
        }
        else
        {
            Console.WriteLine("User failed to log in");
        }


        //************************CREATE A NEW TIME RECORD******************************************
        //Navigate to Time and Material page
        IWebElement AdministationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        AdministationTab.Click();
        IWebElement TmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TmOption.Click();

        //Click on Create new button

        IWebElement CreatenewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        CreatenewButton.Click();

        //Select Time from drop down list
        IWebElement DropdownList = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        DropdownList.Click();
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        //Enter Code
        IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
        CodeTextbox.SendKeys("sanal");

        //Enter Description
        IWebElement DescriptionTextbox = driver.FindElement(By.Id("Description"));
        DescriptionTextbox.SendKeys("sample record");

        //Enter Price per  Unit
        IWebElement PriceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        PriceTag.Click();
        IWebElement PriceperunitTextbox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
        PriceperunitTextbox.SendKeys("20");


        //Click on Save button

        IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
        SaveButton.Click();
        Thread.Sleep(1500);

        //Check if the new record has been created

        IWebElement LastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        LastPageButton.Click();
        IWebElement NewCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (NewCode.Text == "sanal")
        {
            Console.WriteLine("The new record has been created successfully");
        }

        else
        {
            Console.WriteLine("The new record has not created. TEST FAILED");
        }


        Thread.Sleep(1500);

        //*********************************************EDITING FUNCTIONALITY*******************************************
        //Select a record and click edit button
        IWebElement LlastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        LlastPageButton.Click();
        IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        EditButton.Click();



        //Edit the code details
        IWebElement CcodeTextbox = driver.FindElement(By.Id("Code"));
        CcodeTextbox.SendKeys("sanal jacob");


        //Click save
        IWebElement SsaveButton = driver.FindElement(By.Id("SaveButton"));
        SsaveButton.Click();
        Thread.Sleep(1500);

        //Check if the edit functionality is properly working or not

        IWebElement LllastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        LllastPageButton.Click();
        IWebElement NeweditedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (NeweditedCode.Text == "sanalsanal jacob")  
        {
            Console.WriteLine("The editing functionality working successfully");
        }

        else
        {
            Console.WriteLine("Editing test failed");

        }
        Thread.Sleep(1500);
        //***********************************DELETE FUNCTIONALITY******************************************************
        //Click on delete button on a selected record
        IWebElement Deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[last()]/a[2]"));
        Deletebutton.Click();
        Thread.Sleep(1500);
        //Click OK to delete
        driver.SwitchTo().Alert().Accept();

        //Check if the record is deleted
        IWebElement LPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        LPageButton.Click();
        IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (deletedCode.Text == "sanalsanal jacob")
        {
            Console.WriteLine("The deleting functiomality working successfully");
        }

        else
        {
            Console.WriteLine("The deleting functionality working failed");

        }
    }
}



