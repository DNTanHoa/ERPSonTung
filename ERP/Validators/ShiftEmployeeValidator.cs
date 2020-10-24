using ERP.RequestModel;
using FluentValidation;

namespace ERP.Validators
{
    public class ShiftEmployeeCreateValidator : AbstractValidator<ShiftEmployeeCreateRequestModel>
    {
        public ShiftEmployeeCreateValidator()
        {
        }
    }

    public class ShiftEmployeeUpdateValidator : AbstractValidator<ShiftEmployeeUpdateRequestModel>
    {
        public ShiftEmployeeUpdateValidator()
        {
        }
    }

    public class ShiftEmployeeSaveChangeValidator : AbstractValidator<ShiftEmployeeSaveChangeRequestModel>
    {
        public ShiftEmployeeSaveChangeValidator()
        {
        }
    }
}