using ERP.Model.Models;
using ERP.Ultilities.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERP.Model.Extensions
{
    public static class BaseModelExtension
    {
        public static void InitBeforeSave(this BaseModel model, string initUser, InitType type)
        {
            if(type == InitType.Create)
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = initUser;
            }
            model.UpdateDate = DateTime.Now;
            model.UpdateUser = initUser;
        }
    }
}
