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

        public static string GetMessage(string Key, params object[] args)
        {
            return string.Format(configurationSection.GetSection(Key).Value, args);
        }

        //example get 404
        public static string _404 => GetMessage("404");
        public static string CheckSuccess => GetMessage("CheckSuccess");
        public static string CheckFail => GetMessage("CheckFail");
        public static string Require(string fieldName) => GetMessage("Require", fieldName);
        public static string Minimum(string fieldName, int minCharacter) => GetMessage("Minimum", fieldName, minCharacter);
        public static string Maximum(string fieldName, int maxCharacter) => GetMessage("Maximum", fieldName, maxCharacter);
        public static string NotExistInCategory(string fieldName) => GetMessage("NotExistInCategory", fieldName);

        public static string Invalid(string fieldName) => GetMessage("Invalid", fieldName);
        public static string GreaterThanOrEqual(string fieldName, int number) => GetMessage("GreaterThanOrEqual", fieldName, number);
        public static string GreaterThan(string fieldName, int number) => GetMessage("GreaterThan", fieldName, number);
        public static string LessThanOrEqual(string fieldName, int number) => GetMessage("LessThanOrEqual", fieldName, number);
        public static string LessThan(string fieldName, int number) => GetMessage("LessThan", fieldName, number);

    }
}
