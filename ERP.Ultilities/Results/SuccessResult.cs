using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;

namespace ERP.Ultilities.Results
{
    public class SuccessResult : BaseResult
    {
        /// <summary>
        /// Default Result Initialial Default value
        /// ResultType = ResultType.Success
        /// ActionType = ActionType.None
        /// Message = AppGlobal.Success
        /// </summary>
        public SuccessResult()
        {
            this.ResultType = ResultType.Success;
            this.ActionType = ActionType.None;
            this.Message = AppGlobal.Success;
        }

        /// <summary>
        /// Default Result Initialial Default value
        /// Message = AppGlobal.Success
        /// ResultType = ResultType.Success;
        /// </summary>
        /// <param name="ActionType">Delete, Insert, Update, ...</param>
        public SuccessResult(ActionType ActionType)
        {
            this.ActionType = ActionType;
            this.Message = AppGlobal.Success;
            this.ResultType = ResultType.Success;
        }

        /// <summary>
        /// Result Initialial full
        /// </summary>
        /// <param name="ResultType">Success: 0 Or Error: -1</param>
        /// <param name="ActionType">Delete, Insert, Update, ...</param>
        /// <param name="Message">Action Message</param>
        public SuccessResult(ActionType ActionType, string Message)
        {
            this.ActionType = ActionType;
            this.Message = Message;
            this.ResultType = ResultType.Success;
        }
    }
}
