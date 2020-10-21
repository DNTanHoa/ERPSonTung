﻿using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class CheckInOutDevice : BaseModel
    {
        public string Code { get; set; }
        public string TextName { get; set; }
        public string ConnectionTypeCode { get; set; }
        public string IPAddress { get; set; }
        public int? Port { get; set; }
        public string COM { get; set; }
        public decimal? TransferSpeed { get; set; }
        public string Website { get; set; }
        public string StatusCode { get; set; }
        public string Serial { get; set; }
        public string RegisterNumber { get; set; }
    }
}
