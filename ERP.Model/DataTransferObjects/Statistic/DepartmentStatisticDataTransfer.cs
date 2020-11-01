using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    /// <summary>
    /// Báo cáo tình hình đi làm / nghỉ việc của từng department hàng ngày
    /// </summary>
    public class DepartmentStatisticDataTransfer
    {
        public string Name { get; set; }        //Tên department
        public decimal? Percent { get; set; }   //Phần trăm nhân viên của department/Tổng số nhân viên
        public int EmployeeCount { get; set; }  //Tổng số nhân viên của department
        public int EmployeeLeave { get; set; }  //Số nhân viên chưa checkin của department
    }
}
