using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// phân quyền đăng nhập
    /// </summary>
    public partial class UserRole : BaseModel
    {
        public string Username { get; set; }        //Tên người dùng
        public string NavigationCode { get; set; }  //Mã navigate
        public bool? IsAllow { get; set; }          //Cho phép/không
        public string Entity { get; set; }          //Tên entity naigation
        public bool? CanCreate { get; set; }        //có thể tạo
        public bool? CanUpdate { get; set; }        //có thể update    
        public bool? CanRead { get; set; }          //có thể đọc
        public bool? CanDelete { get; set; }        //có thể xóa
    }
}
