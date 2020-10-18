using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class RoleRepository : Repository<UserRole>, IRoleRepository
    {
        public RoleRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public List<RoleDataTransfer> GetAllowedDataTransfersByUserName(string Username)
        {
            var query = from role in context.UserRole
                        join navigation in context.Navigation on role.NavigationCode equals navigation.Code into groupNavigation
                        from navigations in groupNavigation.DefaultIfEmpty()
                        join user in context.User on role.Username equals user.Username into groupUser
                        from users in groupUser.DefaultIfEmpty()
                        where role.Username == Username
                        select new RoleDataTransfer
                        {
                            Navigation = navigations,
                            IsAllow = role.IsAllow,
                        };
            return query.ToList();
        }

        public bool IsUserAllowCreateEntity(string Entity, string Username)
        {
            var role = context.UserRole.Where(item => item.Entity == Entity
                                                  && item.Username == Username).FirstOrDefault();
            if (role != null)
            {
                return role.CanCreate != null ? (bool)role.CanCreate : false;
            }

            return false;
        }

        public bool IsUserAllowDeleteEntity(string Entity, string Username)
        {
            var role = context.UserRole.Where(item => item.Entity == Entity
                                                  && item.Username == Username).FirstOrDefault();
            if (role != null)
            {
                return role.CanDelete != null ? (bool)role.CanDelete : false;
            }

            return false;
        }

        public bool IsUserAllowEditEntity(string Entity, string Username)
        {
            var role = context.UserRole.Where(item => item.Entity == Entity
                                                  && item.Username == Username).FirstOrDefault();
            if (role != null)
            {
                return role.CanUpdate != null ? (bool)role.CanUpdate : false;
            }

            return false;
        }

        public bool IsUserAllowForNavigation(string NavigationCode, string Username)
        {
            var role = context.UserRole.Where(item => item.NavigationCode == NavigationCode
                                                  && item.Username == Username).FirstOrDefault();
            if(role != null)
            {
                return role.IsAllow != null ? (bool)role.IsAllow : false;
            }

            return false;
        }
    }
}
