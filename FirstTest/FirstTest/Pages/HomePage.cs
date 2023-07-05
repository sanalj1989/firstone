using FirstTest.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Pages
{
    public class HomePage
    {
        public void GotoTMPage(IWebDriver driver)
        {
            //************************CREATE A NEW TIME RECORD******************************************
            //Navigate to Time and Material page
            IWebElement administationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 7);
            IWebElement TmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TmOption.Click();
        }
    }
}
