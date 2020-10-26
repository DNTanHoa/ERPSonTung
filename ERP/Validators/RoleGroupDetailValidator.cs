using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Role;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class RoleGroupDetailCreateValidator : AbstractValidator<RoleGroupDetailCreateRequestModel>
    {

        private readonly IRoleGroupRepository _roleGroupRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleGroupDetailCreateValidator(IRoleGroupRepository roleGroupRepository, ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;
            this._roleGroupRepository = roleGroupRepository;

            RuleFor(x => x.RoleGroupCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhóm phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhóm phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhóm phân quyền", 20))
                .Must(IsValidRoleGroupCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));
        }

        private bool IsValidRoleGroupCode(string code)
        {
            var result = this._roleGroupRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation",code,out Category category);
            return result;
        }
    }

    public class RoleGroupDetailUpdateValidator : AbstractValidator<RoleGroupDetailUpdateRequestModel>
    {
        private readonly IRoleGroupRepository _roleGroupRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleGroupDetailUpdateValidator(IRoleGroupRepository roleGroupRepository, ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
            this._roleGroupRepository = roleGroupRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThan(0).WithMessage(CommonMessageGlobal.GreaterThan("Id", 0));

            RuleFor(x => x.RoleGroupCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhóm phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhóm phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhóm phân quyền", 20))
                .Must(IsValidRoleGroupCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));
        }

        private bool IsValidRoleGroupCode(string code)
        {
            var result = this._roleGroupRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation", code, out Category category);
            return result;
        }
    }


    public class RoleGroupDetailSaveChangeValidator : AbstractValidator<RoleGroupDetailSaveChangeRequestModel>
    {
        private readonly IRoleGroupRepository _roleGroupRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RoleGroupDetailSaveChangeValidator(IRoleGroupRepository roleGroupRepository, ICategoryRepository categoryRepository)
        {

            this._categoryRepository = categoryRepository;
            this._roleGroupRepository = roleGroupRepository;

            RuleFor(x => x.Id).NotEmpty().WithMessage(CommonMessageGlobal.Require("Id"))
                .GreaterThanOrEqualTo(0).WithMessage(CommonMessageGlobal.GreaterThanOrEqual("Id", 0));

            RuleFor(x => x.RoleGroupCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhóm phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhóm phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhóm phân quyền", 20))
                .Must(IsValidRoleGroupCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã hợp đồng"));

            RuleFor(x => x.NavigationCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã phân quyền"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phân quyền", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phân quyền", 20))
                .Must(IsValidNavigationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã phân quyền"));
        }


        private bool IsValidRoleGroupCode(string code)
        {
            var result = this._roleGroupRepository.IsExistCode(code);
            return result;
        }

        private bool IsValidNavigationCode(string code)
        {
            var result = this._categoryRepository.IsExistEntityWithCode("Navigation", code, out Category category);
            return result;
        }
    }
}