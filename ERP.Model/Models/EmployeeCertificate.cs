using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Chứng chỉ, văn bằng nhân viên
    /// </summary>
    public partial class EmployeeCertificate : BaseModel
    {
        public string EmployeeCode { get; set; }                //Mã nhân viên
        public string CertificateName { get; set; }             //Tên chứng chỉ
        public string CertificatePlace { get; set; }            //Nơi cấp
        public string CertificateType { get; set; }             //Xếp loại chứng chỉ: khá, giỏi...
        public string CertificateForm { get; set; }             //Hình thức đào tạo chứng chỉ: Chính quy, tại chức...
        public DateTime? CertificateEffectiveDate { get; set; } //Ngày hiệu lực
        public DateTime? CertificateExpireDate { get; set; }    //Ngày hết hạn, null nếu không hết hạn
        public string Path { get; set; }                        //Đường dẫn file scan
    }
}
