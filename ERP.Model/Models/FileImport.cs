using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Models
{
    /// <summary>
    /// File được import
    /// </summary>
    public class FileImport : BaseModel
    {
        public string Code { get; set; }        //Mã
        public string TextName { get; set; }    //Tên file gửi lên
        public string Path { get; set; }        //Đường dẫn
        public string SaveName { get; set; }    //Tên file được lưu lại (ví dụ thêm YYYYMMDD...)
        public string Entity { get; set; }      //Entity sử dụng
    }
}
