using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class EmployeeSaveChangeValidator : AbstractValidator<EmployeeSaveChangeRequestModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmployeeSaveChangeValidator(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ nhân viên", 20));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tên nhân viên", 20));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã bộ phận"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã bộ phận", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã bộ phận", 20))
                .Must(IsValidDepartmentCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Mã bộ phận"));

            RuleFor(x => x.ReligionCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tôn giáo", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tôn giáo", 20));

            RuleFor(x => x.GroupCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tổ nhóm", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tổ nhóm", 20));

            RuleFor(x => x.PersonalEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email cá nhân"));

            RuleFor(x => x.CompanyEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email công ty"));

            RuleFor(x => x.StatusCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Trạng thái nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Trạng thái nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Trạng thái nhân viên", 20))
                .Must(IsValidStatusCode).WithMessage(CommonMessageGlobal.NotExistInCategory("Trạng thái nhân viên"));

            RuleFor(x => x.TitleCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Danh xưng"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Danh xưng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Danh xưng", 20));


            RuleFor(x => x.GenderCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Giới tính"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Giới tính", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Giới tính", 20));

            RuleFor(x => x.PositionCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Vị trí"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Vị trí", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Vị trí", 20));

            RuleFor(x => x.BankCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Ngân hàng", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Ngân hàng", 20));

            RuleFor(x => x.JobCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Công việc"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Công việc", 2))
                .MaximumLength(10).WithMessage(CommonMessageGlobal.Maximum("Công việc", 10));

            RuleFor(x => x.LaborGroupCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Nhóm lao động"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Nhóm lao động", 2))
                .MaximumLength(10).WithMessage(CommonMessageGlobal.Maximum("Nhóm lao động", 10));
        }

        private bool IsValidDepartmentCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("Department", code, out Category category);
        }


        private bool IsValidStatusCode(string code)
        {
            return this._categoryRepository.IsExistEntityWithCode("EmployeeStatus", code, out Category category);
        }

    }


    public class EmployeeContactDetailValidator : AbstractValidator<EmployeeContactDetailRequestModel>
    {

        public EmployeeContactDetailValidator()
        {

            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã nhân viên", 20));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));

            RuleFor(x => x.TemporaryProvinceCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã tỉnh tạm trú"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tỉnh tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tỉnh tạm trú", 20));

            

            RuleFor(x => x.TemporaryDistrictCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã quận/huyện tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã quận/huyện tạm trú", 20));

            RuleFor(x => x.TemporaryWardCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phường/xã tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phường/xã tạm trú", 20));

            RuleFor(x => x.TemporaryAddress).NotEmpty().WithMessage(CommonMessageGlobal.Require("Địa chỉ tạm trú"));


            RuleFor(x => x.OriginProvinceCode).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã tỉnh thường trú"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã tỉnh thường trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã tỉnh thường trú", 20));


            RuleFor(x => x.OriginDistrictCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã quận/huyện thường trú", 2))
               .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã quận/huyện thường trú", 20));

            RuleFor(x => x.OriginWardCode).MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Mã phường/xã tạm trú", 2))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Mã phường/xã tạm trú", 20));

            RuleFor(x => x.OriginAddress).NotEmpty().WithMessage(CommonMessageGlobal.Require("Địa chỉ thường trú"));


            RuleFor(x => x.PersonalEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email cá nhân"));

            RuleFor(x => x.CompanyEmail).EmailAddress().WithMessage(CommonMessageGlobal.Invalid("Email công ty"));

            RuleFor(x => x.Phone).Matches(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$").WithMessage(CommonMessageGlobal.Invalid("Số điện thoại"));


        }

    }
}