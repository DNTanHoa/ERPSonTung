using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class RoleDataTransfer : UserRole
    {
        public Navigation Navigation { get; set; }
    }
}
