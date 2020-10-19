using ERP.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Employee
{
    public class EmployeeDayOffRequest : BaseModel
    {
        [Required(ErrorMessage = "Mã nhân viên - bắt buộc")]
        [MinLength(2)]
        [MaxLength(20)]
        public string EmployeeCode { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        [Required(ErrorMessage = "Lý do nghỉ - bắt buộc")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "trạng thái duyệt - bắt buộc")]
        public string ApproveStatus { get; set; }
    }
}