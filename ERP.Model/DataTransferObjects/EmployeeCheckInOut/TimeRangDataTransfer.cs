using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class TimeRangDataTransfer
    {
        public DateTime? Date { get; set; }

        public string DateOfWeek { get; set; }

        public bool IsWeekend { get; set; }

        public bool IsHoliday { get; set; }

        public string DateField { get; set; }

        public string DateDescription { get; set; }

        public string DateTitle { get; set; }
    }
}
