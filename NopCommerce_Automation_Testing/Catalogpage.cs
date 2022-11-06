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



namespace NopCommerce_Automation_Testing
{
    public class Catalogpage : Testbase
    {

        
        [Test]
        public void _001_Validate_catalog()
        {
            login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
            IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
            adminpage.Click();
            Thread.Sleep(2000);
            IWebElement catalogmenu = driver.FindElement(By.XPath(Constants.Catalogmenu));
            catalogmenu.Click();
            Thread.Sleep(3000);

         
            
        }
        [Test]
        public void _002_Validate_productpage()
        {
            try
            {
                login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
                IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
                adminpage.Click();
                Thread.Sleep(2000);
                IWebElement catalogmenu = driver.FindElement(By.XPath(Constants.Catalogmenu));
                catalogmenu.Click();
                Thread.Sleep(2000);
                IWebElement products = driver.FindElement(By.XPath(Constants.Products));
                products.Click();
                Thread.Sleep(2000);
                //IWebElement s = driver.FindElement(By.XPath("//button[@aria-controls='products-grid']"));
                //IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
                //je.ExecuteScript("arguments[0].scrollIntoView(false);", s);
                IWebElement searchBtn = driver.FindElement(By.XPath("//button[@id='search-products']/i"));
                Assert.IsTrue(searchBtn.Displayed);
                //Assert.IsTrue(searchBtn.Text.Contains("Search"));
                Thread.Sleep(2000);
            }

            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        

        [Test]
        public void _003_Validate_Add_New_Product()

        {
            try
                {
                login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
                IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
                adminpage.Click();
                Thread.Sleep(2000);
                IWebElement catalogmenu = driver.FindElement(By.XPath(Constants.Catalogmenu));
                catalogmenu.Click();
                Thread.Sleep(2000);
                IWebElement products = driver.FindElement(By.XPath(Constants.Products));
                products.Click();
                Thread.Sleep(2000);
                IWebElement AddnewProduct = driver.FindElement(By.XPath(Constants.AddNewProductBtn));
                //AddnewProduct.Click();
                MoveToElement("//a[@class='btn btn-primary']");
                Thread.Sleep(2000);
                IWebElement ProductNametxt = driver.FindElement(By.XPath(Constants.ProductNametxt));
                ProductNametxt.Click();
                ProductNametxt.SendKeys("HCL1");
                IWebElement Categoriestxt = driver.FindElement(By.XPath(Constants.Categoriestxt));
                Categoriestxt.Click();
                Thread.Sleep(2000);
                IReadOnlyList<IWebElement> Categorylist = driver.FindElements(By.XPath(Constants.Categorieslist));
                if (Categorylist.Count >= 1)
                {
                    foreach (IWebElement list in Categorylist)
                    {
                        if (list.Text.Contains("Fashion"))
                        {
                            list.Click();                            
                        }
                    }
                }

                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw ex.InnerException;
            }
        }

        [Test]
        public void _004_Validate_product_edit()

        {
            login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
            IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
            adminpage.Click();
            Thread.Sleep(2000);
            IWebElement catalogmenu = driver.FindElement(By.XPath(Constants.Catalogmenu));
            catalogmenu.Click();
            Thread.Sleep(2000);
            IWebElement products = driver.FindElement(By.XPath(Constants.Products));
            products.Click();
            Thread.Sleep(2000);            
            IReadOnlyList<IWebElement> productgrid = driver.FindElements(By.XPath(Constants.Producttable));
            Thread.Sleep(2000);
            if (productgrid.Count >= 1)
            {
                for (int i = 1; i <= productgrid.Count; i++)
                {
                    IWebElement producttable = driver.FindElement(By.XPath("//table[@id='products-grid']//tr[" + i + "]"));
                    if (producttable.Text.Contains(ConfigProvider.GetconfigValue("ProductEdit")))
                    {
                        IWebElement prodedit1 = driver.FindElement(By.XPath("//a[@class='btn btn-default'][@href='Edit/" + i + "']"));
                        prodedit1.Click();
                        Thread.Sleep(3000);
                    }                    
                }
            }
        }

        [Test]
        public void _005_Validate_Pagination()
        {
            login(ConfigProvider.GetconfigValue(Constants.Username), ConfigProvider.GetconfigValue(Constants.Password));
            IWebElement adminpage = driver.FindElement(By.XPath(Constants.Administrator));
            adminpage.Click();
            Thread.Sleep(2000);
            IWebElement catalogmenu = driver.FindElement(By.XPath(Constants.Catalogmenu));
            catalogmenu.Click();
            Thread.Sleep(2000);
            IWebElement products = driver.FindElement(By.XPath(Constants.Products));
            products.Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(2000);
            IWebElement pagination = driver.FindElement(By.CssSelector(Constants.pagination));
            pagination.Click();
            Thread.Sleep(2000);
            IWebElement pageno = driver.FindElement(By.XPath("//option[@value='7']"));
            pageno.Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> productgrid = driver.FindElements(By.XPath(Constants.Producttable));
            Thread.Sleep(2000);
            if (productgrid.Count >= 1)
            {
                for (int i = 1; i <= productgrid.Count; i++)
                {
                    IWebElement producttable = driver.FindElement(By.XPath("//table[@id='products-grid']//tr[" + i + "]"));
                    if (producttable.Text.Contains(ConfigProvider.GetconfigValue("ProductEdit")))
                    {                        
                        for (int j= 1; j<= 100; j++)
                        {
                            IWebElement prodedit1 = driver.FindElement(By.XPath("//a[@class='btn btn-default'][@href='Edit/" + j + "']"));
                            if (producttable.Text.Contains(ConfigProvider.GetconfigValue("ProductEdit")))
                            {
                                prodedit1.Click();
                            }                                
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        IWebElement nextbtn = driver.FindElement(By.CssSelector("li#products-grid_next"));
                        nextbtn.Click();
                    }
                }
            }

        }
    }
}
