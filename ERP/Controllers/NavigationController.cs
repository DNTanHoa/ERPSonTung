using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ERP.Controllers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ERP.MVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet]
        public ActionResult<CommonResponeModel> Get()
        {
            Data = navigationRepository.Get();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransfers()
        {
            Data = navigationRepository.GetDataTransfers();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpPost]
        public ActionResult<CommonResponeModel> Create(Navigation model)
        {
            string code = entityCenterRepository.GetCodeByEntity(nameof(Navigation));

            if(string.IsNullOrEmpty(code))
            {
                model.Code = code;
                model.InitBeforeSave(RequestUsername, InitType.Create);
                model.InitDefault();
                int result = navigationRepository.Insert(model);

                if (result > 0)
                {
                    Result = new SuccessResultFactory().Factory(ActionType.Insert);
                }
                else
                {
                    Result = new ErrorResultFactory().Factory(ActionType.Insert);
                }
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Insert);
            }

            return GetCommonRespone();
        }

        [HttpPut]
        public ActionResult<CommonResponeModel> Update(Navigation model)
        {
            model.InitBeforeSave(RequestUsername, InitType.Update);
            model.InitDefault();
            int result = navigationRepository.Update(model);

            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Edit);
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Edit);
            }

            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(long Id)
        {
            int result = navigationRepository.Delete(Id);

            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Delete);
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Delete);
            }

            return GetCommonRespone();
        }
    }
}
