using ERP.Model.Models;
using System.Collections.Generic;

namespace ERP.Model.DataTransferObjects
{
    public class EmployeeImportDataTransfer : Employee, IBaseImportDataTransfer
    {
        public List<string> ErrorMessage { get; set; } = new List<string>();
        public bool IsError { get; set; } = false;
    }
}
