using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CandidatePaperCreateValidator : AbstractValidator<CandidatePaperCreateRequestModel>
    {
        public CandidatePaperCreateValidator()
        {
            
        }
    }

    public class CandidatePaperUpdateValidator : AbstractValidator<CandidatePaperUpdateRequestModel>
    {
        public CandidatePaperUpdateValidator()
        {

        }
    }

    public class CandidatePaperSaveChangeValidator : AbstractValidator<CandidatePaperSaveChangeRequestModel>
    {
        public CandidatePaperSaveChangeValidator()
        {

        }
    }
}