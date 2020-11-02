using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// thông tin đăng nhập
    /// </summary>
    public partial class User : BaseModel
    {
        public string Username { get; set; }        //Tên đăng nhập
        public string Password { get; set; }        //Mật khẩu
        public string GuidCode { get; set; }        //Guild code
        public bool? IsActive { get; set; }         //Hoạt động/Không
        public string EmployeeCode { get; set; }    //Mã nhân viên
    }
}
