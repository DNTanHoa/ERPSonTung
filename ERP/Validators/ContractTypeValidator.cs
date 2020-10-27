using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class ContractTypeCreateValidator : AbstractValidator<ContractTypeCreateRequestModel>
    {
        public ContractTypeCreateValidator()
        {
            RuleFor(x => x.TextName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên loại hợp đồng"));
            RuleFor(x => x.TemplatePath).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đường dẫn "));
        }
    }

    public class ContractTypeUpdateValidator : AbstractValidator<ContractTypeUpdateRequestModel>
    {
        public ContractTypeUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.TextName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên loại hợp đồng"));
            RuleFor(x => x.TemplatePath).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đường dẫn "));
        }
    }

    public class ContractTypeSaveChangeValidator : AbstractValidator<ContractTypeSaveChangeRequestModel>
    {
        public ContractTypeSaveChangeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.TextName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên loại hợp đồng"));
            RuleFor(x => x.TemplatePath).NotEmpty().WithMessage(CommonMessageGlobal.Require("Đường dẫn "));
        }
    }
}