using ERP.Model.Models;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Extensions
{
    public static class UserExtension
    {
        public static void InitDefault(this User user)
        {
            if (user.GuidCode == Guid.Empty.ToString() || string.IsNullOrEmpty(user.GuidCode))
                user.GuidCode = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(user.Username))
                user.Username = user.EmployeeCode;
        }

        public static void SetPassword(this User user)
        {
            user.Password = SecurityHelper.Encrypt(user.GuidCode, user.Password);
        }
    }
}
