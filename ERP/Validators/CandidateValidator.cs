using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CandidateCreateValidator : AbstractValidator<CandidateCreateRequestModel>
    {
        public CandidateCreateValidator()
        {
            
        }
    }

    public class CandidateUpdateValidator : AbstractValidator<CandidateUpdateRequestModel>
    {
        public CandidateUpdateValidator()
        {

        }
    }

    public class CandidateSaveChangeValidator : AbstractValidator<CandidateSaveChangeRequestModel>
    {
        public CandidateSaveChangeValidator()
        {

        }
    }
}