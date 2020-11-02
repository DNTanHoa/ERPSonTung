using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Tài liệu ứng viên
    /// </summary>
    public class CandidatePaper : BaseModel
    {
        public string CandidateCode { get; set; }   //Mã ứng viên
        public string Code { get; set; }            //Mã tài liệu
        public string TypeCode { get; set; }        //Loại tài liệu: CV
        public string TextName { get; set; }        //Tên tài liệu
        public string Path { get; set; }            //Đường dẫn file scan
    }
}
