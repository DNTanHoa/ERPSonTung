using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.CheckInOutDevice;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CheckInOutDeviceValidator : AbstractValidator<CheckInOutDeviceCreateRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CheckInOutDeviceValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã thiết bị"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 50));


            RuleFor(x => x.StatusCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Trạng thái", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Trạng thái", 20))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái"));
        }

        private bool IsValidStatusCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("ApproveStatus", code, out Category category);
        }

    }
}