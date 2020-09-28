using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Extensions
{
    public static class NavigationExtension
    {
        public static void InitDefault(this Navigation navigation)
        {
            if (string.IsNullOrEmpty(navigation.ParentCode))
                navigation.ParentCode = string.Empty;
        }
    }
}
