using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERP.MVC.Models;
using ERP.Ultilities.Global;
using ERP.Repository;
using Microsoft.AspNetCore.Http;

namespace ERP.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IUserRepository UserRepository { get; }

        public HomeController(ILogger<HomeController> logger,
                              IUserRepository userRepository)
        {
            _logger = logger;
            UserRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login(UserLoginViewModel model)
        {
            BaseResponeModel respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.LoginFailMessage);
            if (ModelState.IsValid)
            {
                if(UserRepository.IsValidUser(model.Username, model.Password))
                {
                    var cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("Username", model.Username, cookie);
                    Response.Cookies.Append("RememberPassword", model.RememberPassword.ToString(), cookie);
                    respone.SetStatus(AppGlobal.Success).SetMessage(AppGlobal.RedirectDefault);
                }
                return Json(respone);
            }
            return Json(respone);
        }
    }
}
