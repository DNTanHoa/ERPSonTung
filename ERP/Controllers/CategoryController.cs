using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Category;
using ERP.ResponeModel;
using ERP.Ultilities.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                return new BaseResponeModel { Message = "", Status = AppGlobal.Success };
            }
            else
            {
                return new BaseResponeModel { Message = "", Status = AppGlobal.Error };
            }    
        }
    }
}
