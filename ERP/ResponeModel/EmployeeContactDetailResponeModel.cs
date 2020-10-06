using System.ComponentModel.DataAnnotations;

namespace ERP.ResponeModel
{
    public class EmployeeContactDetailResponeModel : BaseResponeModel
    {
        [Required(ErrorMessage = "không được để trống")]
        public string Code { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string TemporaryProvinceCode { get; set; }

        public string TemporaryDistrictCode { get; set; }

        public string TemporaryWardCode { get; set; }

        public string TemporaryAddtional { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string TemporaryAddress { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string OriginProvinceCode { get; set; }

        public string OriginDistrictCode { get; set; }

        public string OriginWardCode { get; set; }

        public string OriginAddtional { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string OriginAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "không hợp lệ")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "không hợp lệ")]
        public string CompanyEmail { get; set; }

        [EmailAddress(ErrorMessage = "không hợp lệ")]
        public string PersonalEmail { get; set; }
    }
}
