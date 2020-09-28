using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.MVC.Models;
using ERP.Repository;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ERP.MVC.Controllers
{
    public class NavigationController : BaseController
    {
        private readonly INavigationRepository navigationRepository;
        private readonly IEntityCenterRepository entityCenterRepository;

        public NavigationController(INavigationRepository navigationRepository,
                                    IEntityCenterRepository entityCenterRepository)
        {
            this.navigationRepository = navigationRepository;
            this.entityCenterRepository = entityCenterRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            return Json(navigationRepository.Get());
        }

        public IActionResult GetDataTransfers()
        {
            return Json(navigationRepository.GetDataTransfers());
        }

        public IActionResult Create(Navigation model)
        {
            BaseResponeModel respone;

            string code = entityCenterRepository.GetCodeByEntity(nameof(Navigation));

            if(!string.IsNullOrEmpty(code))
            {
                model.Code = code;
                model.InitBeforeSave(RequestUsername, InitType.Create);
                model.InitDefault();
                int result = navigationRepository.Insert(model);
                if (result > 0)
                {
                    respone = new BaseResponeModel().SetStatus(AppGlobal.Success).SetMessage(AppGlobal.CreateSucess);
                }
            }
            respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.CreateError);
            return Json(respone);
        }   
        
        public IActionResult Update(Navigation model)
        {
            BaseResponeModel respone;
            model.InitBeforeSave(RequestUsername, InitType.Update);
            model.InitDefault();
            int result = navigationRepository.Update(model);
            if (result > 0)
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Success).SetMessage(AppGlobal.EditSuccess);
            }
            else
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.EditError);
            }
            return Json(respone);
        }

        public IActionResult Delete(long Id)
        {
            BaseResponeModel respone;
            int result = navigationRepository.Delete(Id);
            if (result > 0)
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Success).SetMessage(AppGlobal.EditSuccess);
            }
            else
            {
                respone = new BaseResponeModel().SetStatus(AppGlobal.Error).SetMessage(AppGlobal.EditError);
            }
            return Json(respone);
        }

        public IActionResult MenuLeft()
        {
            var model = navigationRepository.Get().GenerateTree(item => item.Code, item => item.ParentCode, string.Empty);
            return PartialView("~/Views/Navigation/MenuLeft.cshtml", model);
        }
    }
}
