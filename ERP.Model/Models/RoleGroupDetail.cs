using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Chi tiết của nhóm phân quyền
    /// </summary>
    public partial class RoleGroupDetail : BaseModel
    {
        public string RoleGroupCode { get; set; }       //mã nhóm phân quyền
        public string NavigationCode { get; set; }      //Mã navigation
        public bool? IsAllow { get; set; }              //Cho phép/không
        public string Entity { get; set; }              //Tên entity navigation
        public bool? CanCreate { get; set; }            //có thể tạo
        public bool? CanUpdate { get; set; }            //có thể updat
        public bool? CanRead { get; set; }              //có thể đọc
        public bool? CanDelete { get; set; }            //có thể xóa
    }
}
