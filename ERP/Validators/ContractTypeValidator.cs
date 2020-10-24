using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class ContractTypeCreateValidator : AbstractValidator<ContractTypeCreateRequestModel>
    {
        public ContractTypeCreateValidator()
        {
            
        }
    }

    public class ContractTypeUpdateValidator : AbstractValidator<ContractTypeUpdateRequestModel>
    {
        public ContractTypeUpdateValidator()
        {

        }
    }

    public class ContractTypeSaveChangeValidator : AbstractValidator<ContractTypeSaveChangeRequestModel>
    {
        public ContractTypeSaveChangeValidator()
        {

        }
    }
}