using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.EmployeeContract;
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
    public class EmployeeContractController : BaseController
    {
        private readonly IEmployeeContractRepository employeeContractRepository;
        private readonly ILogger<EmployeeContract> logger;

        public EmployeeContractController(IEmployeeContractRepository employeeContractRepository, ILogger<EmployeeContract> logger)
        {
            this.employeeContractRepository = employeeContractRepository;
            this.logger = logger;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(EmployeeContractCreateRequestModel model)
        {
            var databaseObject = model.MapTo<EmployeeContract>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = employeeContractRepository.Insert(databaseObject);
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
        public ActionResult<CommonResponeModel> Update(EmployeeContractUpdateRequestModel model)
        {
            var databaseObject = model.MapTo<EmployeeContract>();
            databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
            int result = employeeContractRepository.Update(databaseObject);
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
            int result = employeeContractRepository.Delete(Id);

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
        public ActionResult<CommonResponeModel> SaveChange(EmployeeContractSaveChangeRequestModel model)
        {
            var databaseObject = model.MapTo<EmployeeContract>();
            int result = 0;

            if (model.Id > 0)
            {
                result = employeeContractRepository.Update(databaseObject);
            }
            else
            {
                result = employeeContractRepository.Insert(databaseObject);
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
            Data = employeeContractRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
