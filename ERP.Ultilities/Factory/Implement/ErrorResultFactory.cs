using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Base;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Ultilities.Factory.Implement
{
    public class ErrorResultFactory : IResultFactory
    {
        public  BaseResult Factory(ActionType ActionType)
        {
            switch (ActionType)
            {
                case ActionType.Insert:
                    return new ErrorResult(ActionType, AppGlobal.CreateError);
                case ActionType.Edit:
                    return new ErrorResult(ActionType, AppGlobal.EditError);
                case ActionType.Delete:
                    return new ErrorResult(ActionType, AppGlobal.DeleteError);
                case ActionType.Login:
                    return new ErrorResult(ActionType, AppGlobal.LoginFailMessage);
                case ActionType.Select:
                    return new ErrorResult(ActionType, AppGlobal.Error);
                case ActionType.None:
                    return new ErrorResult(ActionType, AppGlobal.Error);
                default:
                    return new ErrorResult(ActionType, AppGlobal.Error);
            }
        }
    }
}
