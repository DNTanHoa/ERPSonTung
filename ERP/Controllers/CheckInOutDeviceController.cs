using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.CheckInOutDevice;
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
    public class CheckInOutDeviceController : BaseController
    {
        private readonly ICheckInOutDeviceRepository checkInOutDeviceRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly ILogger<CheckInOutDevice> logger;

        public CheckInOutDeviceController(ICheckInOutDeviceRepository checkInOutDeviceRepository,
                                            IEntityCenterRepository entityCenterRepository,
                                            ILogger<CheckInOutDevice> logger)
        {
            this.checkInOutDeviceRepository = checkInOutDeviceRepository;
            this.entityCenterRepository = entityCenterRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(CheckInOutDeviceCreateRequestModel model)
        {
            var databaseObject = model.MapTo<CheckInOutDevice>();

            //empty code
            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(CheckInOutDevice));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            //check exist in db
            if (checkInOutDeviceRepository.IsExistCode(databaseObject.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = checkInOutDeviceRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> Update(CheckInOutDeviceUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<CheckInOutDevice>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = checkInOutDeviceRepository.Update(databaseObject);
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
            int result = checkInOutDeviceRepository.Delete(Id);

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
        public ActionResult<CommonResponeModel> SaveChange(CheckInOutDeviceSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<CheckInOutDevice>();
            int result = 0;

            if (model.Id > 0)
            {
                result = checkInOutDeviceRepository.Update(databaseObject);
            }
            else
            {
                //empty code
                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(CheckInOutDevice));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                //check exist in db
                if (checkInOutDeviceRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = checkInOutDeviceRepository.Insert(databaseObject);
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
            Data = checkInOutDeviceRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}