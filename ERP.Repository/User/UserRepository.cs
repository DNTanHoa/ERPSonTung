using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public UserDataTransfer GetDataTransferByUsername(string Username)
        {
            var query = from user in context.User
                        join employee in context.Employee on user.EmployeeCode equals employee.Code into userGroup
                        from users in userGroup.DefaultIfEmpty()
                        where user.Username == Username
                        select new UserDataTransfer 
                        {
                            Username = user.Username,
                            Name = users.FullName,
                            Image = users.Image
                        };
            return query.ToList().SingleOrDefault();
        }

        public List<UserDataTransfer> GetDataTransfers()
        {
            var query = from user in context.User
                        join employee in context.Employee on user.EmployeeCode equals employee.Code into userGroup
                        from employees in userGroup.DefaultIfEmpty()
                        select new UserDataTransfer
                        {
                            Id = user.Id,
                            CreateDate = user.CreateDate,
                            UpdateDate = user.UpdateDate,
                            CreateUser = user.CreateUser,
                            UpdateUser = user.UpdateUser,
                            Deleted = user.Deleted,
                            Note = user.Note,
                            Username = user.Username,
                            Password = user.Password,
                            GuidCode = user.GuidCode,
                            Name = employees.FullName,
                            Image = employees.Image,
                            cbxEmployee = new EmployeeModelTemplate
                            {
                                Code = employees.Code,
                                Display = employees.Code + " - " + employees.FullName
                            }
                        };
            return query.ToList();
        }
    }
}
