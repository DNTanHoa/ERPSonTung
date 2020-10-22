using ERP.Repository;
using ERP.RequestModel.EmployeeContract;
using ERP.Ultilities.Global;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Validators
{
    public class EmployeeContractCreateValidator : AbstractValidator<EmployeeContractCreateRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;

        public EmployeeContractCreateValidator(IEmployeeContractRepository employeeContractRepository)
        {
            this._employeeContractRepository = employeeContractRepository;

        }
    }

    public class EmployeeContractUpdateValidator : AbstractValidator<EmployeeContractUpdateRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;

        public EmployeeContractUpdateValidator(IEmployeeContractRepository employeeContractRepository)
        {
            this._employeeContractRepository = employeeContractRepository;


        }
    }

    public class EmployeeContractSaveChangeValidator : AbstractValidator<EmployeeContractSaveChangeRequestModel>
    {
        private readonly IEmployeeContractRepository _employeeContractRepository;

        public EmployeeContractSaveChangeValidator(IEmployeeContractRepository employeeContractRepository)
        {
            this._employeeContractRepository = employeeContractRepository;

        }
    }
}