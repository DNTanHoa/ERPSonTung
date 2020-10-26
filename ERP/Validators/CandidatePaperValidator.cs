using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CandidatePaperCreateValidator : AbstractValidator<CandidatePaperCreateRequestModel>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandidatePaperCreateValidator(ICandidateRepository candidateRepository, ICategoryRepository categoryRepository)
        {
            this._candidateRepository = candidateRepository;
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.CandidateCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ứng viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ứng viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ứng viên", 20))
                .Must(IsValidCandidateCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã ứng viên"));

            RuleFor(x => x.TypeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Loại giấy tờ"))
               .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Loại giấy tờ", 2))
               .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Loại giấy tờ", 20))
               .Must(IsValidTypeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Loại giấy tờ"));
        }

        private bool IsValidCandidateCode(string code)
        {
            var obj= this._candidateRepository.GetByCode(code);
            return obj == null ? false : true;
        }

        private bool IsValidTypeCode(string code)
        {
            var obj = this._categoryRepository.IsExistEntityWithCode("CandidatePaperType",code,out Category category);
            return obj;
        }

    }

    public class CandidatePaperUpdateValidator : AbstractValidator<CandidatePaperUpdateRequestModel>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandidatePaperUpdateValidator(ICandidateRepository candidateRepository, ICategoryRepository categoryRepository)
        {
            this._candidateRepository = candidateRepository;
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ứng viên"))
                .GreaterThan(1).WithMessage(CommonMessageGlobal.GreaterThan("Id",1));

            RuleFor(x => x.CandidateCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ứng viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ứng viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ứng viên", 20))
                .Must(IsValidCandidateCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã ứng viên"));

            RuleFor(x => x.TypeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Loại giấy tờ"))
               .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Loại giấy tờ", 2))
               .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Loại giấy tờ", 20))
               .Must(IsValidTypeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Loại giấy tờ"));
        }

        private bool IsValidCandidateCode(string code)
        {
            var obj = this._candidateRepository.GetByCode(code);
            return obj == null ? false : true;
        }

        private bool IsValidTypeCode(string code)
        {
            var obj = this._categoryRepository.IsExistEntityWithCode("CandidatePaperType", code, out Category category);
            return obj;
        }
    }

    public class CandidatePaperSaveChangeValidator : AbstractValidator<CandidatePaperSaveChangeRequestModel>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandidatePaperSaveChangeValidator(ICandidateRepository candidateRepository, ICategoryRepository categoryRepository)
        {
            this._candidateRepository = candidateRepository;
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ứng viên"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.CandidateCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã ứng viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã ứng viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã ứng viên", 20))
                .Must(IsValidCandidateCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã ứng viên"));

            RuleFor(x => x.TypeCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Loại giấy tờ"))
               .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Loại giấy tờ", 2))
               .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Loại giấy tờ", 20))
               .Must(IsValidTypeCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Loại giấy tờ"));
        }

        private bool IsValidCandidateCode(string code)
        {
            var obj = this._candidateRepository.GetByCode(code);
            return obj == null ? false : true;
        }

        private bool IsValidTypeCode(string code)
        {
            var obj = this._categoryRepository.IsExistEntityWithCode("CandidatePaperType", code, out Category category);
            return obj;
        }
    }
}