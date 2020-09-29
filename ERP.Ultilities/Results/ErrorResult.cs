using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;

namespace ERP.Ultilities.Results
{
    public class ErrorResult : BaseResult
    {
        /// <summary>
        /// Default Result Initialial Default value
        /// ResultType = ResultType.Error
        /// ActionType = ActionType.None
        /// Message = AppGlobal.Error
        /// </summary>
        public ErrorResult()
        {
            this.ActionType = ActionType.None;
            this.Message = AppGlobal.Error;
            this.ResultType = ResultType.Error;
        }

        /// <summary>
        /// Default Result Initialial Default value
        /// ResultType = ResultType.Error
        /// Message = AppGlobal.Error
        /// </summary>
        /// <param name="ActionType">Delete, Insert, Update, ...</param>
        public ErrorResult(ActionType ActionType)
        {
            this.ActionType = ActionType;
            this.ResultType = ResultType.Error;
            this.Message = AppGlobal.Error;
        }

        /// <summary>
        /// Result Initialial full
        /// </summary>
        /// <param name="ActionType">Delete, Insert, Update, ...</param>
        /// <param name="Message">Action Message</param>
        public ErrorResult(ActionType ActionType, string Message)
        {
            this.ActionType = ActionType;
            this.Message = Message;
            this.ResultType = ResultType.Error;
        }
    }
}
