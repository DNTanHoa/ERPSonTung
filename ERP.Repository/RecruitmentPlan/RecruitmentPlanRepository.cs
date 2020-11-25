using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class RecruitmentPlanRepository : Repository<RecruitmentPlan>, IRecruitmentPlanRepository
    {
        public RecruitmentPlanRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public List<RecruitmentPlanDataTransfer> GetDataTransfer()
        {
            var query = from recruitmentPlan in context.RecruitmentPlan
                        join job in context.Category on recruitmentPlan.JobCode equals job.Code into groupJob
                        from jobs in groupJob.DefaultIfEmpty()
                        join department in context.Category on recruitmentPlan.DepartmentCode equals department.Code into groupDepartment
                        from departments in groupDepartment.DefaultIfEmpty()
                        join status in context.Category on recruitmentPlan.Status equals status.Code into groupStatus
                        from statuses in groupStatus.DefaultIfEmpty()
                        select new RecruitmentPlanDataTransfer
                        {
                            Id = recruitmentPlan.Id,
                            CreateDate = recruitmentPlan.CreateDate,
                            CreateUser = recruitmentPlan.CreateUser,
                            UpdateDate = recruitmentPlan.UpdateDate,
                            UpdateUser = recruitmentPlan.UpdateUser,
                            Deleted = recruitmentPlan.Deleted,
                            Note = recruitmentPlan.Note,
                            Title = recruitmentPlan.Title,
                            DepartmentCode = recruitmentPlan.DepartmentCode,
                            Department = recruitmentPlan.DepartmentCode + '-' + departments.Name,
                            JobCode = recruitmentPlan.JobCode,
                            Job = recruitmentPlan.JobCode + '-' + jobs.Name,
                            Status = recruitmentPlan.Status,
                            DisplayStatus = statuses.Name,
                            Quantity = recruitmentPlan.Quantity,
                            Code = recruitmentPlan.Code,
                            StartDate = recruitmentPlan.StartDate,
                            EndDate = recruitmentPlan.EndDate
                        };
            return query.ToList();
        }

        public bool IsExistCode(string Code)
        {
            var recruitmentPlan = context.RecruitmentPlan.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return recruitmentPlan != null ? true : false;
        }
    }
}
