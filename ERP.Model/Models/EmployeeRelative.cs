using System;

namespace ERP.Model.Models
{
    /// <summary>
    /// Quản lí người thân nhân viên
    /// </summary>
    public partial class EmployeeRelative : BaseModel
    {
        public string EmployeeCode { get; set; }        //mã nhân viên
        public string RelativeType { get; set; }        //loại liên quan: Cha,mẹ...
        public DateTime? DateOfBirth { get; set; }      //Ngày sinh
        public string OriginAddress { get; set; }       //Địa chỉ thường trú
        public string Job { get; set; }                 //Công việc
        public string Phone { get; set; }               //Số điện thoại
        public string OriginProvinceCode { get; set; }  //Mã tỉnh
        public bool IsDependentPerson { get; set; }     //Phụ thuộc hay không
        public string Name { get; set; }                //Tên người thân

    }
}