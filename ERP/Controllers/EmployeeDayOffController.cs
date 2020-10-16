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
using System.Linq;

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


        #endregion

        #region public method

        /// <summary>
        /// get filtered list employee day off
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CommonResponeModel> Get(string employeeCode, DateTime? fromDate, DateTime? toDate)
        {
            var result = this._employeeDayOffRepository.GetFilteredItems(employeeCode, fromDate, toDate);

            Data = result;
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();

        }


        //[HttpPost]
        //public ActionResult<CommonResponeModel> SaveChange(EmployeeDayOffRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
        //        Result = new ErrorResult(ActionType.Insert, message);
        //        return GetCommonRespone();
        //    }
        //    else
        //    {
        //        var result = 0;

        //        var model = request.MapTo<EmployeeDayOff>();

        //        if (model.Id == 0)
        //        {
        //            result = this._employeeDayOffRepository.Insert(model);
        //            Result = new SuccessResult(ActionType.Insert, AppGlobal.SaveChangeSuccess);
        //        }
        //        else
        //        {
        //            var currentObj = this._employeeDayOffRepository.GetById(model.Id);


        //            if (currentObj != null)
        //            {
        //                this._employeeDayOffRepository.Update(model);
        //            }
        //            else
        //            {
        //                Result = new ErrorResult(ActionType.Edit, AppGlobal.ExistCodeError);
        //                return GetCommonRespone();
        //            }
        //        }





        //    }


        //}


        #endregion


    }
}