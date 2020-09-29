using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Base;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using System;

namespace ERP.Ultilities.Factory.Implement
{
    public class SuccessResultFactory : IResultFactory
    {
        public BaseResult Factory(ActionType ActionType)
        {
            switch (ActionType)
            {
                case ActionType.Insert:
                    return new SuccessResult(ActionType, AppGlobal.CreateSucess);
                case ActionType.Edit:
                    return new SuccessResult(ActionType, AppGlobal.EditSuccess);
                case ActionType.Delete:
                    return new SuccessResult(ActionType, AppGlobal.DeleteSuccess);
                case ActionType.Login:
                    return new SuccessResult(ActionType, AppGlobal.Success);
                case ActionType.None:
                    return new SuccessResult(ActionType, AppGlobal.Success);
                default:
                    return new SuccessResult(ActionType, AppGlobal.Success);
            }
        }
    }
}
