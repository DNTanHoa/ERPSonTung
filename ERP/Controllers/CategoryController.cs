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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<BaseResponeModel> GetByEntity(CategoryGetRequestModel model)
        {
            var Data =  categoryRepository.GetByEntity(model.Entity).ToList();
            return new BaseResponeModel(Data, new SuccessResultFactory().Factory(ActionType.Select));
        }

        [HttpGet]
        public ActionResult<BaseResponeModel> GetAll(CategoryGetRequestModel model)
        {
            var Data =  categoryRepository.Get().ToList();
            return new BaseResponeModel(Data, new SuccessResultFactory().Factory(ActionType.Select));
        }

        [HttpDelete]
        public ActionResult<BaseResponeModel> DeleteByCode(string Code)
        {
            int result =  categoryRepository.Delete(Code);

            if (result > 0)
            {
                return new BaseResponeModel(new SuccessResultFactory().Factory(ActionType.Delete));
            }
            else
            {
                return new BaseResponeModel(new ErrorResultFactory().Factory(ActionType.Delete));
            }    
        }
    }
}
