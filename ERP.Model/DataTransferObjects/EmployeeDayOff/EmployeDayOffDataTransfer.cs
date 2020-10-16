using System;

namespace ERP.Model.DataTransferObjects.EmployeeDayOff
{
    public class EmployeDayOffDataTransfer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public string Reason { get; set; }
        public string ApproveStatus { get; set; }
    }
}