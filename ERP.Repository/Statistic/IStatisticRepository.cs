using ERP.Model.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace ERP.Repository.Statistic
{
    public interface IStatisticRepository
    {
        IEnumerable<DashboardOverviewDataTransfer> GetDataTransferDashboardOverview(DateTime fromDate, DateTime toDate);
    }
}