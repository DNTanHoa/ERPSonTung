namespace ERP.Model.DataTransferObjects.Dashboard
{
    public class DepartmentStatisticDataTransfer
    {
        /// <summary>
        /// Tên bộ phận
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tỷ lệ nhân sự bộ phận
        /// </summary>
        public decimal? EmployeePercent { get; set; }

        /// <summary>
        /// Tổng nhân sự bộ phận
        /// </summary>
        public int EmployeeCount { get; set; }

        /// <summary>
        /// Số nhân viên vắng
        /// </summary>
        public int EmployeeLeave { get; set; }

        /// <summary>
        /// Số nhân viên đi công tác
        /// </summary>
        public int EmployeeOutside { get; set; }

        /// <summary>
        /// Số lượng đi đúng giờ
        /// </summary>
        public int EmployeeGoOnTime { get; set; }

        /// <summary>
        /// Số lượng đi trễ
        /// </summary>
        public int EmployeeGoLate { get; set; }
    }
}