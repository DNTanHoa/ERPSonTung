using ERP.RequestModel.Holiday;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class HolidayCreateRequestValidator : AbstractValidator<HolidayCreateRequestModel>
    {
        public HolidayCreateRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên", 256));

            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Từ ngày"));
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đến ngày"));

            RuleFor(x => x.SalaryIncreasePercent).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số tiền tăng"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Số tiền tăng", 0));
        }
    }

    public class HolidaySaveChangeRequestValidator : AbstractValidator<HolidayCreateRequestModel>
    {
        public HolidaySaveChangeRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên", 256));

            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Từ ngày"));
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đến ngày"));

            RuleFor(x => x.SalaryIncreasePercent).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số tiền tăng"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Số tiền tăng", 0));
        }
    }

    public class HolidayUpdateRequestValidator : AbstractValidator<HolidayUpdateRequestModel>
    {
        public HolidayUpdateRequestValidator()
        {

            RuleFor(x => x.SalaryIncreasePercent).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên", 256));

            RuleFor(x => x.StartDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Từ ngày"));
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đến ngày"));

            RuleFor(x => x.SalaryIncreasePercent).NotEmpty().WithMessage(CommonMessageGlobal.Require("Số tiền tăng"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Số tiền tăng", 0));
        }
    }
}