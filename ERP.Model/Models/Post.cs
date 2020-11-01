using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Bài đăng tuyển dụng
    /// </summary>
    public partial class Post : BaseModel
    {
        public string CategoryCode { get; set; }        //Mã 
        public string Title { get; set; }               //Tên 
        public string SubTitle { get; set; }
        public string MateKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string MainContent { get; set; }
    }
}
