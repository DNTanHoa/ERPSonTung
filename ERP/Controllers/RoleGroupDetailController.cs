﻿using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Role;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleGroupDetailController : BaseController
    {
        private readonly IRoleGroupDetailRepository roleGroupDetailRepository;
        private readonly ILogger<RoleGroupDetailController> logger;

        public RoleGroupDetailController(IRoleGroupDetailRepository roleGroupDetailRepository, ILogger<RoleGroupDetailController> logger)
        {
            this.roleGroupDetailRepository = roleGroupDetailRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(RoleGroupDetailCreateRequestModel model)
        {
            var databaseObject = model.MapTo<RoleGroupDetail>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = roleGroupDetailRepository.Insert(databaseObject);
            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Insert, AppGlobal.CreateSucess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.CreateError);
            }

            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(RoleGroupDetailUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<RoleGroupDetail>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = roleGroupDetailRepository.Update(databaseObject);
            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Edit, AppGlobal.EditSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Edit, AppGlobal.EditError);
            }

            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(long Id)
        {
            int result = roleGroupDetailRepository.Delete(Id);

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Delete, AppGlobal.DeleteSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Delete, AppGlobal.DeleteError);
            }

            return GetCommonRespone();
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChange(RoleGroupDetailSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<RoleGroupDetail>();
            int result = 0;

            if (model.Id > 0)
            {
                result = roleGroupDetailRepository.Update(databaseObject);
            }
            else
            {
                result = roleGroupDetailRepository.Insert(databaseObject);
            }

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Edit, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Edit, AppGlobal.SaveChangeFalse);
            }

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetByRoleGroupCode(string RoleGroupCode)
        {
            Data = roleGroupDetailRepository.GetByRoleGroupCode(RoleGroupCode).ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }

        //[HttpGet]
        //public ActionResult<CommonResponeModel> GetUserNavigationRole(string username)
        //{
        //    if (string.IsNullOrEmpty(username))
        //    {
        //        username = RequestUsername;
        //    }
        //    Result = Result = new SuccessResultFactory().Factory(ActionType.Select);
        //    Data = roleGroupDetailRepository.GetAllowedDataTransfersByUserName(username);
        //    return GetCommonRespone();
        //}
    }
}