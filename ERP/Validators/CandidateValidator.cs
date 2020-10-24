using ERP.RequestModel;
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