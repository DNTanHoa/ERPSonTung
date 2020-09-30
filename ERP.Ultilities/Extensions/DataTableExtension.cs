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
        public static List<T> ToList<T>(this DataTable table)
        {
            var result = new List<T>();
            foreach(DataRow row in table.Rows)
            {
                result.Add(row.AsObject<T>());
            }    
            return result;
        }

        public static IEnumerable<T> ToEnumerable<T>(this DataTable table)
        {
            var result = new List<T>();
            foreach(DataRow row in table.Rows)
            {
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
