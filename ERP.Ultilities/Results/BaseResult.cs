using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;

namespace ERP.Ultilities.Results
{
    public class BaseResult
    {
        /// <summary>
        /// Success: 0, Error: -1
        /// </summary>
        protected ResultType ResultType;

        /// <summary>
        /// None,Insert,Edit,Delete,Login
        /// </summary>
        protected ActionType ActionType;

        /// <summary>
        /// Result message
        /// </summary>
        protected string Message;
    }
}
