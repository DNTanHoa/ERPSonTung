using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;

namespace ERP.Ultilities.Results
{
    public class BaseResult
    {
        /// <summary>
        /// Success: 0, Error: -1
        /// </summary>
        public ResultType ResultType { get; set; }

        /// <summary>
        /// None,Insert,Edit,Delete,Login
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// Result message
        /// </summary>
        public string Message { get; set; }
    }
}
