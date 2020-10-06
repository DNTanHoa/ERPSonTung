using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.ResponeModel
{
    public class EmployeeIdentityDetailResponeModel : BaseResponeModel
    {
        [Required(ErrorMessage = "không được để trống")]
        public string Code { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string NationCode { get; set; }
        
        [Required(ErrorMessage = "không được để trống")]
        public string NationalityCode { get; set; }
        
        [Required(ErrorMessage = "Không được để trống")]
        public string IdentityNumber { get; set; }
        
        [Required(ErrorMessage = "Không được để trống")]
        public DateTime? IdentityLicenseDate { get; set; }
        
        [Required(ErrorMessage = "Kkhoogn được để trống")]
        public string IdentityLicensePlaceCode { get; set; }

        public string ReligionCode { get; set; }

        public string TitleCode { get; set; }

        public string GenderCode { get; set; }

        public string Image { get; set; }
    }
}
