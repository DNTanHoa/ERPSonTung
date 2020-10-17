using ERP.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.EmployeeRelative
{
    public class EmployeeRelativeRequest:BaseModel
    {
        [Required(ErrorMessage = "Mã nhân viên - bắt buộc")]
        [MinLength(4)]
        [MaxLength(20)]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Mối quan hệ - bắt buộc")]
        [MinLength(2)]
        [MaxLength(20)]
        public string RelativeType { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Chỗ ở hiện nay - bắt buộc")]
        public string OriginAddress { get; set; }

        [Required(ErrorMessage = "Công việc - bắt buộc")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Công việc - bắt buộc")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tỉnh thành - bắt buộc")]
        [MinLength(2)]
        [MaxLength(20)]
        public string OriginAddressCode { get; set; }

        [Required(ErrorMessage = "Họ và tên - bắt buộc")]
        public string Name { get; set; }
    }
}