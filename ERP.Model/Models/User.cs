using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string GuidCode { get; set; }
        public bool? IsActive { get; set; }
        public string EmployeeCode { get; set; }
    }
}
