using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Role;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class RoleCreateValidator : AbstractValidator<RoleCreateRequestModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleCreateValidator(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;

            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50))
                .Must(IsValidUsername).WithMessage(CommonMessageGlobal.NotExistInCategory("Username"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));

            RuleFor(x => x.Entity).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Entity", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Entity", 20));
        }

        private bool IsValidUsername(string code)
        {
            var result = this._userRepository.IsExistUsername(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation", code, out Category category);
            return result;
        }
    }

    public class RoleSaveChangeValidator : AbstractValidator<RoleSaveChangeRequestModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleSaveChangeValidator(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
               .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
               .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50))
                .Must(IsValidUsername).WithMessage(CommonMessageGlobal.NotExistInCategory("Username"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 256));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));

            RuleFor(x => x.Entity).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Entity", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Entity", 20));
        }

        private bool IsValidUsername(string code)
        {
            var result = this._userRepository.IsExistUsername(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation", code, out Category category);
            return result;
        }
    }

    public class RoleUpdateValidator : AbstractValidator<RoleUpdateRequestModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleUpdateValidator(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.Username).NotEmpty().WithMessage(CommonMessageGlobal.Require("Username"))
               .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Username", 2))
               .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Username", 50))
                .Must(IsValidUsername).WithMessage(CommonMessageGlobal.NotExistInCategory("Username"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));

            RuleFor(x => x.Entity).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Entity", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Entity", 20));
        }

        private bool IsValidUsername(string code)
        {
            var result = this._userRepository.IsExistUsername(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation", code, out Category category);
            return result;
        }
    }
}