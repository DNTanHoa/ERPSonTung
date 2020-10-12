using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        public bool IsUserAllowForNavigation(string NavigationCode, string Username);

        public List<RoleDataTransfer> GetAllowedDataTransfersByUserName(string Username);

        public bool IsUserAllowEditEntity(string Entity, string Username);

        public bool IsUserAllowCreateEntity(string Entity, string Username);

        public bool IsUserAllowDeleteEntity(string Entity, string Username);
    }
}
