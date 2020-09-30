using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.ResponeModel
{
    public class LoginResponeModel
    {
        public DateTime? TokenExpireDate { get; set; }

        public string Token { get; set; }

        public User LoginUser { get; set; }
    }
}
