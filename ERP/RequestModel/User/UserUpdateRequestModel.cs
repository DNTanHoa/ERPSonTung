using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.User
{
    public class UserUpdateRequestModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public string EmployeeCode { get; set; }

        public string Note { get; set; }
    }
}
