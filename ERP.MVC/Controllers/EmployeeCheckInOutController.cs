using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.MVC.Models;
using ERP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class EmployeeCheckInOutController : Controller
    {
        private readonly IEmployeeCheckInOutRepository employeeCheckInOutRepository;

        public EmployeeCheckInOutController(IEmployeeCheckInOutRepository employeeCheckInOutRepository)
        {
            this.employeeCheckInOutRepository = employeeCheckInOutRepository;
        }

        public IActionResult Index(EmployeeCheckInOutFilterModel model)
        {
            if (model == null)
                model = new EmployeeCheckInOutFilterModel();
            return View(model);
        }

        public IActionResult TimeKeeping()
        {
            return View();
        }

        public IActionResult GetTimeRangeDataTransfer(DateTime? FromDate, DateTime? ToDate)
        {
            return Json(employeeCheckInOutRepository.GetTimeRangeDataTransfer(FromDate, ToDate));
        }
    }
}
