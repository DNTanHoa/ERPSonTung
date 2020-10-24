using ERP.Repository;
using ERP.RequestModel.EmployeeContract;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeContractCreateValidator : AbstractValidator<EmployeeContractCreateRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeContractCreateValidator(IEmployeeContractRepository employeeContractRepository,
            IEmployeeRepository employeeRepository)
        {
            this._employeeContractRepository = employeeContractRepository;
            this._employeeRepository = employeeRepository;

            RuleFor(x => x.SignDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày ký"));
            RuleFor(x => x.EffectiveDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày hiệu lực"));

            RuleFor(x => x.CompanySignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký công ty"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký công ty", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký công ty", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký công ty"));

            RuleFor(x => x.EmployeeSignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký người lao động"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký người lao động", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký người lao động", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký người lao động"));


            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã hợp đồng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã hợp đồng", 20))
                .Must(IsValidNumberCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));


        }

        private bool IsValidEmployeeCode(string code)
        {
            return this._employeeRepository.IsExistCode(code);
        }

        private bool IsValidNumberCode(string code)
        {
            var obj = this._employeeContractRepository.GetByCode(code);

            return obj == null ? false : true;

        }
    }

    public class EmployeeContractUpdateValidator : AbstractValidator<EmployeeContractUpdateRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeContractUpdateValidator(IEmployeeContractRepository employeeContractRepository,
            IEmployeeRepository employeeRepository)
        {
            this._employeeContractRepository = employeeContractRepository;
            this._employeeRepository = employeeRepository;

            RuleFor(x => x.SignDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày ký"));
            RuleFor(x => x.EffectiveDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày hiệu lực"));

            RuleFor(x => x.CompanySignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký công ty"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký công ty", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký công ty", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký công ty"));

            RuleFor(x => x.EmployeeSignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký người lao động"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký người lao động", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký người lao động", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký người lao động"));


            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã hợp đồng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã hợp đồng", 20))
                .Must(IsValidNumberCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));


        }

        private bool IsValidEmployeeCode(string code)
        {
            return this._employeeRepository.IsExistCode(code);
        }

        private bool IsValidNumberCode(string code)
        {


            if (!string.IsNullOrEmpty(code))
            {

                var obj = this._employeeContractRepository.GetByCode(code);

                return obj == null ? false : true;

            }
            else
            {
                return true;
            }

        }
    }

    public class EmployeeContractSaveChangeValidator : AbstractValidator<EmployeeContractSaveChangeRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeContractSaveChangeValidator(IEmployeeContractRepository employeeContractRepository,
            IEmployeeRepository employeeRepository)
        {
            this._employeeContractRepository = employeeContractRepository;
            this._employeeRepository = employeeRepository;

            RuleFor(x => x.SignDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày ký"));
            RuleFor(x => x.EffectiveDate).NotEmpty().WithMessage(CommonMessageGlobal.Require("Ngày hiệu lực"));

            RuleFor(x => x.CompanySignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký công ty"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký công ty", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký công ty", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký công ty"));

            RuleFor(x => x.EmployeeSignPerson).NotEmpty().WithMessage(CommonMessageGlobal.Require("Chữ ký người lao động"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Chữ ký người lao động", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Chữ ký người lao động", 20))
                .Must(IsValidEmployeeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Chữ ký người lao động"));


            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã hợp đồng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã hợp đồng", 20))
                .Must(IsValidNumberCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));


        }

        private bool IsValidEmployeeCode(string code)
        {
            return this._employeeRepository.IsExistCode(code);
        }

        private bool IsValidNumberCode(string code)
        {
            var obj = this._employeeContractRepository.GetByCode(code);

            return obj == null ? false : true;

        }
    }
}