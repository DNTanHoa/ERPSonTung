using System;
using System.Collections.Generic;
using System.Text;
using ERP.Model.Models;

namespace ERP.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public bool IsValidUser(string Username, string Password);

        public bool IsExistUsername(string Username);
    }
}
