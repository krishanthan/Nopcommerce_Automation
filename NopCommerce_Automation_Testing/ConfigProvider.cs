using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace NopCommerce_Automation_Testing
{
    public static class ConfigProvider
    {
        public static string GetconfigValue(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }
    }
}
