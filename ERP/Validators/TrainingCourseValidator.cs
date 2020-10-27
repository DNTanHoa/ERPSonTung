using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class TrainingCourseCreateValidator : AbstractValidator<TrainingCourseCreateRequestModel>
    {
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseCreateValidator(ITrainingCourseRepository trainingCourseRepository)
        {
            this._trainingCourseRepository = trainingCourseRepository;

            RuleFor(x => x.Code).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã khóa đào tạo"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 256));

            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo cha", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo cha", 20))
                .Must(IsValidParentCode).WithMessage(CommonMessageGlobal.Invalid("Mã khóa đào tạo cha"));

        }


        private bool IsValidParentCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }
            else
            {
                var result = this._trainingCourseRepository.IsExistCode(code);
                return result;
            }

            
        }
    }

    public class TrainingCourseUpdateValidator : AbstractValidator<TrainingCourseUpdateRequestModel>
    {
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseUpdateValidator(ITrainingCourseRepository trainingCourseRepository)
        {
            this._trainingCourseRepository = trainingCourseRepository;


            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.Code).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã khóa đào tạo"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 256));

            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo cha", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo cha", 20))
                .Must(IsValidParentCode).WithMessage(CommonMessageGlobal.Invalid("Mã khóa đào tạo cha"));

        }


        private bool IsValidParentCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }
            else
            {
                var result = this._trainingCourseRepository.IsExistCode(code);
                return result;
            }


        }
    }

    public class TrainingCourseSaveChangeValidator : AbstractValidator<TrainingCourseSaveChangeRequestModel>
    {
        private readonly ITrainingCourseRepository _trainingCourseRepository;

        public TrainingCourseSaveChangeValidator(ITrainingCourseRepository trainingCourseRepository)
        {
            this._trainingCourseRepository = trainingCourseRepository;

            RuleFor(x => x.Code).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã khóa đào tạo"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo", 256));

            RuleFor(x => x.ParentCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã khóa đào tạo cha", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã khóa đào tạo cha", 20))
                .Must(IsValidParentCode).WithMessage(CommonMessageGlobal.Invalid("Mã khóa đào tạo cha"));

        }


        private bool IsValidParentCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }
            else
            {
                var result = this._trainingCourseRepository.IsExistCode(code);
                return result;
            }


        }
    }
}