using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Ngày nghỉ
    /// </summary>
    public partial class Holiday : BaseModel
    {
        public string Code { get; set; }                    //Mã ngày nghỉ
        public string Name { get; set; }                    //Tên ngày nghỉ
        public DateTime? StartDate { get; set; }            //Ngày bắt đầu
        public DateTime? EndDate { get; set; }              //Ngày kết thúc        
        public decimal? SalaryIncreasePercent { get; set; } //Phần trăm lương
    }
}
