using ERP.Ultilities.Enum;
using ERP.Ultilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Ultilities.Factory.Base
{
    public interface IResultFactory
    {
        public BaseResult Factory(ActionType ActionType);
    }
}
