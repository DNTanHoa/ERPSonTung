using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IRecruitmentPlanRepository : IRepository<RecruitmentPlan>
    {
        public bool IsExistCode(string Code);

        public List<RecruitmentPlanDataTransfer> GetDataTransfer();
    }
}
