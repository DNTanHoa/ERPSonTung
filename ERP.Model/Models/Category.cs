using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Phân loại chung toàn hệ thống
    /// </summary>
    public class Category : BaseModel
    {
        public string Entity { get; set; }          //Tên Entity
        public string Code { get; set; }            //Mã phân loại
        public string SubCode { get; set; }         //Mã phân loại phụ
        public string Name { get; set; }            //Tên phân loại
        public string ParentCode { get; set; }      //Phân loại cha
    }
}
