using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;


namespace NopCommerce_Automation_Testing
{
    [TestFixture]
    public class Testbase
    {
        public static IWebDriver driver;
        public WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            Datadriven data = new Datadriven();
            //data.ExcelToDataTable(@"D:\NopCommerce_Automation\NopCommerce_Automation_Testing\Data.xlsx");
            string drivertype = ConfigProvider.GetconfigValue("Browser");
            if (drivertype == "Chrome")
            {
                driver = new ChromeDriver();

            }

            else if (drivertype == "Firefox")
            {
                driver=new FirefoxDriver();
            }

            
            string baseurl = "http://192.168.1.151:8082/";
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            //MoveToElement(Constants.Username);
        }

        public void MoveToElement(string locator )
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(locator))).Build().Perform();        
        }
        
        public void login(string username, string password)
        {
            try
            {
                IWebElement login = driver.FindElement(By.XPath(Constants.Login));
                login.Click();
                Thread.Sleep(2000);
                IWebElement Email = driver.FindElement(By.XPath(Constants.Emailtxt));
                Email.Click();
                Email.SendKeys(username);
                Thread.Sleep(2000);
                IWebElement Password = driver.FindElement(By.XPath(Constants.passwordtxt));
                Password.Click();
                Password.SendKeys(password);
            }

            catch (Exception ex)
            {
                //secondfile with login details
                //Remaining code will not be excuted
                Console.WriteLine(ex.Message);

            }
            IWebElement LoginBtn = driver.FindElement(By.XPath(Constants.Loginbtn));
            LoginBtn.Click();

            Thread.Sleep(2000);
        }
        [TearDown]
        public void Close()
        {
            IWebElement logout = driver.FindElement(By.XPath(Constants.Logout));
            logout.Click();
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
        }
    }
}
