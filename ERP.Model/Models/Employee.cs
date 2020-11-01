using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Quản lý nhân viên toàn công ty
    /// </summary>
    public partial class Employee : BaseModel
    {
        public string Code { get; set; }                        //Mã nhân viên
        public string FirstName { get; set; }                   //Tên
        public string LastName { get; set; }                    //Họ và chữ lót
        public string FullName { get; set; }                    //Tên đầy đủ
        public DateTime? DateOfBirth { get; set; }              //ngày sinh
        public string OriginAddress { get; set; }               //Thường trú đầy đủ
        public string TemporaryAddress { get; set; }            //Tạm trú đầy đủ
        public string ReligionCode { get; set; }                //Mã tôn giáo
        public string DepartmentCode { get; set; }              //Mã phòng ban
        public string GroupCode { get; set; }                   //Nhóm: trực tiếp, gián tiếp
        public string NationCode { get; set; }                  //Mã dân tộc
        public string NationalityCode { get; set; }             //Mã quốc gia
        public string IdentityNumber { get; set; }              //Số CMND
        public DateTime? IdentityLicenseDate { get; set; }      //Ngày cấp
        public string IdentityLicensePlace { get; set; }        //Nơi cấp CMND
        public string IdentityPlace { get; set; }               //Nguyên quán trong CMND
        public string Phone { get; set; }                       //số điện thoại
        public string CompanyEmail { get; set; }                //email công ty
        public string PersonalEmail { get; set; }               //email cá nhân
        public DateTime? StartDate { get; set; }                //Ngày bắt đầu làm việc
        public string StatusCode { get; set; }                  //Thử việc, nhân viên chính thức, đã nghỉ...
        public string TitleCode { get; set; }                   //Tên công việc đảm nhiệm: VD: Thủ kho, kế toán trưởng...
        public string GenderCode { get; set; }                  //Mã giới tính
        public string SupervisorCode { get; set; }              //Người giám sát
        public string PositionCode { get; set; }                //Vị trí công việc: Giám đốc, Phó phòng....
        public string Image { get; set; }                       //Path avata
        public string BankCode { get; set; }                    //Tài khoản ngân hàng (chính)
        public string BankNumber { get; set; }                  //Số tài khoản ngân hàng (chính)
        public string SubBankCode { get; set; }                 //Tài khoản ngân hàng (phụ)
        public string SubBankNumber { get; set; }               //Số tài khoản ngân hàng (phụ)
        public string JobCode { get; set; }                     //Mã vị trí công việc
        public string LaborGroupCode { get; set; }              //Nhóm lao động
        public string TemporaryProvinceCode { get; set; }       //Tỉnh/Thành phố (tạm trú)
        public string TemporaryDistrictCode { get; set; }       //Quận/Huyện (tạm trú)
        public string TemporaryWardCode { get; set; }           //Phường/xã (tạm trú)
        public string TemporaryAddtional { get; set; }          //Số nhà (tạm trú)
        public string OriginProvinceCode { get; set; }          //Tỉnh/Thành phố (thường trú)
        public string OriginDistrictCode { get; set; }          //Quận/Huyện (thường trú)
        public string OriginWardCode { get; set; }              //Phường/xã (thường trú)
        public string OriginAddtional { get; set; }             //Số nhà (thường trú)
        public string CheckInOutCode { get; set; }              //Mã chấm công
        public string TaxNumber { get; set; }                   //Mã số thuế
        public string EducationLevel { get; set; }              //Trình độ văn hóa 1/12-12/12
        public string QualificationLevel { get; set; }          //Trình độ chuyên môn kỹ thuật: Kỹ sư CNTT
        public string PayrollTypeCode { get; set; }             //Mã hình thức thanh toán: Chuyển khoản/Tiền mặt
    }
}
