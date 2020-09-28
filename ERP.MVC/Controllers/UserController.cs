using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.MVC.Models;
using ERP.Repository;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Global;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HeaderInfor()
        {
            var model = userRepository.GetDataTransferByUsername(RequestUsername);
            return PartialView("~/Views/User/_HeaderInfor.cshtml", model);
        }

        public IActionResult GetDataTransfers()
        {
            return Json(userRepository.GetDataTransfers());
        }

        public IActionResult Create(User model)
        {
            BaseResponeModel respone;
            
            model.InitBeforeSave(RequestUsername, InitType.Create);
            model.InitDefault();
            model.SetPassword();
            
            if(userRepository.IsExistUsername(model.Username))
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage("Tài khoản đã được sử dụng");
                return Json(respone);
            }  
            
            int result = userRepository.Insert(model);
            
            if (result > 0)
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Success).SetMessage(AppGlobal.CreateError);
                return Json(respone);
            }
            
            respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.CreateError);
            return Json(respone);
        }

        public IActionResult Update(User model)
        {
            BaseResponeModel respone;
            model.InitBeforeSave(RequestUsername, InitType.Update);
            model.InitDefault();
            model.SetPassword();
            int result = userRepository.Update(model);
            if (result > 0)
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Success).SetMessage(AppGlobal.EditSuccess);
                return Json(respone);
            }
            respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.EditError);
            return Json(respone);
        }

        public IActionResult SideBarInfor()
        {
            var greeting = string.Empty;
            if (DateTime.Now.Hour < 11)
            {
                greeting = AppGlobal.Morning + RequestUsername;
            }
            else if (DateTime.Now.Hour < 15)
            {
                greeting = AppGlobal.Afternoon + RequestUsername;
            }
            else if (DateTime.Now.Hour < 19)
            {
                greeting = AppGlobal.Evenning + RequestUsername;
            }
            else
            {
                greeting = AppGlobal.Night + RequestUsername;
            }
            ViewData["Greeting"] = greeting;
            return PartialView("~/Views/User/_SideBarInfor.cshtml");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("Username");
            return RedirectToAction("Index", "Home");
        }
    }
}
