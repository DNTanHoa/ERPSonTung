using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

using System.Text;

namespace ERP.Ultilities.Global
{
    public class CategoryMessageGlobal
    {
        public static IConfigurationSection configurationSection;
        
        static CategoryMessageGlobal()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationSection = builder.Build().GetSection("Messages").GetSection("Category");
        }

        public static string GetMessage(string Key, params object[] args)
        {
            return string.Format(configurationSection.GetSection(Key).Value, args);
        }

        //example get EmptyFirstName
        //public static string EmptyFirstName => GetMessage("EmptyFirstName");
    }
}
