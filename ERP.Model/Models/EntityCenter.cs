using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Models
{
    /// <summary>
    /// Quản lí đối tượng/Đánh mã số tự động
    /// </summary>
    public class EntityCenter : BaseModel
    {
        public string Entity { get; set; }          //Tên entity
        public string PrefixCode { get; set; }      //Tiền tố mã tự động
        public string NumberCount { get; set; }     //Số mã hiện tại
    }
}
