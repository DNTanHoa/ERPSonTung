using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Nhóm phân quyền
    /// </summary>
    public partial class RoleGroup : BaseModel
    {
        public string Code { get; set; }
        public string TextName { get; set; }
    }
}
