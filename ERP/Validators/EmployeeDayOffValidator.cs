using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeDayOffValidator : AbstractValidator<EmployeeDayOffRequest>
    {

        private readonly ICategoryRepository _categoryRepository;

        public EmployeeDayOffValidator(ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20));

            RuleFor(x => x.Reason).NotEmpty().WithMessage(CommonMessageGlobal.Require("Lý do nghỉ"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Lý do nghỉ", 2)) 
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Lý do nghỉ", 20));

            RuleFor(x => x.Reason).Must(IsValidReasonCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Lý do nghỉ"));


            RuleFor(x => x.ApproveStatus).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái duyệt"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Trạng thái duyệt", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Trạng thái duyệt", 20));


            RuleFor(x => x.ApproveStatus).Must(IsValidApproveCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái duyệt"));

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