using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ERP.Ultilities.Helpers
{
    public static class XmlReader
    {
        /// TODO: Chưa test vì chưa dùng
        /// <summary>
        /// Map Attribute node to T class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static T MapTo<T>(this XElement element)
        {
            //property in T type
            var result = Activator.CreateInstance<T>();
            PropertyInfo[] props = result.GetType().GetProperties();
            foreach (var prop in props)
            {
                try
                {
                    //get source object value
                    var pairValue = element.Attribute(prop.Name);

                    //set object value to T
                    result.GetType().GetProperty(prop.Name).SetValue(result, pairValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
