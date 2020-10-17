﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.RequestModel.Role
{
    public class RoleGroupSaveChangeRequestModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Mã nhóm phân quyền không được để trống")]
        public string Code { get; set; }
        public string TextName { get; set; }
    }
}
