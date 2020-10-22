using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Category
{
    public class CategorySaveChangeRequestModel
    {
        public string Note { get; set; }

        public string Entity { get; set; }

        public string Code { get; set; }

        public string SubCode { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }
    }
}