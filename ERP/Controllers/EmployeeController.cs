using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDataTransfer>> GetDataTransferAll()
        {
            return employeeRepository.GetDataTransfer().ToList();
        }

        [HttpDelete]
        public ActionResult<BaseResponeModel> DeleteByCode(string Code)
        {
            BaseResponeModel respone;
            int result = employeeRepository.Delete(Code);
            if(result > 0)
            {
                respone = new BaseResponeModel(new SuccessResultFactory().Factory(ActionType.Delete));
            }
            else
            {
                respone = new BaseResponeModel(new ErrorResultFactory().Factory(ActionType.Delete));
            }
            return respone;
        }

        [HttpPost]
        public ActionResult<BaseResponeModel> SaveChange(EmployeeSaveChangeRequestModel model)
        {
            BaseResponeModel respone;
            int result;

            var databaseObject = model.MapTo<Employee>();

            if(string.IsNullOrEmpty(model.Code))
            {
                result = employeeRepository.Insert(databaseObject);

                if (result > 0)
                {
                    respone = new BaseResponeModel(new SuccessResultFactory().Factory(ActionType.Insert));
                }
                else
                {
                    respone = new BaseResponeModel(new ErrorResultFactory().Factory(ActionType.Insert));
                }
            }
            else
            {
                result = employeeRepository.Update(databaseObject);

                if (result > 0)
                {
                    respone = new BaseResponeModel(new SuccessResultFactory().Factory(ActionType.Edit));
                }
                else
                {
                    respone = new BaseResponeModel(new ErrorResultFactory().Factory(ActionType.Edit));
                }
            }
            
            return respone;
        }
    }
}
