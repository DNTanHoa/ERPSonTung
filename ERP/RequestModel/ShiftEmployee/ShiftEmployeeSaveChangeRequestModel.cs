using System;
using System.Collections.Generic;

namespace ERP.RequestModel
{
    public class ShiftEmployeeSaveChangeRequestModel
    {
        public long Id { get; set; }
        public string ShiftCode { get; set; }
        public string EmployeeCode { get; set; }
    }
}
