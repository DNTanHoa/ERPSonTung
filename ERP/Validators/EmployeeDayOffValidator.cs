using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeDayOffValidator : AbstractValidator<EmployeeDayOffRequest>
    {

        private readonly ICategoryRepository _categoryRepository;

        public EmployeeDayOffValidator(ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage("Mã nhân viên - Bắt buộc")
                .MinimumLength(2).WithMessage("Mã nhân viên - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Mã nhân viên - tối đa 20 ký tự");

            RuleFor(x => x.Reason).NotEmpty().WithMessage("Lý do nghỉ - Bắt buộc")
                .MinimumLength(2).WithMessage("Lý do nghỉ - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Lý do nghỉ - tối đa 20 ký tự");

            RuleFor(x => x.Reason).Must(IsValidReasonCode).WithMessage("Lý do nghỉ không tồn tại trong danh mục");


            RuleFor(x => x.ApproveStatus).NotEmpty().WithMessage("Trạng thái duyệt - Bắt buộc")
                .MinimumLength(2).WithMessage("Trạng thái duyệt - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Trạng thái duyệt - tối đa 20 ký tự");


            RuleFor(x => x.ApproveStatus).Must(IsValidApproveCode).WithMessage("Trạng thái duyệt không tồn tại trong danh mục");

        }

        private bool IsValidReasonCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("ApproveStatus", code, out Category category);
        }

        private bool IsValidApproveCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Reason", code, out Category category);
        }
    }
}