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
    public class RoleController : BaseController
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        public ActionResult<CommonResponeModel> Create(RoleCreateRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var databaseObject = model.MapTo<Role>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = roleRepository.Insert(databaseObject);
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
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResultFactory().Factory(ActionType.Insert);
            }
            
            return GetCommonRespone();
        }

        [HttpPut]
        public ActionResult<CommonResponeModel> Update(RoleUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<Role>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = roleRepository.Update(databaseObject);
                if (result > 0)
                {
                    Result = new SuccessResultFactory().Factory(ActionType.Edit);
                }
                else
                {
                    Result = new ErrorResultFactory().Factory(ActionType.Edit);
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
            int result = roleRepository.Delete(Id);
            
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

        [HttpPost]
        public ActionResult<CommonResponeModel> SaveChange(RoleSaveChangeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<Role>();
                int result = 0;
                
                if(model.Id > 0)
                {
                    result = roleRepository.Update(databaseObject);
                }
                else
                {
                    result = roleRepository.Insert(databaseObject);
                }

                if(result > 0)
                {
                    Result = new SuccessResult(ActionType.Edit, AppGlobal.EditSuccess);
                }   
                else
                {
                    Result = new SuccessResult(ActionType.Edit, AppGlobal.Error);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Edit, message);
            }

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<List<RoleDataTransfer>> GetUserNavigationRole(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = RequestUsername;
            }
            return 
        }

    }
}
