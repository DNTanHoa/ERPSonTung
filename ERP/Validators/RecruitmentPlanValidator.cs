using ERP.RequestModel;
using FluentValidation;

namespace ERP.Validators
{
    public class RecruitmentPlanCreateValidator : AbstractValidator<RecruitmentPlanCreateRequestModel>
    {
        public RecruitmentPlanCreateValidator()
        {
        }
    }

    public class RecruitmentPlanUpdateValidator : AbstractValidator<RecruitmentPlanUpdateRequestModel>
    {
        public RecruitmentPlanUpdateValidator()
        {
        }
    }

    public class RecruitmentPlanSaveChangeValidator : AbstractValidator<RecruitmentPlanSaveChangeRequestModel>
    {
        public RecruitmentPlanSaveChangeValidator()
        {
        }
    }
}