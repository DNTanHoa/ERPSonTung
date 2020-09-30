using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.MVC.Models.Category;
using ERP.Repository;
using ERP.Ultilities.Global;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddressBuild(AddressBuildViewModel model)
        {
            if(model == null)
                model = new AddressBuildViewModel();
            return PartialView("~/Views/Category/_AddressBuild.cshtml", model);
        }

        public IActionResult GetAll()
        {
            return Json(categoryRepository.Get());
        }

        public IActionResult GetSavedEntityType()
        {
            return Json(categoryRepository.GetSavedEntityType());
        }

        public IActionResult GetByEntity(string Entity)
        {
            if (string.IsNullOrEmpty(Entity))
            {
                return Json(categoryRepository.Get());
            }
            else
            {
                return Json(categoryRepository.GetByEntity(Entity));
            }
        }
        
        public IActionResult GetByEntityHasDataSourceRequest([DataSourceRequest] DataSourceRequest request, string Entity)
        {
            if (string.IsNullOrEmpty(Entity))
            {
                return Json(categoryRepository.Get().ToDataSourceResult(request));
            }
            else
            {
                return Json(categoryRepository.GetByEntity(Entity).ToDataSourceResult(request));
            }
        }

        public IActionResult GetModelTemplateByEntity(string Entity)
        {
            return Json(categoryRepository.GetModelTemplateByEntity(Entity));
        }

        public IActionResult GetModelTemplateByEntityAndParentCode(string Entity, string ParentCode = "")
        {
            if (string.IsNullOrEmpty(ParentCode))
                ParentCode = string.Empty;
            return Json(categoryRepository.GetModelTemplateByEntityAndParentCode(Entity, ParentCode));
        }

        public IActionResult GetRecursiveByEntity(string Entity = "")
        {
            return Json(categoryRepository.GetRecursiveByEntity(Entity));
        }

        public IActionResult GetRecursiveByEntityHasDataSourceRequest([DataSourceRequest] DataSourceRequest request, string Entity = "")
        {
            return Json(categoryRepository.GetRecursiveByEntity(Entity).ToDataSourceResult(request));
        }

        public IActionResult GetByParentCode(string ParentCode)
        {
            return Json(categoryRepository.GetByParentCode(ParentCode));
        }

        public IActionResult Department()
        {
            ViewData["Title"] = "Bộ phận";
            ViewData["Entity"] = AppGlobal.DepartmentCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult Group()
        {
            ViewData["Title"] = "Phòng ban";
            ViewData["Entity"] = AppGlobal.GroupCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult LaborGroup()
        {
            ViewData["Title"] = "Nhóm lao động";
            ViewData["Entity"] = AppGlobal.LaborGroupCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult Job()
        {
            ViewData["Title"] = "Chức danh nghề nghiệp";
            ViewData["Entity"] = AppGlobal.JobCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult Position()
        {
            ViewData["Title"] = "Chức vụ";
            ViewData["Entity"] = AppGlobal.PositionCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult Bank()
        {
            ViewData["Title"] = "Ngân hàng";
            ViewData["Entity"] = AppGlobal.BankCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult School()
        {
            ViewData["Title"] = "Trường học";
            ViewData["Entity"] = AppGlobal.SchoolCode;
            return View("~/Views/Category/Distinct.cshtml");
        }

        public IActionResult Address()
        {
            ViewData["Title"] = "Tỉnh, huyện, xã";
            ViewData["Entity"] = AppGlobal.ProvinceCode;
            return View("~/Views/Category/Group.cshtml");
        }

        public IActionResult Nation()
        {
            ViewData["Title"] = "Quốc gia - Dân tộc";
            ViewData["Entity"] = AppGlobal.NationCode;
            return View("~/Views/Category/Group.cshtml");
        }
    }
}
