using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERP.Model.Extensions
{
    public static class EmployeeExtension
    {
        public static void InitDefault(this Employee employee)
        {
            if (employee.FirstName.EndsWith(" "))
                employee.FullName = employee.FirstName + employee.LastName;
            else
                employee.FullName = employee.FirstName + " " + employee.LastName;
        }
    }
}
