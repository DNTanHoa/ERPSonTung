using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public Candidate GetByCode(string code)
        {
            var currentObj = this.context.Candidate.SingleOrDefault(n=>n.Code.Equals(code));

            return currentObj;
        }
    }
}
