using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MVC.Models
{
    public class EmployeeDetailModel
    {
        [Required(ErrorMessage = "không được để trống")]
        public string Code { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public DateTime? StartDate { get; set; }

        public string StatusCode { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        public string DepartmentCode { get; set; }
        
        public string GroupCode { get; set; }
        
        public string LaborGroupCode { get; set; }

        public string PositionCode { get; set; }

        public string SupervisorCode { get; set; }

        public string JobCode { get; set; }
    }
}
