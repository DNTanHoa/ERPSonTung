using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Category;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetByEntity(CategoryGetRequestModel model)
        {
            return categoryRepository.GetByEntity(model.Entity).ToList();
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll(CategoryGetRequestModel model)
        {
            return categoryRepository.Get().ToList();
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
