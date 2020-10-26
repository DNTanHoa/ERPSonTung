using System;

namespace ERP.RequestModel
{
    public class CandidateUpdateRequestModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string OriginProvinceCode { get; set; }
        public string OriginDistrictCode { get; set; }
        public string OriginWardCode { get; set; }
        public string OriginAddtional { get; set; }
        public string OriginAddress { get; set; }
        public string TemporaryProvinceCode { get; set; }
        public string TemporaryDistrictCode { get; set; }
        public string TemporaryWardCode { get; set; }
        public string TemporaryAddtional { get; set; }
        public string TemporaryAddress { get; set; }
        public string ReligionCode { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityLicenseDate { get; set; }
        public string IdentityLicensePlaceCode { get; set; }
        public string Phone { get; set; }
        public string PersonalEmail { get; set; }
        public string GenderCode { get; set; }
        public string RecruitmentPlanCode { get; set; }
    }
}