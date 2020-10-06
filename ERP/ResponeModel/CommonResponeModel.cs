using ERP.Ultilities.Results;
using System;

namespace ERP.ResponeModel
{
    public class CommonResponeModel
    {
        public BaseResult Result { get; set; }
        public Object Data { get; set; }

        public CommonResponeModel()
        {
            //default result is success
            this.Result = new SuccessResult();
        }

        /// <summary>
        /// Initialize Response model
        /// </summary>
        /// <param name="Result">Result respones, Success if null</param>
        public CommonResponeModel(BaseResult Result)
        {
            BaseResult result = Result;

            if (result == null)
            {
                //default result is success
                result = new SuccessResult();
            }

            this.Result = result;
        }

        /// <summary>
        /// Initialize Response model
        /// </summary>
        /// <param name="Data">Data response</param>
        /// <param name="Result">Result respones, Success if null</param>
        public CommonResponeModel(Object Data, BaseResult Result = null)
        {
            this.Data = Data;

            BaseResult result = Result;

            if (result == null)
            {
                //default result is success
                result = new SuccessResult();
            }

            this.Result = result;
        }

        public CommonResponeModel setResult(BaseResult Result)
        {
            this.Result = Result;
            return this;
        }

        public CommonResponeModel setData(Object Data)
        {
            this.Data = Data;
            return this;
        }
    }
}
