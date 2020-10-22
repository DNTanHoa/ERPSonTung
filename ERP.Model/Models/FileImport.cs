using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Models
{
    public class FileImport : BaseModel
    {
        public string Code { get; set; }
        public string TextName { get; set; }
        public string Path { get; set; }
        public string SaveName { get; set; }
        public string Entity { get; set; }
    }
}
