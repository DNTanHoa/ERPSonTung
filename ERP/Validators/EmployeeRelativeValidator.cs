using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.EmployeeRelative;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeRelativeValidator : AbstractValidator<EmployeeRelativeRequest>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmployeeRelativeValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage("Mã nhân viên - Bắt buộc")
                .MinimumLength(2).WithMessage("Mã nhân viên - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Mã nhân viên - tối đa 20 ký tự");

            RuleFor(x => x.OriginProvinceCode).NotEmpty().WithMessage("Mã tỉnh thành - Bắt buộc")
                .MinimumLength(2).WithMessage("Mã tỉnh thành - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Mã tỉnh thành - tối đa 20 ký tự");
            RuleFor(x => x.OriginProvinceCode).Must(IsValidProvinceCode).WithMessage("Mã tỉnh thành không tồn tại trong danh mục");


            RuleFor(x => x.OriginAddress).NotEmpty().WithMessage("Địa chỉ - Bắt buộc");

            RuleFor(x => x.Job).NotEmpty().WithMessage("Công việc - Bắt buộc");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Số điện thoại - Bắt buộc")
                .MinimumLength(2).WithMessage("Số điện thoại - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Số điện thoại - tối đa 20 ký tự");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Họ và tên - Bắt buộc");

            RuleFor(x => x.RelativeType).NotEmpty().WithMessage("Mã mối quan hệ - Bắt buộc")
                .MinimumLength(2).WithMessage("Mã mối quan hệ - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Mã mối quan hệ - tối đa 20 ký tự");
            RuleFor(x => x.RelativeType).Must(IsValidRelativeCode).WithMessage("Mã mối quan hệ không tồn tại trong danh mục");
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