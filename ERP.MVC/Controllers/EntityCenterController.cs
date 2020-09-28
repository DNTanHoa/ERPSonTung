using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class EntityCenterController : Controller
    {
        public EntityCenterController()
        {
                
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
