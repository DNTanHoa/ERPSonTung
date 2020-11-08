using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.Ultilities.Global;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Validators
{
    public class ImportEmployeeExcelFileValidator : AbstractValidator<EmployeeImportDataTransfer>
    {
        private readonly ICategoryRepository categoryRepository;

        private List<Category> Departments { get; set; }

        public ImportEmployeeExcelFileValidator(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"));
            
            RuleFor(x => x.LastName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên nhân viên", 20))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tên nhân viên", 20));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã bộ phận", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã bộ phận", 20))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));
        }

        private bool IsValidDepartmentCode(string code)
        {
            if(this.Departments == null)
            {
                this.Departments = categoryRepository.GetByEntity("Department").ToList();
            }
            var department = this.Departments.FirstOrDefault(item => item.Code.Equals(code));
            return department != null ? true : false;
        }
    }
}