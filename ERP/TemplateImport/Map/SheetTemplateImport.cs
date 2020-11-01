using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using ERP.Ultilities.Extensions;

namespace ERP.TemplateImport
{
    public class SheetTemplateImport
    {
        //sheet name
        public string SheetName { get; set; }

        public List<ColumnTemplateImport> Columns { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="Url">path to xml file to load</param>
        public SheetTemplateImport(string Url)
        {
            readXmlTemplate(Url);
        }

        /// <summary>
        /// Read xml file and load to properties
        /// </summary>
        /// <param name="Url"></param>
        private void readXmlTemplate(string Url)
        {
            try
            {
                // Loading from a file, you can also load from a stream
                var xml = XDocument.Load(Url);

                this.SheetName = (string)xml.Root.Attribute("Name");

                // Query the data and write out a subset of contacts
                var query = from c in xml.Root.Descendants("Column")
                            select new ColumnTemplateImport()
                            {
                                propertyName = (string)c.Attribute("propertyName"),
                                excelColumn = (int)c.Attribute("excelColumn")
                            };

                this.Columns = query?.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get column index in excel file search by property name
        /// </summary>
        /// <param name="propertyName">property name to search</param>
        /// <returns>-1: not found, int: index if found</returns>
        public int getIndexByPropertyName(string propertyName)
        {
            var column = Columns.Where(item => item.propertyName == propertyName).FirstOrDefault();
            return column == null ? -1 : column.excelColumn;
        }
    }
}
