using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;

namespace ERP.ResponeModel
{
    public class LoginResponeModel : BaseResponeModel
    {
        public DateTime? TokenExpireDate { get; set; }

        public string Token { get; set; }

        //public User LoginUser { get; set; }
        public UserDataTransfer User { get; set; }
    }
}
