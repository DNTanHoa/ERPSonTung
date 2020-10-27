using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ERP.Helpers;
using ERP.Model.DataTransferObjects;
using ERP.Model.Extensions;
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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEntityCenterRepository entityCenterRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                  IEntityCenterRepository entityCenterRepository)
        {
            this.employeeRepository = employeeRepository;
            this.entityCenterRepository = entityCenterRepository;
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Detail(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Employee();
            Data = employee.MapTo<EmployeeDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Contact(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Employee();
            Data = employee.MapTo<EmployeeContactDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Identity(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            Data = employee.MapTo<EmployeeIdentityDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransfer()
        {
            Data = employeeRepository.GetDataTransfer();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransferHasFilter(EmployeeFilterRequestModel filterModel)
        {
            Data = employeeRepository.GetDataTransferHasFilter(filterModel?.DepartmentCode, filterModel?.GroupCode, filterModel?.LaborGroupCode, filterModel?.StatusCode, filterModel?.StartFromDate, filterModel?.StartToDate);
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetModelTemplates()
        {
            Data = employeeRepository.GetModelTemplates();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }


        [HttpDelete]
        public ActionResult<CommonResponeModel> DeleteByCode(string Code)
        {
            int result = employeeRepository.Delete(Code);

            if(result > 0)
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
        public ActionResult<CommonResponeModel> SaveChange(EmployeeSaveChangeRequestModel model)
        {
            var databaseObject = new Employee();
            int result;

            if (model.Id == 0)
            {
                databaseObject = model.MapTo<Employee>();

                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(Employee));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                if (employeeRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.ExistCodeError);
                    return GetCommonRespone();
                }

                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                databaseObject.InitDefault();
                result = employeeRepository.Insert(databaseObject);
            }
            else
            {
                databaseObject = employeeRepository.GetById(model.Id);
                databaseObject.MapFrom(model);
                databaseObject.InitBeforeSave(RequestUsername, InitType.Update);
                databaseObject.InitDefault();
                result = employeeRepository.Update(databaseObject);
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

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChangeContact(EmployeeContactDetailRequestModel model)
        {
            var databaseObject = new Employee();
            int result;

            if (model.Id == 0)
            {
                Result = new ErrorResult(ActionType.Insert, "Mã nhân viên không tồn tại");
                return GetCommonRespone();
            }
            else
            {
                databaseObject = employeeRepository.GetById(model.Id);
                databaseObject.MapFrom(model);
                databaseObject.InitBeforeSave(RequestUsername, InitType.Update);
                databaseObject.InitDefault();
                result = employeeRepository.Update(databaseObject);
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
    }
}
