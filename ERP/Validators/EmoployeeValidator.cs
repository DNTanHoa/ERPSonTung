using ERP.Model.Models;
using ERP.Repository;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmoployeeValidator : AbstractValidator<Employee>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmoployeeValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ nhân viên", 50));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tên nhân viên", 50));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.DepartmentCode).Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));
        }

        private bool IsValidDepartmentCode(string Code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Department", Code, out Category category);
        }
    }
}