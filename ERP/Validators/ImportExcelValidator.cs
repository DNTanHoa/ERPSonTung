using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.Ultilities.Global;
using FluentValidation;

namespace ERP.Validators
{
    public class ImportEmployeeExcelFileValidator : AbstractValidator<EmployeeImportDataTransfer>
    {
        public ImportEmployeeExcelFileValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage(CommonMessageGlobal.Require("Mã nhân viên"));
            
            RuleFor(x => x.LastName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Tên nhân viên", 20))
                .MaximumLength(20).WithMessage(CommonMessageGlobal.Maximum("Tên nhân viên", 20));

            RuleFor(x => x.FullName).NotEmpty().WithMessage(CommonMessageGlobal.Require("Họ và tên nhân viên"))
                .MinimumLength(2).WithMessage(CommonMessageGlobal.Minimum("Họ và tên nhân viên", 2))
                .MaximumLength(256).WithMessage(CommonMessageGlobal.Maximum("Họ và tên nhân viên", 256));
        }
    }
}