using FirstTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Pages
{
    public class TM_Page
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create new button

            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createnewButton.Click();

            try
            {
                //Select Time from drop down list
                IWebElement dropdownList = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
                dropdownList.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("CreateNew page isn't displayed", ex.Message);
            }
                
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("sanal");

            //Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("sample record");

            //Enter Price per  Unit
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();
            IWebElement priceperunitTextbox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            priceperunitTextbox.SendKeys("20");


            //Click on Save button
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1500);

            //Check if the new record has been created

            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newCode.Text == "sanal", "New time record has not been created. Test failed!");

            //if (newCode.Text == "sanal")
            //{
            //    Assert.Pass("The new record has been created successfully");
            //}

            //else
            //{
            //    Assert.Fail("The new record has not created. TEST FAILED");
            //}


            Thread.Sleep(1500);

        }
        public void EditTimeRecord(IWebDriver driver)
        {

            //*********************************************EDITING FUNCTIONALITY*******************************************
            //Select a record and click edit button
            IWebElement llastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            llastPageButton.Click();
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();


            try
            {
                //Edit the code details
                IWebElement ccodeTextbox = driver.FindElement(By.Id("Code"));
                ccodeTextbox.Clear();
                ccodeTextbox.SendKeys("sanal jacob");
            }
            catch (Exception ex) 
            {
                Assert.Fail("Edit button isn't working", ex.Message);
            }
            


            //Click save
            IWebElement ssaveButton = driver.FindElement(By.Id("SaveButton"));
            ssaveButton.Click();
            Thread.Sleep(1500);

            //Check if the edit functionality is properly working or not

            IWebElement lllastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lllastPageButton.Click();
            IWebElement neweditedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(neweditedCode.Text == "sanal jacob", "Editing functionality working failed");
            //if (neweditedCode.Text == "sanal jacob")
            //{
            //    Console.WriteLine("The editing functionality working successfully");
            //}

            //else
            //{
            //    Console.WriteLine("Editing test failed");

            //}
            Thread.Sleep(1500);
        }
        public void DeleteTimeRecord(IWebDriver driver) 
        {
            //***********************************DELETE FUNCTIONALITY******************************************************
            //Click on delete button on a selected record
            IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[last()]/a[2]"));
            deletebutton.Click();
            Thread.Sleep(1500);
            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            //Check if the record is deleted
            IWebElement lPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lPageButton.Click();
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(deletedCode.Text != "sanal jacob", "The deleting functiomality working successfully");
            //if (deletedCode.Text != "sanal jacob")
            //{
            //    Console.WriteLine("The deleting functionality working failed");
            //}

            //else
            //{
            //    Console.WriteLine("The deleting functiomality working successfully");

            //}
        }
    }
}
