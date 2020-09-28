using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class UserDataTransfer : User
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public EmployeeModelTemplate cbxEmployee { get; set; } = new EmployeeModelTemplate();
    }
}
