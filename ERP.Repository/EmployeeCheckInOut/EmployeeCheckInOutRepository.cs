using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERP.Repository
{
    public class EmployeeCheckInOutRepository  : Repository<EmployeeCheckInOut>, IEmployeeCheckInOutRepository
    {
        public EmployeeCheckInOutRepository(SonTungContext context) : base(context)
        {

        }

        public List<TimeRangDataTransfer> GetTimeRangeDataTransfer(DateTime? FromDate, DateTime? ToDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)
            };
            DataTable table = SqlHelper.FillByReader(AppGlobal.ConnectionString, "sprocEmployeeCheckInOutSelectTimeRange", parameters);
            return table.ToList<TimeRangDataTransfer>();
        }
    }
}
