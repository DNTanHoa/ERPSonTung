using ERP.Repository;
using ERP.RequestModel;
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