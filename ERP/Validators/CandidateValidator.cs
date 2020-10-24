using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CandidateCreateValidator : AbstractValidator<CandidateCreateRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CandidateCreateValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.TemporaryProvinceCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã tỉnh tạm trú"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tỉnh tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tỉnh tạm trú", 20));

            RuleFor(x => x.TemporaryDistrictCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã quận/huyện tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã quận/huyện tạm trú", 20));

            RuleFor(x => x.TemporaryWardCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phường/xã tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phường/xã tạm trú", 20));

            RuleFor(x => x.TemporaryAddress).NotEmpty().WithMessage(CommonMessageGlobal.Require("Địa chỉ tạm trú"));


            RuleFor(x => x.OriginProvinceCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã tỉnh thường trú"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tỉnh thường trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tỉnh thường trú", 20));


            RuleFor(x => x.OriginDistrictCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã quận/huyện thường trú", 2))
               .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã quận/huyện thường trú", 20));

            RuleFor(x => x.OriginWardCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phường/xã tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phường/xã tạm trú", 20));

            RuleFor(x => x.OriginAddress).NotEmpty().WithMessage(CommonMessageGlobal.Require("Địa chỉ thường trú"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Địa chỉ thường trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Địa chỉ thường trú", 20));;

            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage(CommonMessageGlobal.Require("CMND"));

            RuleFor(x => x.PersonalEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email cá nhân"));

            RuleFor(x => x.Phone).Matches(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$").WithMessage(CommonMessageGlobal.Invalid("Số điện thoại"));


        }
    }

    public class CandidateUpdateValidator : AbstractValidator<CandidateUpdateRequestModel>
    {
        public CandidateUpdateValidator()
        {
        }
    }

    public class CandidateSaveChangeValidator : AbstractValidator<CandidateSaveChangeRequestModel>
    {
        public CandidateSaveChangeValidator()
        {
        }
    }
}