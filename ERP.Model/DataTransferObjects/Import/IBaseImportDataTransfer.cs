using System.Collections.Generic;

namespace ERP.Model.DataTransferObjects
{
    public interface IBaseImportDataTransfer
    {
        public List<string> ErrorMessage { get; set; }

        public bool IsError { get; set; }
    }
}
