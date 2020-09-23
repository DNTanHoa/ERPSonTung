using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.Category
{
    public class CategorySaveChangeRequestModel
    {
        public string Note { get; set; }

        [Required(ErrorMessage = "Entity không được để trống")]
        public string Entity { get; set; }

        public string Code { get; set; }
        
        public string SubCode { get; set; }

        [Required(ErrorMessage = "Name không được để trống")]
        public string Name { get; set; }
        
        public string ParentCode { get; set; }
    }
}
