using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.MVC.Models;
using ERP.MVC.Models.Employee;
using ERP.Repository;
using ERP.Ultilities.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(long Id, bool HasLayout = false)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            var model = employee.MapTo<EmployeeDetailModel>();
            if (HasLayout)
            {
                return View(model);
            }
            else
            {
                return PartialView("~/Views/Employee/_Detail.cshtml",model);
            }
        }

        public IActionResult Contact(long Id, bool HasLayout = false)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            var model = employee.MapTo<EmployeeContactDetailModel>();
            if (HasLayout)
            {
                return View(model);
            }
            else
            {
                return PartialView("~/Views/Employee/_Contact.cshtml", model);
            }
        }

        public IActionResult GetDataTransfer()
        {
            return Json(employeeRepository.GetDataTransfer());
        }

        public IActionResult GetModelTemplates()
        {
            return Json(employeeRepository.GetModelTemplates());
        }
    }
}
