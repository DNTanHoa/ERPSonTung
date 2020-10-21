using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ERP.Ultilities.Global
{
    public class CommonMessageGlobal
    {
        public static IConfigurationSection configurationSection;
        
        static CommonMessageGlobal()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationSection = builder.Build().GetSection("Messages").GetSection("Common");
        }

        public static string GetMessage(string Key)
        {
            return configurationSection.GetSection(Key).Value;
        }

        //example get 404
        public static string _404 => GetMessage("404");
    }
}
