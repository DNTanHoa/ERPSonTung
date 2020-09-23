using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Role
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string Username { get; set; }
        public string NavigationCode { get; set; }
        public bool? IsAllow { get; set; }
        public string Entity { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanRead { get; set; }
        public bool? CanDelete { get; set; }
    }
}
