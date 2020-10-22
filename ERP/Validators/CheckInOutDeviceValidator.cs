using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.CheckInOutDevice;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CheckInOutDeviceCreateValidator : AbstractValidator<CheckInOutDeviceCreateRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CheckInOutDeviceCreateValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã thiết bị"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã thiết bị", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Mã thiết bị", 50));


            RuleFor(x => x.StatusCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Trạng thái", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Trạng thái", 20))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái"));
        }

        private bool IsValidStatusCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("CheckInOutDeviceStatus", code, out Category category);
        }

    }

    public class CheckInOutDeviceSaveChangeValidator : AbstractValidator<CheckInOutDeviceSaveChangeRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CheckInOutDeviceSaveChangeValidator(ICategoryRepository categoryRepository)
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
            return this._categoryRepository.IsExistEntityWithCode("CheckInOutDeviceStatus", code, out Category category);
        }

    }

    public class CheckInOutDeviceUpdateValidator : AbstractValidator<CheckInOutDeviceUpdateRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CheckInOutDeviceUpdateValidator(ICategoryRepository categoryRepository)
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
            return this._categoryRepository.IsExistEntityWithCode("CheckInOutDeviceStatus", code, out Category category);
        }

    }
}