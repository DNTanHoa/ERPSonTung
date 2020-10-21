using ERP.Repository.Statistic;
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
    public class StatisticController : BaseController
    {
        #region Constructor

        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {
            this._statisticRepository = statisticRepository;
        }

        #endregion Constructor


        #region Public method


        /// <summary>
        /// api home dashboard overview
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CommonResponeModel> DashboardOverview(DateTime fromDate, DateTime toDate)
        {
            Data = this._statisticRepository.GetDataTransferDashboardOverview(fromDate, toDate);
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        #endregion
    }
}