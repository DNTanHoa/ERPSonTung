using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Navigation
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string DisplayName { get; set; }
        public long? ParentId { get; set; }
    }
}
