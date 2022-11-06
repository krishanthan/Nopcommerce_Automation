using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace NopCommerce_Automation_Testing
{
    [TestFixture]
    public class Promotions : Testbase
    {
        [Test]
        public void _005_Validate_campaign_new_tab()
        {
            login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
            IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
            adminpage.Click();
            Thread.Sleep(2000);
            IWebElement promotionmenu = driver.FindElement(By.XPath(Constants.promotionmenu));
            promotionmenu.Click();
            Thread.Sleep(2000);
            IWebElement campaigne = driver.FindElement(By.XPath(Constants.campaigne));
            campaigne.Click();
            Thread.Sleep(2000);
            IWebElement emailcampaign = driver.FindElement(By.XPath(Constants.emailcampaignelink));
            emailcampaign.Click();
            Thread.Sleep(2000);
            //New tab handle
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            IWebElement emailcam = driver.FindElement(By.XPath("//*[@id='email-campaigns']"));
            Assert.IsTrue(emailcam.Text.Contains("Email campaigns"));
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            IWebElement addnew = driver.FindElement(By.XPath("//*[text()=' Add new ']"));
            addnew.Click();
            Thread.Sleep(2000);
            //SCSreenshot
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C://Image.png",
            ScreenshotImageFormat.Png);
        }
    }
}
