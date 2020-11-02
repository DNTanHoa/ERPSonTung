using ERP.Model.DataTransferObjects;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ERP.Repository.Statistic
{
    public class StatisticRepository: IStatisticRepository
    {
        public IEnumerable<DashboardOverviewDataTransfer> GetDataTransferDashboardOverview(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate),
            };

            DataTable table = SqlHelper.FillByReader(AppGlobal.ConnectionString, "sprocStatisticSelectDashboardOverview", parameters);
            return table.ToList<DashboardOverviewDataTransfer>();
        }

        public IEnumerable<DepartmentStatisticDataTransfer> SelectEmployeeDepartmentCountStatistic(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate),
            };
            ///TODO: VIết SP bổ sung
            DataTable table = SqlHelper.FillByReader(AppGlobal.ConnectionString, "sprocStatisticSelectEmployeeDepartmentCount", parameters);
            return table.ToList<DepartmentStatisticDataTransfer>();
        }
    }
}