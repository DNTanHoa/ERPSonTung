using ERP.RequestModel;
using FluentValidation;

namespace ERP.Validators
{
    public class TrainingCourseCreateValidator : AbstractValidator<TrainingCourseCreateRequestModel>
    {
        public TrainingCourseCreateValidator()
        {
        }
    }

    public class TrainingCourseUpdateValidator : AbstractValidator<TrainingCourseUpdateRequestModel>
    {
        public TrainingCourseUpdateValidator()
        {
        }
    }

    public class TrainingCourseSaveChangeValidator : AbstractValidator<TrainingCourseSaveChangeRequestModel>
    {
        public TrainingCourseSaveChangeValidator()
        {
        }
    }
}