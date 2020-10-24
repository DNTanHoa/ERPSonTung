using System;

namespace ERP.RequestModel.Holiday
{
    public class HolidayCreateRequestModel
    {
        public string Code { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryIncreasePercent { get; set; }
    }
}