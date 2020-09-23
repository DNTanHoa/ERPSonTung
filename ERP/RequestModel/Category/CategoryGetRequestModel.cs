using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.Category
{
    public class CategoryGetRequestModel
    {
        public string Entity { get; set; }

        public string Code { get; set; }

        public string ParentCode { get; set; }
    }
}
