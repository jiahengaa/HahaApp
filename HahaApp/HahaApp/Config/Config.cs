using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaApp
{
    public class Config
    {
        public static string BaseUrl { get; private set; }
        public static bool IsDebug { get; private set; }
        public static void InitConfig()
        {
            IsDebug = ConfigurationManager.AppSettings["IsDebug"].ToString().Trim() == "true";
            if (ConfigurationManager.AppSettings["IsDebug"].ToString().Trim() == "true")
            {
                BaseUrl = ConfigurationManager.AppSettings["debugUrlBase"].ToString().Trim();
            }
            else
            {
                BaseUrl = ConfigurationManager.AppSettings["productUrlBase"].ToString().Trim();
            }
        }
    }
}
