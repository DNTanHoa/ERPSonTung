using System;

namespace ERP.Model.Models
{
    public partial class EmployeeRelative : BaseModel
    {
        public string EmployeeCode { get; set; }
        public string RelativeType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string OriginAddress { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string OriginProvinceCode { get; set; }

        public bool IsDependentPerson { get; set; }

        public string Name { get; set; }

    }
}