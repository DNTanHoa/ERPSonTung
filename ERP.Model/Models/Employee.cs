using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Employee : BaseModel
    {
        
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string OriginAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string ReligionCode { get; set; }
        public string DepartmentCode { get; set; }
        public string GroupCode { get; set; }
        public string NationCode { get; set; }
        public string NationalityCode { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityLicenseDate { get; set; }
        public string IdentityLicensePlaceCode { get; set; }
        public string Phone { get; set; }
        public string CompanyEmail { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime? StartDate { get; set; }
        public string StatusCode { get; set; }
        public string TitleCode { get; set; }
        public string GenderCode { get; set; }
        public string SupervisorCode { get; set; }
        public string PositionCode { get; set; }
        public string Image { get; set; }
        public string BankCode { get; set; }
        public string JobCode { get; set; }
        public string LaborGroupCode { get; set; }
        public string BankNumber { get; set; }
        public int Age { get; set; }
        public int ExperienceYear { get; set; }
        public string TemporaryProvinceCode { get; set; }
        public string TemporaryDistrictCode { get; set; }
        public string TemporaryWardCode { get; set; }
        public string TemporaryAddtional { get; set; }
        public string OriginProvinceCode { get; set; }
        public string OriginDistrictCode { get; set; }
        public string OriginWardCode { get; set; }
        public string OriginAddtional { get; set; }
    }
}
