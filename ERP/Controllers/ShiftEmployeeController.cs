using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel;
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
    public class ShiftEmployeeController : BaseController
    {
        private readonly IShiftEmployeeRepository shiftEmployeeRepository;
        private readonly ILogger<ShiftEmployee> logger;

        public ShiftEmployeeController(IShiftEmployeeRepository shiftEmployeeRepository, ILogger<ShiftEmployee> logger)
        {
            this.shiftEmployeeRepository = shiftEmployeeRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(ShiftEmployeeCreateRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var databaseObject = model.MapTo<ShiftEmployee>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = shiftEmployeeRepository.Insert(databaseObject);
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
                Result = new ErrorResult(ActionType.Insert, message);
            }
            
            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(ShiftEmployeeUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<ShiftEmployee>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = shiftEmployeeRepository.Update(databaseObject);
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
            int result = shiftEmployeeRepository.Delete(Id);
            
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
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChange(ShiftEmployeeSaveChangeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<ShiftEmployee>();
                int result = 0;
                
                if(model.Id > 0)
                {
                    result = shiftEmployeeRepository.Update(databaseObject);
                }
                else
                {
                    result = shiftEmployeeRepository.Insert(databaseObject);
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

        [HttpGet]
        public ActionResult<CommonResponeModel> GetAll()
        {
            Data = shiftEmployeeRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
