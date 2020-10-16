using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.DataTransferObjects;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleGroupController : BaseController
    {
        private readonly IRoleGroupRepository roleGroupRepository;

        public RoleGroupController(IRoleGroupRepository roleGroupRepository)
        {
            this.roleGroupRepository = roleGroupRepository;
        }

        [HttpPost]
        public ActionResult<CommonResponeModel> Create(RoleCreateRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var databaseObject = model.MapTo<RoleGroup>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = roleGroupRepository.Insert(databaseObject);
                if (result > 0)
                {
                    Result = new SuccessResult(ActionType.Insert, AppGlobal.CreateSucess);
                }
                else
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.CreateError);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Insert, message);
            }
            
            return GetCommonRespone();
        }

        [HttpPut]
        public ActionResult<CommonResponeModel> Update(RoleUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<RoleGroup>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = roleGroupRepository.Update(databaseObject);
                if (result > 0)
                {
                    Result = new SuccessResult(ActionType.Edit, AppGlobal.EditSuccess);
                }
                else
                {
                    Result = new ErrorResult(ActionType.Edit, AppGlobal.EditError);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Edit, message);
            }
            
            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(long Id)
        {
            int result = roleGroupRepository.Delete(Id);
            
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
        public ActionResult<CommonResponeModel> SaveChange(RoleSaveChangeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<RoleGroup>();
                int result = 0;
                
                if(model.Id > 0)
                {
                    result = roleGroupRepository.Update(databaseObject);
                }
                else
                {
                    result = roleGroupRepository.Insert(databaseObject);
                }

                if(result > 0)
                {
                    Result = new SuccessResult(ActionType.Edit, AppGlobal.SaveChangeSuccess);
                }   
                else
                {
                    Result = new ErrorResult(ActionType.Edit, AppGlobal.SaveChangeFalse);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Edit, message);
            }

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
        //    Data = roleGroupRepository.GetAllowedDataTransfersByUserName(username);
        //    return GetCommonRespone();
        //}
    }
}
