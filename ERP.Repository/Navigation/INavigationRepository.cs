using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface INavigationRepository : IRepository<Navigation>
    {
        public List<NavigationDataTransfer> GetDataTransfers();

        public bool IsExistCode(string Code);
    }
}
