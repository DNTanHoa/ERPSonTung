using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class ShiftEmployeeCreateValidator : AbstractValidator<ShiftEmployeeCreateRequestModel>
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShiftRepository _shiftRepository;

        public ShiftEmployeeCreateValidator(IEmployeeRepository employeeRepository, IShiftRepository shiftRepository)
        {
            this._employeeRepository = employeeRepository;
            this._shiftRepository = shiftRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.ShiftCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidShiftCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidShiftCode(string code)
        {
            var result = this._shiftRepository.IsExistCode(code);
            return result;
        }
    }

    public class ShiftEmployeeUpdateValidator : AbstractValidator<ShiftEmployeeUpdateRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShiftRepository _shiftRepository;

        public ShiftEmployeeUpdateValidator(IEmployeeRepository employeeRepository, IShiftRepository shiftRepository)
        {
            this._employeeRepository = employeeRepository;
            this._shiftRepository = shiftRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.ShiftCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidShiftCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));
        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidShiftCode(string code)
        {
            var result = this._shiftRepository.IsExistCode(code);
            return result;
        }
    }

    public class ShiftEmployeeSaveChangeValidator : AbstractValidator<ShiftEmployeeSaveChangeRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShiftRepository _shiftRepository;

        public ShiftEmployeeSaveChangeValidator(IEmployeeRepository employeeRepository, IShiftRepository shiftRepository)
        {
            this._employeeRepository = employeeRepository;
            this._shiftRepository = shiftRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.ShiftCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidShiftCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));
        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidShiftCode(string code)
        {
            var result = this._shiftRepository.IsExistCode(code);
            return result;
        }
    }
}