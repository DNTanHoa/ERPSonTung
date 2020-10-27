using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IFileImportRepository : IRepository<FileImport>
    {
        /// TODO: implement method
        public bool IsExistCode(string Code);
    }
}
