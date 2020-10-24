using ERP.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Employee
{
    public class EmployeeContactDetailRequestModel : BaseModel
    {
        public string Code { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// Temporary là tạm trú
        /// </summary>
        public string TemporaryProvinceCode { get; set; }

        public string TemporaryDistrictCode { get; set; }

        public string TemporaryWardCode { get; set; }

        public string TemporaryAddtional { get; set; }

        public string TemporaryAddress { get; set; }

        /// <summary>
        /// Origin là thường trú
        /// </summary>
        public string OriginProvinceCode { get; set; }

        public string OriginDistrictCode { get; set; }

        public string OriginWardCode { get; set; }

        public string OriginAddtional { get; set; }

        public string OriginAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "không hợp lệ")]
        public string Phone { get; set; }

        public string CompanyEmail { get; set; }

        public string PersonalEmail { get; set; }
    }
}