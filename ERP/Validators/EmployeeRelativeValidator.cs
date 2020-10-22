using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.EmployeeRelative;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeRelativeValidator : AbstractValidator<EmployeeRelativeRequest>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmployeeRelativeValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20));

            RuleFor(x => x.OriginProvinceCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã tỉnh thành"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tỉnh thành",2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tỉnh thành",20))
                .Must(IsValidProvinceCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã tỉnh thành"));


            RuleFor(x => x.OriginAddress).NotEmpty().WithMessage(CommonMessageGlobal.Require("Địa chỉ"));

            RuleFor(x => x.Job).NotEmpty().WithMessage(CommonMessageGlobal.Require("Công việc"));

            RuleFor(x => x.Phone).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số điện thoại"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Số điện thoại", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Số điện thoại", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên"));

            RuleFor(x => x.RelativeType).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã mối quan hệ"))
            .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã mối quan hệ", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã mối quan hệ", 20))
                .Must(IsValidRelativeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã mối quan hệ"));
        }

        private bool IsValidProvinceCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("ApproveStatus", code, out Category category);
        }

        private bool IsValidRelativeCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Reason", code, out Category category);
        }
    }
}