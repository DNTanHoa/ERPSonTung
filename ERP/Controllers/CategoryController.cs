using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Category;
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
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEntityCenterRepository _entityCenterRepository;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryRepository categoryRepository, ILogger<CategoryController> logger, IEntityCenterRepository entityCenterRepository)
        {
            this._categoryRepository = categoryRepository;
            this.logger = logger;
            this._entityCenterRepository = entityCenterRepository;
        }

        [HttpPost]
        public ActionResult<CommonResponeModel> GetByEntity(CategoryGetRequestModel model)
        {
            Data = _categoryRepository.GetByEntity(model.Entity).ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(CategorySaveChangeRequestModel request)
        {
            var result = 0;

            var model = request.MapTo<Category>();

            model.InitBeforeSave(RequestUsername, InitType.Create);

            if (string.IsNullOrEmpty(model.Code))
            {
                var code = this._entityCenterRepository.GetCodeByEntity(nameof(Candidate));

                if (string.IsNullOrEmpty(code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                    return GetCommonRespone();
                }

                model.Code = code;
            }

            result = this._categoryRepository.Insert(model);

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Insert, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.SaveChangeFalse);
            }
            return GetCommonRespone();
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChange(CategorySaveChangeRequestModel request)
        {
            var model = request.MapTo<Category>();
            int result = 0;

            if (model.Id > 0)
            {
                model.InitBeforeSave(RequestUsername, InitType.Update);
                result = this._categoryRepository.Update(model);
            }
            else
            {
                model.InitBeforeSave(RequestUsername, InitType.Create);

                if (string.IsNullOrEmpty(model.Code))
                {
                    var code = this._entityCenterRepository.GetCodeByEntity(nameof(Category));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    model.Code = code;
                }

                if (this._categoryRepository.IsExistEntityWithCode("Category",model.Code,out Category category)==true)
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                result = this._categoryRepository.Insert(model);
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

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(CategorySaveChangeRequestModel request)
        {
            var result = 0;

            var model = request.MapTo<Category>();

            var currentObj = this._categoryRepository.GetById(model.Id);

            if (currentObj != null)
            {
                model.InitBeforeSave(RequestUsername, InitType.Update);
                result = this._categoryRepository.Update(model);
            }
            else
            {
                Result = new ErrorResult(ActionType.Select, CommonMessageGlobal._404);
            }

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Insert, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Insert, AppGlobal.SaveChangeFalse);
            }
            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetAll()
        {
            Data = categoryRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> DeleteByCode(string Code)
        {
            int result = categoryRepository.Delete(Code);

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
    }
}