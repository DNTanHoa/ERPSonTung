using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Category;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetByEntity(CategoryGetRequestModel model)
        {
            Data =  categoryRepository.GetByEntity(model.Entity).ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetAll(CategoryGetRequestModel model)
        {
            Data =  categoryRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> DeleteByCode(string Code)
        {
            int result =  categoryRepository.Delete(Code);

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
