using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace ERP.Ultilities.Extensions
{
    public static class DataTableExtension
    {
        public static List<T> ToList<T>(this DataTable table, bool checkError = false)
        {
            var result = new List<T>();
            foreach(DataRow row in table.Rows)
            {
                if(checkError)
                {
                    result.Add(row.AsObjectCheckError<T>());
                }
                result.Add(row.AsObject<T>());
            }    
            return result;
        }

        public static IEnumerable<T> ToEnumerable<T>(this DataTable table, bool checkError = false)
        {
            var result = new List<T>();
            foreach(DataRow row in table.Rows)
            {
                if (checkError)
                {
                    yield return row.AsObjectCheckError<T>();
                }
                yield return row.AsObject<T>();
            }    
        } 
        
        public static T AsObject<T> (this DataRow tableRow)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in tableRow.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && tableRow[column.ColumnName] != DBNull.Value)
                    {
                        Type t = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                        pro.SetValue(obj, Convert.ChangeType(tableRow[column.ColumnName], t), null);
                        continue;
                    }
                }
            }
            return obj;
        }

        public static T AsObjectCheckError<T>(this DataRow tableRow)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in tableRow.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && tableRow[column.ColumnName] != DBNull.Value)
                    {
                        try
                        {
                            Type t = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                            pro.SetValue(obj, Convert.ChangeType(tableRow[column.ColumnName], t), null);
                            continue;
                        }
                        catch(Exception ex)
                        {
                            obj.GetType().GetProperty("IsError")?.SetValue(obj, true);
                            var errorList = (IList<string>)obj.GetType().GetProperty("ErrorMessage");
                            if(errorList != null)
                            {
                                errorList.Add(ex.Message);
                            }
                            obj.GetType().GetProperty("ErrorMessage")?.SetValue(obj, errorList);
                        }
                    }
                }
            }
            return obj;
        }

        public static Dictionary<string, object> ToDictionaryStringObject(this DataRow tableRow)
        {
            var content = new Dictionary<string, object>();
            foreach(DataColumn column in tableRow.Table.Columns)
            {
                content.Add(column.ColumnName, tableRow[column]);
            }
            return content;
        }

        public static string ToJson(this DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
