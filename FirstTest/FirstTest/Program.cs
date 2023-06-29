using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

internal class Program
{
    private static void Main(string[] args)
    {
        // Open Google Chrome browser
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        // Lauch Turn up portal

        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

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
    }
}