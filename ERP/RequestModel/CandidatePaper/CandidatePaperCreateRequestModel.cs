﻿using System;
using System.Collections.Generic;

namespace ERP.RequestModel
{
    public class CandidatePaperCreateRequestModel
    {
        public string CandidateCode { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string TextName { get; set; }
        public string Path { get; set; }
    }
}
