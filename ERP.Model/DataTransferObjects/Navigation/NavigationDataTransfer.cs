using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class NavigationDataTransfer : Navigation
    {
        public string TypeName { get; set; }

        public CategoryModelTemplate cbxMenuType { get; set; }
    }
}
