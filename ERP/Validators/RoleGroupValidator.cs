using ERP.RequestModel.Role;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class RoleGroupCreateValidator : AbstractValidator<RoleGroupCreateRequestModel>
    {
        public RoleGroupCreateValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));
        }
    }

    public class RoleGroupUpdateValidator : AbstractValidator<RoleGroupUpdateRequestModel>
    {
        public RoleGroupUpdateValidator()
        {


            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));
        }
    }


    public class RoleGroupSaveChangeValidator : AbstractValidator<RoleGroupSaveChangeRequestModel>
    {
        public RoleGroupSaveChangeValidator()
        {

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã", 20));
        }
    }
}