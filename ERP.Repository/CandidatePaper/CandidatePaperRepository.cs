using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class CandidatePaperRepository : Repository<CandidatePaper>, ICandidatePaperRepository
    {
        public CandidatePaperRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var candidatePaper = context.CandidatePaper.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return candidatePaper != null ? true : false;
        }
    }
}
