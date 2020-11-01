using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Hợp đồng nhân viên
    /// </summary>
    public partial class EmployeeContract : BaseModel
    {
        public string ContractType { get; set; }        //Loại hợp đồng: thử việc, chính thức...
        public DateTime? SignDate { get; set; }         //Ngày ký
        public DateTime? EffectiveDate { get; set; }    //Ngày hiệu lực
        public DateTime? ExpireDate { get; set; }       //Ngày hết hạn
        public decimal? ContractSalary { get; set; }    //Lương ghi trên hợp đồng
        public decimal? RealSalary { get; set; }        //Lương thực tế, mặc định = lương hợp đồng x % lương loại hợp đồng
        public decimal? InsurranceSalary { get; set; }  //Lương đóng bảo hiểm
        public string CompanySignPerson { get; set; }   //Mã người đại diện công ty
        public string EmployeeSignPerson { get; set; }  //Mã nhân viên kí
        public string MainContent { get; set; }         //Nội dung chính
        public string Path { get; set; }                //Đường dẫn lưu file scan
        public string NumberCode { get; set; }          //Số hợp đồng
        public string StatusCode { get; set; }          //Trạng thái hợp đồng: Hiệu lực, hết hạn
        public decimal? SalaryPercent { get; set; }     //Phần trăm lương trên hợp đồng
        public string JobCode { get; set; }             //Vị trí công việc
        public string ParentCode { get; set; }          //Khi là phụ lục hợp đồng, sẽ lưu lại số HĐ
        public string ContractFormCode { get; set; }    //Hình thức làm việc: toàn thời gian, bán thời gian, cộng tác viên
    }
}
