using ERP.Model.Models;
using ERP.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Validators
{
    public class EmoployeeValidator : AbstractValidator<Employee> 
    {
        private readonly ICategoryRepository categoryRepository;

        public EmoployeeValidator(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Họ không được để trống");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Tên đầy đủ không được để trống");
            RuleFor(x => x.DepartmentCode).Must(IsValidDepartmentCode).WithMessage("Bộ phận không tồn tại trong danh mục");
        }

        private bool IsValidDepartmentCode(string Code)
        {
            return categoryRepository.IsExistEntityWithCode("Department", Code, out Category category);
        }
    }
}
