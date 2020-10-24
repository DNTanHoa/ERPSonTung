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
    public class TrainingCourseEmployeeController : BaseController
    {
        private readonly ITrainingCourseEmployeeRepository trainingCourseEmployeeRepository;
        private readonly ILogger<TrainingCourseEmployee> logger;

        public TrainingCourseEmployeeController(ITrainingCourseEmployeeRepository trainingCourseEmployeeRepository, ILogger<TrainingCourseEmployee> logger)
        {
            this.trainingCourseEmployeeRepository = trainingCourseEmployeeRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(TrainingCourseEmployeeCreateRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var databaseObject = model.MapTo<TrainingCourseEmployee>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = trainingCourseEmployeeRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> Update(TrainingCourseEmployeeUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<TrainingCourseEmployee>();
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                int result = trainingCourseEmployeeRepository.Update(databaseObject);
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
            int result = trainingCourseEmployeeRepository.Delete(Id);
            
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
        public ActionResult<CommonResponeModel> SaveChange(TrainingCourseEmployeeSaveChangeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var databaseObject = model.MapTo<TrainingCourseEmployee>();
                int result = 0;
                
                if(model.Id > 0)
                {
                    result = trainingCourseEmployeeRepository.Update(databaseObject);
                }
                else
                {
                    result = trainingCourseEmployeeRepository.Insert(databaseObject);
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
            Data = trainingCourseEmployeeRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
