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
using ERP.Validators;
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
    public class RecruitmentPlanController : BaseController
    {
        private readonly IRecruitmentPlanRepository recruitmentPlanRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ILogger<RecruitmentPlan> logger;

        public RecruitmentPlanController(IRecruitmentPlanRepository recruitmentPlanRepository, 
                                        IEntityCenterRepository entityCenterRepository,
                                        ICategoryRepository categoryRepository,
                                        ILogger<RecruitmentPlan> logger)
        {
            this.recruitmentPlanRepository = recruitmentPlanRepository;
            this.entityCenterRepository = entityCenterRepository;
            this.categoryRepository = categoryRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(RecruitmentPlanCreateRequestModel model)
        {
            var validator = new RecruitmentPlanCreateValidator(categoryRepository);

            var databaseObject = model.MapTo<RecruitmentPlan>();

            //empty code
            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(RecruitmentPlan));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    Data = model;
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            //check exist in db
            if (recruitmentPlanRepository.IsExistCode(databaseObject.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);

            int result = recruitmentPlanRepository.Insert(databaseObject);
            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Insert);
                Data = databaseObject;
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Insert);
                Data = databaseObject;
            }

            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(RecruitmentPlanUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<RecruitmentPlan>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = recruitmentPlanRepository.Update(databaseObject);
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
            int result = recruitmentPlanRepository.Delete(Id);
            
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
        public ActionResult<CommonResponeModel> SaveChange(RecruitmentPlanSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<RecruitmentPlan>();
            int result = 0;

            if (model.Id > 0)
            {
                result = recruitmentPlanRepository.Update(databaseObject);
            }
            else
            {
                //empty code
                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(RecruitmentPlan));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                //check exist in db
                if (recruitmentPlanRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = recruitmentPlanRepository.Insert(databaseObject);
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
            Data = recruitmentPlanRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetById(long Id)
        {
            Data = recruitmentPlanRepository.GetById(Id);
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransfer()
        {
            Data = recruitmentPlanRepository.GetDataTransfer();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
