using ERP.Controllers;
using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(Navigation model)
        {
            //empty code
            if (string.IsNullOrEmpty(model.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(Navigation));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                model.Code = code;
            }

            //check exist in db
            if (navigationRepository.IsExistCode(model.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            model.InitBeforeSave(RequestUsername, InitType.Create);
            model.InitDefault();
            int result = navigationRepository.Insert(model, out model);

            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Insert);
                Data = model;
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Insert);
                Data = model;
            }

            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(Navigation model)
        {
            model.InitBeforeSave(RequestUsername, InitType.Update);
            model.InitDefault();
            
            var existModel = navigationRepository.GetById(model.Id);
            ObjectExtensions.CopyValues(existModel, model);
            
            int result = navigationRepository.Update(existModel, out existModel);

            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Edit);
                Data = existModel;
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Edit);
                Data = existModel;
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