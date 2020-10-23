using ERP.Model.Models;
using System;

namespace ERP.RequestModel.EmployeeRelative
{
    public class EmployeeRelativeRequest : BaseModel
    {
        public string EmployeeCode { get; set; }

        public string RelativeType { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public string OriginAddress { get; set; }

        public string Job { get; set; }

        public string Phone { get; set; }

        public string OriginProvinceCode { get; set; }

        public bool IsDependentPerson { get; set; }

        public string Name { get; set; }
    }
}