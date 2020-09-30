using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MVC.Models.Employee
{
    public class EmployeeIdentityDetailModel : BaseModel
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
