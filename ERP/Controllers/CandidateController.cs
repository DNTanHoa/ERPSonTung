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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CandidateController : BaseController
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IEntityCenterRepository _entityCenterRepository;
        private readonly ILogger<CandidateController> logger;

        public CandidateController(ICandidateRepository candidateRepository, ILogger<CandidateController> logger, IEntityCenterRepository entityCenterRepository)
        {
            this._candidateRepository = candidateRepository;
            this.logger = logger;
            this._entityCenterRepository = entityCenterRepository;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(CandidateCreateRequestModel model)
        {
            var databaseObject = model.MapTo<Candidate>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);

            if (string.IsNullOrEmpty(databaseObject.Code))
            {
                var code = this._entityCenterRepository.GetCodeByEntity(nameof(Candidate));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                databaseObject.Code = code;
            }

            if (this._candidateRepository.GetByCode(databaseObject.Code) != null)
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                return GetCommonRespone();
            }

            int result = this._candidateRepository.Insert(databaseObject);

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
        public ActionResult<CommonResponeModel> Update(CandidateUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<Candidate>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = _candidateRepository.Update(databaseObject);
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
            int result = _candidateRepository.Delete(Id);
            
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
        public ActionResult<CommonResponeModel> SaveChange(CandidateSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<Candidate>();
            int result = 0;

            if (model.Id > 0)
            {
                result = _candidateRepository.Update(databaseObject);
            }
            else
            {
                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);

                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = this._entityCenterRepository.GetCodeByEntity(nameof(Candidate));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                if (this._candidateRepository.GetByCode(databaseObject.Code) != null)
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = _candidateRepository.Insert(databaseObject);
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
            Data = this._candidateRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
