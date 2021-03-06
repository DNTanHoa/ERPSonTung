﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class ContractTypeRepository : Repository<ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var contractType = context.ContractType.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return contractType != null ? true : false;
        }
    }
}
