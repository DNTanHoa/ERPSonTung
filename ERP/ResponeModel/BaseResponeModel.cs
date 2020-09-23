using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.ResponeModel
{
    public class BaseResponeModel
    {
        public string Message { get; set; }

        public string Status { get; set; }

        public BaseResponeModel setMessage(string message)
        {
            this.Message = message;
            return this;
        }

        public BaseResponeModel setStatus(string Status)
        {
            this.Status = Status;
            return this;
        }
    }
}
