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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TrainingCourseController : BaseController
    {
        private readonly ITrainingCourseRepository trainingCourseRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly ILogger<TrainingCourse> logger;

        public TrainingCourseController(ITrainingCourseRepository trainingCourseRepository,
                                        IEntityCenterRepository entityCenterRepository,
                                        ILogger<TrainingCourse> logger)
        {
            this.trainingCourseRepository = trainingCourseRepository;
            this.entityCenterRepository = entityCenterRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(TrainingCourseCreateRequestModel model)
        {
            var databaseObject = model.MapTo<TrainingCourse>();

            //empty code
            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(TrainingCourse));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            //check exist in db
            if (trainingCourseRepository.IsExistCode(databaseObject.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = trainingCourseRepository.Insert(databaseObject);

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
        public ActionResult<CommonResponeModel> Update(TrainingCourseUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<TrainingCourse>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = trainingCourseRepository.Update(databaseObject);
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
            int result = trainingCourseRepository.Delete(Id);

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
        public ActionResult<CommonResponeModel> SaveChange(TrainingCourseSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<TrainingCourse>();
            int result = 0;

            if (model.Id > 0)
            {
                result = trainingCourseRepository.Update(databaseObject);
            }
            else
            {
                //empty code
                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(TrainingCourse));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                //check exist in db
                if (trainingCourseRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = trainingCourseRepository.Insert(databaseObject);
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
            Data = trainingCourseRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}