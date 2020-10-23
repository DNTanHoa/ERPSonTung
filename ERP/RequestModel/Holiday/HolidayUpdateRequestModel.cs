using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Holiday
{
    public class HolidayUpdateRequestModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Mã ngày lễ không được để trống")]
        public string Code { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryIncreasePercent { get; set; }
    }
}