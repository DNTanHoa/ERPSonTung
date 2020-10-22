using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeSaveChangeRequestValidator : AbstractValidator<EmployeeSaveChangeRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmployeeSaveChangeRequestValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ nhân viên", 20));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tên nhân viên", 50));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tôn giáo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tôn giáo", 20))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));

            RuleFor(x => x.ReligionCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tôn giáo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tôn giáo", 20))
                .Must(IsValidReligionCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã tôn giáo"));

            RuleFor(x => x.GroupCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tổ nhóm", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tổ nhóm", 20))
                .Must(IsValidGroupCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã tổ nhóm"));

            RuleFor(x => x.NationCode).Must(IsValidNationCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã quốc gia"));

            RuleFor(x => x.NationalityCode).Must(IsValidNationalityCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã dân tộc"));

            RuleFor(x => x.PersonalEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email cá nhân"));

            RuleFor(x => x.CompanyEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email công ty"));

            RuleFor(x => x.StatusCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Trạng thái nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Trạng thái nhân viên", 20))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái nhân viên"));

            RuleFor(x => x.TitleCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Danh xưng"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Danh xưng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Danh xưng", 20))
                .Must(IsValidTitleCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Danh xưng"));


            RuleFor(x => x.GenderCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Giới tính"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Giới tính", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Giới tính", 20))
                .Must(IsValidGenderCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Giới tính"));

            RuleFor(x => x.PositionCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Vị trí"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Vị trí", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Vị trí", 20))
                .Must(IsValidPositionCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Vị trí"));

            RuleFor(x => x.BankCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Ngân hàng", 2))
                .MaximumLength(50).WithMessage(CommonMessageGlobal.Maximum("Ngân hàng", 50))
                .Must(IsValidBankCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Ngân hàng"));

            RuleFor(x => x.JobCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Công việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Công việc", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Công việc", 20))
                .Must(IsValidJobCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Công việc"));

            RuleFor(x => x.LaborGroupCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Nhóm lao động"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Nhóm lao động", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Nhóm lao động", 20))
                .Must(IsValidLaborGroupCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Nhóm lao động"));
        }

        private bool IsValidDepartmentCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Department", code, out Category category);
        }

        private bool IsValidReligionCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Religion", code, out Category category);
        }

        private bool IsValidGroupCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Group", code, out Category category);
        }

        private bool IsValidNationCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Nation", code, out Category category);
        }

        private bool IsValidNationalityCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Nationality", code, out Category category);
        }

        private bool IsValidStatusCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("EmployeeStatus", code, out Category category);
        }

        private bool IsValidTitleCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Title", code, out Category category);
        }

        private bool IsValidGenderCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Gender", code, out Category category);
        }

        private bool IsValidPositionCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Gender", code, out Category category);
        }

        private bool IsValidBankCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Gender", code, out Category category);
        }

        private bool IsValidJobCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Gender", code, out Category category);
        }

        private bool IsValidLaborGroupCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Gender", code, out Category category);
        }


    }
}