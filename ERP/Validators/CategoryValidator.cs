using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Category;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class CategoryValidator : AbstractValidator<CategorySaveChangeRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id"))

            RuleFor(x => x.Entity).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã Entity"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Entity", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Entity", 20));

            RuleFor(x => x.Name).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên danh mục"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên danh mục", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Tên danh mục", 256));

            RuleFor(x => x.ParentCode).Must(IsValidParentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Danh mục cha"));
        }

        private bool IsValidParentCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode(null, code, out Category category);
        }
    }
}