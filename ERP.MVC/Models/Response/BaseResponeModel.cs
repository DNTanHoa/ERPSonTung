using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MVC.Models
{
    public class BaseResponeModel
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public BaseResponeModel SetStatus(string Status)
        {
            this.Status = Status;
            return this;
        }

        public BaseResponeModel SetMessage(string Message)
        {
            this.Message = Message;
            return this;
        }
    }
}
