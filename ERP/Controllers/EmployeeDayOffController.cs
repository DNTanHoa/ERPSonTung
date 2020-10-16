using ERP.Repository;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Implement;
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
        public ActionResult<CommonResponeModel> GetItems(string employeeCode, DateTime? fromDate, DateTime? toDate)
        {
            var result = this._employeeDayOffRepository.GetItems(employeeCode, fromDate, toDate);

            Data = result;
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();

        }



        #endregion


    }
}