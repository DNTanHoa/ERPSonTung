using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.Role
{
    public class RoleGroupDetailCreateRequestModel
    {
        [Required(ErrorMessage = "Mã nhóm phân quyền không được để trống")]
        public string RoleGroupCode { get; set; }

        [Required(ErrorMessage = "Mã phân quyền không được để trống")]
        public string NavigationCode { get; set; }
        
        public bool? IsAllow { get; set; }
        
        public string Entity { get; set; }
        
        public bool? CanCreate { get; set; }
        
        public bool? CanUpdate { get; set; }
        
        public bool? CanRead { get; set; }
        
        public bool? CanDelete { get; set; }
    }
}
