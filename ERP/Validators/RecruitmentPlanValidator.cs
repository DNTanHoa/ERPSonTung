using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Validators
{
    public class RecruitmentPlanCreateValidator : AbstractValidator<RecruitmentPlanCreateRequestModel>
    {
        private readonly ICategoryRepository categoryRepository;

        private List<Category> Departments { get; set; }

        private List<Category> Jobs { get; set; }

        private List<Category> Statuses { get; set; }

        public RecruitmentPlanCreateValidator(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;

            RuleFor(x => x.Title).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tiêu đề kế hoạch tuyển dụng"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tiêu đề kế hoạch tuyển dụng", 2));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));
            
            RuleFor(x => x.JobCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Vị trí công việc"))
                .Must(IsValidJobCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Vị trí công việc"));
            
            RuleFor(x => x.Status).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái kế hoạch"))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái kế hoạch"));

            RuleFor(x => x.Quantity).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số lượng"));
        }

        private bool IsValidDepartmentCode(string code)
        {
            if(this.Departments == null) 
            {
                Departments = categoryRepository.GetByEntity("Department").ToList();
            }
            return Departments.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidJobCode(string code)
        {
            if (this.Jobs == null)
            {
                Jobs = categoryRepository.GetByEntity("Job").ToList();
            }
            return Jobs.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidStatusCode(string code)
        {
            if (this.Statuses == null)
            {
                Statuses = categoryRepository.GetByEntity("RecruitmentPlanStatus").ToList();
            }
            return Statuses.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }
    }

    public class RecruitmentPlanUpdateValidator : AbstractValidator<RecruitmentPlanUpdateRequestModel>
    {
        private readonly ICategoryRepository categoryRepository;

        private List<Category> Departments { get; set; }

        private List<Category> Jobs { get; set; }

        private List<Category> Statuses { get; set; }

        public RecruitmentPlanUpdateValidator(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;

            RuleFor(x => x.Title).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tiêu đề kế hoạch tuyển dụng"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tiêu đề kế hoạch tuyển dụng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tiêu đề kế hoạch tuyển dụng", 100));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));

            RuleFor(x => x.JobCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Vị trí công việc"))
                .Must(IsValidJobCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Vị trí công việc"));

            RuleFor(x => x.Status).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái kế hoạch"))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái kế hoạch"));

            RuleFor(x => x.Quantity).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số lượng"));
        }

        private bool IsValidDepartmentCode(string code)
        {
            if (this.Departments == null)
            {
                Departments = categoryRepository.GetByEntity("Department").ToList();
            }
            return Departments.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidJobCode(string code)
        {
            if (this.Jobs == null)
            {
                Jobs = categoryRepository.GetByEntity("Job").ToList();
            }
            return Jobs.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidStatusCode(string code)
        {
            if (this.Statuses == null)
            {
                Statuses = categoryRepository.GetByEntity("RecruitmentPlanStatus").ToList();
            }
            return Statuses.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }
    }

    public class RecruitmentPlanSaveChangeValidator : AbstractValidator<RecruitmentPlanSaveChangeRequestModel>
    {
        private readonly ICategoryRepository categoryRepository;

        private List<Category> Departments { get; set; }

        private List<Category> Jobs { get; set; }

        private List<Category> Statuses { get; set; }

        public RecruitmentPlanSaveChangeValidator(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;

            RuleFor(x => x.Title).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tiêu đề kế hoạch tuyển dụng"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tiêu đề kế hoạch tuyển dụng", 2));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));

            RuleFor(x => x.JobCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Vị trí công việc"))
                .Must(IsValidJobCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Vị trí công việc"));

            
        }

        private bool IsValidDepartmentCode(string code)
        {
            if (this.Departments == null)
            {
                Departments = categoryRepository.GetByEntity("Department").ToList();
            }
            return Departments.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidJobCode(string code)
        {
            if (this.Jobs == null)
            {
                Jobs = categoryRepository.GetByEntity("Job").ToList();
            }
            return Jobs.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }

        private bool IsValidStatusCode(string code)
        {
            if (this.Statuses == null)
            {
                Statuses = categoryRepository.GetByEntity("RecruitmentPlanStatus").ToList();
            }
            return Statuses.Where(item => item.Code.Equals(code)).FirstOrDefault() != null ? true : false;
        }
    }
}