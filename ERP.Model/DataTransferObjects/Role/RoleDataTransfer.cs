using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class RoleDataTransfer : UserRole
    {
        public User User { get; set; }

        public Navigation Navigation { get; set; }
    }
}
