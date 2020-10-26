using ERP.Helpers;
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
    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : BaseController
    {
        private readonly IRoleRepository roleRepository;
        private readonly ILogger<RoleController> logger;

        public RoleController(IRoleRepository roleRepository, ILogger<RoleController> logger)
        {
            this.roleRepository = roleRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(RoleCreateRequestModel model)
        {
            var databaseObject = model.MapTo<UserRole>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = roleRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> Update(RoleUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<UserRole>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = roleRepository.Update(databaseObject);
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
            int result = roleRepository.Delete(Id);

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
        public ActionResult<CommonResponeModel> SaveChange(RoleSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<UserRole>();
            int result = 0;

            if (model.Id > 0)
            {
                result = roleRepository.Update(databaseObject);
            }
            else
            {
                result = roleRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> GetUserNavigationRole(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = RequestUsername;
            }
            Result = Result = new SuccessResultFactory().Factory(ActionType.Select);
            Data = roleRepository.GetAllowedDataTransfersByUserName(username).GenerateTree(item => item.Navigation.Code,
                                                            item => item.Navigation.ParentCode, string.Empty);
            return GetCommonRespone();
        }
    }
}