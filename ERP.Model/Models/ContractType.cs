using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Hợp đồng
    /// </summary>
    public class ContractType : BaseModel
    {
        public string Code { get; set; }                //Mã loại hợp đồng
        public string TextName { get; set; }            //Tên loại hợp đồng: thử việc, chính thức...
        public decimal? SalaryPercent { get; set; }     //Phần trăm lương trên hợp đồng
        public int? NumberOfDate { get; set; }          //Số ngày làm việc trên hợp đồng
        public int? AnnualLeave { get; set; }           //Tổng số ngày nghỉ phép
        public string TemplatePath { get; set; }        //Mẫu hợp đồng
    }
}
