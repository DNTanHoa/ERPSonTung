using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardOverviewDataTransfer();
            return View(model);
        }
    }
}
