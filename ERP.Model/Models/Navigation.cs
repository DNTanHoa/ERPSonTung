using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Điều hướng chức năng
    /// </summary>
    public partial class Navigation : BaseModel
    {
        public string ControllerName { get; set; }  //Tên chức năng
        public string ActionName { get; set; }      //Tên action
        public string Type { get; set; }            //Loại: menuleft, menutop, detailview...
        public string Icon { get; set; }            //Icon
        public string DisplayName { get; set; }     //Tên hiển thị
        public string ParentCode { get; set; }      //Mã chức năng cha
        public string Code { get; set; }            //Mã navigation
        public long? SortOrder { get; set; }        //thứ tự sắp xếp
        public string ComponentPath { get; set; }   //Đường dẫn tới để navigate
        public string ComponentName { get; set; }   //Tên component
    }
}
