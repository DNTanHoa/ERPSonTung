using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ERP.Ultilities.Extensions
{
    public static class ObjectExtensions
    {
        public static Dictionary<string, string> ToDictionaryStringString(this object obj)
        {
            if (obj != null)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    result.Add(prop.Name, prop.GetValue(obj)?.ToString());
                }
                return result;
            }
            return null;
        }

        public static T MapTo<T>(this object obj)
        {
            var result = Activator.CreateInstance<T>();
            PropertyInfo[] props = result.GetType().GetProperties();
            foreach (var prop in props)
            {
                try
                {
                    var pairValue = obj.GetType().GetProperty(prop.Name)?.GetValue(obj);
                    var type = result.GetType()?.GetProperty(prop.Name)?.PropertyType;
                    result.GetType().GetProperty(prop.Name).SetValue(result, Convert.ChangeType(pairValue, type));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }

        public static T MapToByAttribute<T>(this object obj)
        {
            var result = Activator.CreateInstance<T>();
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var attrs = prop.GetCustomAttributes(true);
                var mapPropertyName = attrs.FirstOrDefault(item => item.GetType() == typeof(MapPropertyName));
                if (mapPropertyName != null)
                {
                    try
                    {
                        var pairValue = obj.GetType().GetProperty(prop.Name).GetValue(obj);
                        var type = obj.GetType().GetProperty(((MapPropertyName)mapPropertyName).Name).GetType();
                        result.GetType().GetProperty(((MapPropertyName)mapPropertyName).Name).SetValue(result, Convert.ChangeType(pairValue, type));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return result;
        }

        public static void MapFrom<T>(this object obj, T source)
        {
            if (source != null)
            {
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var pairValue = source.GetType().GetProperty(prop.Name)?.GetValue(source);
                    var type = obj.GetType().GetProperty(prop.Name).PropertyType;
                    obj.GetType().GetProperty(prop.Name).SetValue(obj, Convert.ChangeType(pairValue, type));
                }
            }
        }

        public static void MapFromByAttribute<T>(this object obj, T source)
        {
            if (source != null)
            {
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var attrs = prop.GetCustomAttributes(true);
                    var mapPropertyName = attrs.FirstOrDefault(item => item.GetType() == typeof(MapPropertyName));
                    if (mapPropertyName != null)
                    {
                        try
                        {
                            var pairValue = source.GetType().GetProperty(((MapPropertyName)mapPropertyName).Name)?.GetValue(source);
                            var type = prop.PropertyType;
                            obj.GetType().GetProperty(prop.Name).SetValue(obj, Convert.ChangeType(pairValue, type));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        public static void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
    }
}
