using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Controllers;
using ERP.Repository;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Implement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeCheckInOutController : BaseController
    {
        private readonly IEmployeeCheckInOutRepository employeeCheckInOutRepository;

        public EmployeeCheckInOutController(IEmployeeCheckInOutRepository employeeCheckInOutRepository)
        {
            this.employeeCheckInOutRepository = employeeCheckInOutRepository;
        }

        [HttpGet]
        public ActionResult<BaseResponeModel> GetTimeRangeDataTransfer(DateTime? FromDate, DateTime? ToDate)
        {
            Data = employeeCheckInOutRepository.GetTimeRangeDataTransfer(FromDate, ToDate);
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetResponeModel();
        }
    }
}
