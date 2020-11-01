using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Map giữa nhân viên và khóa học
    /// </summary>
    public partial class TrainingCourseEmployee : BaseModel
    {
        public string TrainingCourseCode { get; set; }  //Mã khóa học
        public string EmployeeCode { get; set; }        //Mã nhân viên
        public string ResultType { get; set; }          //Kết quả: Tốt/khá...
        public string Point { get; set; }               //Điểm
    }
}
