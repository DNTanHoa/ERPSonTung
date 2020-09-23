using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.User
{
    public class LoginUserRequestModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(4, ErrorMessage = "Mật khẩu phải có ít nhất 4 ký tự")]
        public string Password { get; set; }

        public bool RememberPassword { get; set; }
    }
}
