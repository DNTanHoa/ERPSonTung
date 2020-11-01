using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Ứng viên
    /// </summary>
    public class Candidate : BaseModel
    {
        public string Code { get; set; }                        //mã ứng viên, khác mã nhân viên
        public string FirstName { get; set; }                   //Tên ứng viên
        public string LastName { get; set; }                    //Họ và tên đệm
        public string FullName { get; set; }                    //Tên đầy đủ
        public DateTime? DateOfBirth { get; set; }              //Ngày sinh
        public string OriginProvinceCode { get; set; }          //Tỉnh/Thành phố (thường trú)
        public string OriginDistrictCode { get; set; }          //Quận/Huyện (thường trú)
        public string OriginWardCode { get; set; }              //Phường/xã (thường trú)
        public string OriginAddtional { get; set; }             //Số nhà (thường trú)
        public string OriginAddress { get; set; }               //Địa chỉ đầy đủ (thường trú)
        public string TemporaryProvinceCode { get; set; }       //Tỉnh/Thành phố (tạm trú)
        public string TemporaryDistrictCode { get; set; }       //Quận/Huyện (tạm trú)
        public string TemporaryWardCode { get; set; }           //Phường/xã (tạm trú)
        public string TemporaryAddtional { get; set; }          //Số nhà (tạm trú)
        public string TemporaryAddress { get; set; }            //Địa chỉ đầy đủ (tạm trú)
        public string ReligionCode { get; set; }                //Mã tôn giáo
        public string IdentityNumber { get; set; }              //Số CMND
        public DateTime? IdentityLicenseDate { get; set; }      //Ngày cấp
        public string IdentityLicensePlace { get; set; }        //Nơi cấp
        public string Phone { get; set; }                       //Số điện thoại
        public string PersonalEmail { get; set; }               //Email cá nhân
        public string GenderCode { get; set; }                  //Mã giới tính
        public string RecruitmentPlanCode { get; set; }         //Mã kế hoạch tuyển dụng
    }
}
