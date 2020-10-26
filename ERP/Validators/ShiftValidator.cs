using ERP.RequestModel.Shift;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class ShiftCreateValidator : AbstractValidator<ShiftCreateRequestModel>
    {
        public ShiftCreateValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên ca làm việc", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên ca làm việc", 256));
        }
    }

    public class ShiftUpdateValidator : AbstractValidator<ShiftUpdateRequestModel>
    {
        public ShiftUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên ca làm việc", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên ca làm việc", 256));
        }
    }

    public class ShiftSaveChangeValidator : AbstractValidator<ShiftSaveChangeRequestModel>
    {
        public ShiftSaveChangeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên ca làm việc", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên ca làm việc", 256));
        }
    }
}