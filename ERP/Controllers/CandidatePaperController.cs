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
    public class CandidatePaperController : BaseController
    {
        private readonly ICandidatePaperRepository candidatePaperRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly ILogger<CandidatePaper> logger;

        public CandidatePaperController(ICandidatePaperRepository candidatePaperRepository,
                                        IEntityCenterRepository entityCenterRepository,
                                        ILogger<CandidatePaper> logger)
        {
            this.candidatePaperRepository = candidatePaperRepository;
            this.entityCenterRepository = entityCenterRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(CandidatePaperCreateRequestModel model)
        {
            var databaseObject = model.MapTo<CandidatePaper>();

            //empty code
            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = entityCenterRepository.GetCodeByEntity(nameof(CandidatePaper));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            //check exist in db
            if (candidatePaperRepository.IsExistCode(databaseObject.Code))
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = candidatePaperRepository.Insert(databaseObject);

            //result
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
        public ActionResult<CommonResponeModel> Update(CandidatePaperUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<CandidatePaper>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = candidatePaperRepository.Update(databaseObject);
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
            int result = candidatePaperRepository.Delete(Id);
            
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
        public ActionResult<CommonResponeModel> SaveChange(CandidatePaperSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<CandidatePaper>();
            int result = 0;

            if (model.Id > 0)
            {
                result = candidatePaperRepository.Update(databaseObject);
            }
            else
            {
                //empty code
                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(CandidatePaper));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                //check exist in db
                if (candidatePaperRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = candidatePaperRepository.Insert(databaseObject);
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
            Data = candidatePaperRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
