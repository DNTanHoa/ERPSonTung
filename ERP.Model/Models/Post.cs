using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Post : BaseModel
    {
        public string CategoryCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MateKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string MainContent { get; set; }
    }
}
