using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ERP.Ultilities.Global
{
    public class RoleMessageGlobal
    {
        public static IConfigurationSection configurationSection;
        
        static RoleMessageGlobal()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationSection = builder.Build().GetSection("Messages").GetSection("Role");
        }

        public static string GetMessage(string Key, params object[] args)
        {
            return string.Format(configurationSection.GetSection(Key).Value, args);
        }

        //example get EmptyFirstName
        //public static string EmptyFirstName => GetMessage("EmptyFirstName");
    }
}
