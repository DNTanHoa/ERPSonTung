using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;

namespace ERP.Ultilities.Results
{
    public class ErrorResult : BaseResult
    {
        public ErrorType ErrorType;

        /// <summary>
        /// Initialize ErrorResult
        /// </summary>
        /// <param name="ErrorType">Error type is defined in enum ErrorType</param>
        /// <param name="Message">Message error, default is message in AppGlobal.Error</param>
        public ErrorResult(ErrorType ErrorType, string Message = null)
        { 
            //message is empty
            if (string.IsNullOrWhiteSpace(Message))
                Message = AppGlobal.Error;

            base.Message = Message;
            base.ResultType = ResultType.Error;

            this.ErrorType = ErrorType;
        }
    }
}
