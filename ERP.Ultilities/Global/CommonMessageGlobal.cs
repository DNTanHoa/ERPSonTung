﻿using Microsoft.Extensions.Configuration;
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

        public static string GetMessage(string Key, params object[] args)
        {
            return string.Format(configurationSection.GetSection(Key).Value, args);
        }

        //example get 404
        public static string _404 => GetMessage("404");

        public static string Require(string fieldName) => GetMessage("Require", fieldName);
        public static string Minimum(string fieldName, int minCharacter) => GetMessage("Minimum", fieldName, minCharacter);
        public static string Maximum(string fieldName, int maxCharacter) => GetMessage("Require", fieldName, maxCharacter);
        public static string NotExistInCategory(string fieldName) => GetMessage("NotExistInCategory", fieldName);
    }
}
