using ERP.RequestModel;
using FluentValidation;

namespace ERP.Validators
{
    public class TrainingCourseEmployeeCreateValidator : AbstractValidator<TrainingCourseEmployeeCreateRequestModel>
    {
        public TrainingCourseEmployeeCreateValidator()
        {
        }
    }

    public class TrainingCourseEmployeeUpdateValidator : AbstractValidator<TrainingCourseEmployeeUpdateRequestModel>
    {
        public TrainingCourseEmployeeUpdateValidator()
        {
        }
    }

    public class TrainingCourseEmployeeSaveChangeValidator : AbstractValidator<TrainingCourseEmployeeSaveChangeRequestModel>
    {
        public TrainingCourseEmployeeSaveChangeValidator()
        {
        }
    }
}