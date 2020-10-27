using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface ICandidatePaperRepository : IRepository<CandidatePaper>
    {
        public bool IsExistCode(string Code);
    }
}
