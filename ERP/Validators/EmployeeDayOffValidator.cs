using ERP.RequestModel.Employee;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeDayOffValidator : AbstractValidator<EmployeeDayOffRequest>
    {
        public EmployeeDayOffValidator()
        {
            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage("Mã nhân viên - Bắt buộc")
                .MinimumLength(2).WithMessage("Mã nhân viên - ít nhất 2 ký tự")
                .MaximumLength(20).WithMessage("Mã nhân viên - tối đa 20 ký tự");
        }
    }
}