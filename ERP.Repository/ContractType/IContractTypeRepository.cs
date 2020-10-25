using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IContractTypeRepository : IRepository<ContractType>
    {
        public bool IsExistCode(string Code);
    }
}
