using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public class FileImportRepository : Repository<FileImport>, IFileImportRepository
    {
        public FileImportRepository(SonTungContext context) : base(context)
        {

        }
    }
}
