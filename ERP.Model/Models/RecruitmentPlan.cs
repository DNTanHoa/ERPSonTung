using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Kế hoạch tuyển dụng
    /// </summary>
    public partial class RecruitmentPlan : BaseModel
    {
        public string Code { get; set; }            //Mã kế hoạch
        public string Title { get; set; }           //Tiêu đề/Tên kế hoạch
        public decimal? Quantity { get; set; }      //Số lượng
        public string JobCode { get; set; }         //Tên công việc tuyển dụng
        public string DepartmentCode { get; set; }  //Phòng ban
        public DateTime? StartDate { get; set; }    //Ngày bắt đầu tuyển dụng
        public DateTime? EndDate { get; set; }      //Ngày kết thúc tuyển dụng
        public string Status { get; set; }          //Trạng thái: Lên kế hoạch, đăng tin, tạm hoãn, hủy bỏ...
        public string Description { get; set; }     //Yêu cầu công việc
    }
}
