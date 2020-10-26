using ERP.Repository;
using ERP.RequestModel.User;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class UserLoginValidator:AbstractValidator<LoginUserRequestModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50));

            RuleFor(x => x.Password).NotEmpty().WithMessage(CommonMessageGlobal.Require("Password"))
                .MinimumLength(4).WithMessage(CommonMessageGlobal.Minimum("Password", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Password", 256));

        }
    }
    


    public class UserCreateValidator : AbstractValidator<UserCreateRequestModel>
    {

        private readonly IEmployeeRepository _employeeRepository;



        public UserCreateValidator(IEmployeeRepository employeeRepository)
        {

            this._employeeRepository = employeeRepository;



            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50));

            RuleFor(x => x.Password).NotEmpty().WithMessage(CommonMessageGlobal.Require("Password"))
                .MinimumLength(4).WithMessage(CommonMessageGlobal.Minimum("Password", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Password", 256));

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }
    }

    public class UserUpdateValidator : AbstractValidator<UserUpdateRequestModel>
    {

        private readonly IEmployeeRepository _employeeRepository;



        public UserUpdateValidator(IEmployeeRepository employeeRepository)
        {

            this._employeeRepository = employeeRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50));

            RuleFor(x => x.Password).NotEmpty().WithMessage(CommonMessageGlobal.Require("Password"))
                .MinimumLength(4).WithMessage(CommonMessageGlobal.Minimum("Password", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Password", 256));

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }
    }

}