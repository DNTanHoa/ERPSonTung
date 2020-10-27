using ERP.Helpers;
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
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeDayOffController : BaseController
    {
        #region constructor

        private readonly IEmployeeDayOffRepository _employeeDayOffRepository;

        public EmployeeDayOffController(IEmployeeDayOffRepository employeeDayOffRepository)
        {
            this._employeeDayOffRepository = employeeDayOffRepository;
        }

        #endregion constructor

        #region public method

        [HttpGet]
        public ActionResult<CommonResponeModel> Get(string employeeCode, DateTime? fromDate, DateTime? toDate)
        {
            var result = this._employeeDayOffRepository.GetFilteredItems(employeeCode, fromDate, toDate);

            Data = result;
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetItemsByEmployeeCode(string employeeCode)
        {


            if (string.IsNullOrEmpty(employeeCode))
            {
                Result = new ErrorResult(ActionType.Select, AppGlobal.Error);
            }
            else
            {
                var result = this._employeeDayOffRepository.GetItemsByEmployeeCode(employeeCode);

                Data = result;
                Result = new SuccessResultFactory().Factory(ActionType.Select);
            }

            

            return GetCommonRespone();
        }


        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(EmployeeDayOffRequest request)
        {
            var result = 0;

            var model = request.MapTo<EmployeeDayOff>();

            model.InitBeforeSave(RequestUsername, InitType.Create);
            result = this._employeeDayOffRepository.Insert(model);

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

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(EmployeeDayOffRequest request)
        {
            var result = 0;

            var model = request.MapTo<EmployeeDayOff>();

            var currentObj = this._employeeDayOffRepository.GetItemById(model.Id);

            if (currentObj != null)
            {
                model.InitBeforeSave(RequestUsername, InitType.Update);
                result = this._employeeDayOffRepository.Update(model);
            }
            else
            {
                Result = new ErrorResult(ActionType.Select, CommonMessageGlobal._404);
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

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChange(EmployeeDayOffRequest request)
        {
            var result = 0;

            var model = request.MapTo<EmployeeDayOff>();

            if (model.Id == 0)
            {
                model.InitBeforeSave(RequestUsername, InitType.Create);
                result = this._employeeDayOffRepository.Insert(model);
            }
            else
            {
                var currentObj = this._employeeDayOffRepository.GetItemById(model.Id);

                if (currentObj != null)
                {
                    model.InitBeforeSave(RequestUsername, InitType.Update);
                    result = this._employeeDayOffRepository.Update(model);
                }
                else
                {
                    Result = new ErrorResult(ActionType.Select, CommonMessageGlobal._404);
                }
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

        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(long id)
        {
            var result = 0;

            var currentObj = this._employeeDayOffRepository.GetById(id);

            if (currentObj != null)
            {
                //deleted a object set deleted is true
                currentObj.Deleted = true;
                result = this._employeeDayOffRepository.Update(currentObj);
            }
            else
            {
                Result = new ErrorResult(ActionType.Select, "Lỗi 404");
            }

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Delete, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Delete, AppGlobal.SaveChangeFalse);
            }

            return GetCommonRespone();
        }

        #endregion public method
    }
}