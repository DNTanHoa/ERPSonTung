using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Shift;
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
    public class ShiftController : BaseController
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly ILogger<Shift> logger;

        public ShiftController(IShiftRepository shiftRepository,
                                IEntityCenterRepository entityCenterRepository,
                                ILogger<Shift> logger)
        {
            this.shiftRepository = shiftRepository;
            this.entityCenterRepository = entityCenterRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(ShiftCreateRequestModel model)
        {
            var databaseObject = model.MapTo<Shift>();

            //empty code
            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(Shift));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            //check exist in db
            if (shiftRepository.IsExistCode(databaseObject.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = shiftRepository.Insert(databaseObject);
            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Insert);
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Insert);
            }

            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(ShiftUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<Shift>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = shiftRepository.Update(databaseObject);
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
            int result = shiftRepository.Delete(Id);

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
        public ActionResult<CommonResponeModel> SaveChange(ShiftSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<Shift>();
            int result = 0;

            if (model.Id > 0)
            {
                result = shiftRepository.Update(databaseObject);
            }
            else
            {
                //empty code
                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(Shift));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                //check exist in db
                if (shiftRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = shiftRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> GetAll()
        {
            Data = shiftRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}