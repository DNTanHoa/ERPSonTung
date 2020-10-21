using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.Holiday
{
    public class HolidayCreateRequestModel
    {
        [Required(ErrorMessage = "Mã ngày lễ không được để trống")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? SalaryIncreasePercent { get; set; }
    }
}
