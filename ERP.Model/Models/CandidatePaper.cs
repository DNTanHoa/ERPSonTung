using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public class CandidatePaper : BaseModel
    {
        public string CandidateCode { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string TextName { get; set; }
        public string Path { get; set; }
    }
}
