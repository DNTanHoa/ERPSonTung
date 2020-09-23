using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Post
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string CategoryCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MateKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string MainContent { get; set; }
    }
}
