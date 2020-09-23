using ERP.Model.Models;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SonTungContext context) : base(context) { }

        public bool IsValidUser(string Username, string Password)
        {
            var user = dbSet.Where(item => item.Username.Equals(Username)).FirstOrDefault();
            if(user != null)
            {
                if(user.Password == SecurityHelper.Encrypt(user.GuidCode, Password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsExistUsername(string Username)
        {
            var user = dbSet.Where(item => item.Username.Equals(Username)).FirstOrDefault();
            return user != null ? true : false;
        }
    }
}
