﻿using ERP.Ultilities.Results;
using System;

namespace ERP.ResponeModel
{
    public class BaseResponeModel
    {
        public BaseResult Result { get; set; }
        public Object Data { get; set; }

        public BaseResponeModel()
        {
            //default result is success
            this.Result = new SuccessResult();
        }

        /// <summary>
        /// Initialize Response model
        /// </summary>
        /// <param name="Data">Data response</param>
        /// <param name="Result">Result respones, Success if null</param>
        public BaseResponeModel(Object Data, BaseResult Result = null)
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

        public BaseResponeModel setResult(BaseResult Result)
        {
            this.Result = Result;
            return this;
        }

        public BaseResponeModel setData(Object Data)
        {
            this.Data = Data;
            return this;
        }
    }
}
