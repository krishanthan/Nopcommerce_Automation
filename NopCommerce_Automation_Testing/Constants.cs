using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Automation_Testing
{
    public static class Constants
    {
        public const string Login = "//a[@class='ico-login']";
        public const string Emailtxt = "//input[@class='email']";
        public const string Username = "Email";
        public const string Password = "password";
        public const string passwordtxt = "//input[@class='password']";
        public const string Loginbtn = "//button[@type='submit'][text()='Log in']";
        public const string Administrator = "//a[@class='administration'][text()='Administration']";
        public const string Logout = "//a[text()='Logout']";
        

        //Catagol
        public const string Catalogmenu = "//ul[@class='nav nav-pills nav-sidebar flex-column nav-legacy']/li[@class='nav-item has-treeview'][1]";
        public const string Products = "//p[text()='Products']";
        public const string AddNewProductBtn = "//a[@class='btn btn-primary']";

        //Product page
        public const string ProductNametxt = "//input[@id='Name']";
        public const string ProductDescription = "//textarea[@name='ShortDescription']";
        public const string SKU = "//input[@id='Sku']";
        public const string Categoriestxt = "//div[@role='listbox']";
        public const string Categorieslist = "//li[@tabindex='-1'][@class='k-item']";
        public const string Producttable = "//table[@id='products-grid']//tr";
        public const string pagination = "select[name='products-grid_length']";

        //Promotions page
        public const string promotionmenu = "/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[5]/a";
        public const string campaigne = "//p[text()='Campaigns']";
        public const string emailcampaignelink = "//a[text()='email campaigns']";

    }
}
