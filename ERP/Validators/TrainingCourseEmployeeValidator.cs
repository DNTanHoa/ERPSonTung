using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class TrainingCourseEmployeeCreateValidator : AbstractValidator<TrainingCourseEmployeeCreateRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseEmployeeCreateValidator(IEmployeeRepository employeeRepository, ITrainingCourseRepository trainingCourseRepository)
        {
            this._employeeRepository = employeeRepository;
            this._trainingCourseRepository = trainingCourseRepository;

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.TrainingCourseCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidCourseCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidCourseCode(string code)
        {
            var result = this._trainingCourseRepository.IsExistCode(code);
            return result;
        }
    }

    public class TrainingCourseEmployeeUpdateValidator : AbstractValidator<TrainingCourseEmployeeUpdateRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseEmployeeUpdateValidator(IEmployeeRepository employeeRepository, ITrainingCourseRepository trainingCourseRepository)
        {
            this._employeeRepository = employeeRepository;
            this._trainingCourseRepository = trainingCourseRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.TrainingCourseCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidCourseCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidCourseCode(string code)
        {
            var result = this._trainingCourseRepository.IsExistCode(code);
            return result;
        }
    }

    public class TrainingCourseEmployeeSaveChangeValidator : AbstractValidator<TrainingCourseEmployeeSaveChangeRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseEmployeeSaveChangeValidator(IEmployeeRepository employeeRepository, ITrainingCourseRepository trainingCourseRepository)
        {
            this._employeeRepository = employeeRepository;
            this._trainingCourseRepository = trainingCourseRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.Invalid("Mã nhân viên"));

            RuleFor(x => x.TrainingCourseCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ca làm việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ca làm việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ca làm việc", 20))
                .Must(IsValidCourseCode).WithMessage(CommonMessageGlobal.Invalid("Mã ca làm việc"));

        }

        private bool IsValidEmployeeCode(string code)
        {
            var result = this._employeeRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidCourseCode(string code)
        {
            var result = this._trainingCourseRepository.IsExistCode(code);
            return result;
        }
    }
}