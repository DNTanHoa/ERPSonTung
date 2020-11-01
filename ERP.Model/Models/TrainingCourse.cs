using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Khóa học
    /// </summary>
    public partial class TrainingCourse : BaseModel
    {
        public string Code { get; set; }            //Mã khóa học
        public string Name { get; set; }            //Tên khóa học
        public DateTime? StartDate { get; set; }    //Ngày bắt đầu
        public DateTime? EndDate { get; set; }      //Ngày kết thúc
        public string Location { get; set; }        //Địa điểm học
        public string Description { get; set; }     //Mô tả
        public decimal? PlannedCost { get; set; }   //Chi phí dự toán
        public decimal? RealCost { get; set; }      //Chi phí thực
        public string ParentCode { get; set; }      //Mã khóa học cha
    }
}
