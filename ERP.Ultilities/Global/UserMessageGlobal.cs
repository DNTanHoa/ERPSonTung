using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ERP.Ultilities.Global
{
    public class UserMessageGlobal
    {
        public static IConfigurationSection configurationSection;
        
        static UserMessageGlobal()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationSection = builder.Build().GetSection("Messages").GetSection("User");
        }

        public static string GetMessage(string Key, params object[] args)
        {
            return string.Format(configurationSection.GetSection(Key).Value, args);
        }

        public static string ExistUsername => GetMessage("ExistUsername");
        
        public static string NotExistUsername => GetMessage("NotExistUsername");
        
        public static string NotExistUser => GetMessage("NotExistUser");
    }
}
