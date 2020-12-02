using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.ResponeModel
{
    public class EmployeeDetailResponeModel : BaseResponeModel
    {
        public string Code { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public DateTime StartDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string StatusCode { get; set; }

        public string CheckInOutCode { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string DepartmentCode { get; set; }

        public string GroupCode { get; set; }

        public string LaborGroupCode { get; set; }

        public string PositionCode { get; set; }

        public string SupervisorCode { get; set; }

        public string JobCode { get; set; }

        public string TaxNumber { get; set; }

        public string Image { get; set; }                       //Path avata

    }
}
