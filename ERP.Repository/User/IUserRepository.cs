using System;
using System.Collections.Generic;
using System.Text;
using ERP.Model.DataTransferObjects;
using ERP.Model.Models;

namespace ERP.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public bool IsValidUser(string Username, string Password);

        public bool IsExistUsername(string Username);

        public UserDataTransfer GetDataTransferByUsername(string Username);

        public List<UserDataTransfer> GetDataTransfers();
    }
}
