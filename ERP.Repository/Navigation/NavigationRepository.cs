using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace ERP.Repository
{
    public class NavigationRepository : Repository<Navigation>, INavigationRepository
    {
        public NavigationRepository(SonTungContext context) : base(context)
        {

        }

        public List<NavigationDataTransfer> GetDataTransfers()
        {
            var query = from navigation in context.Navigation
                        join navigationType in context.Category on navigation.Type equals navigationType.Code into groupNavigation
                        from navigations in groupNavigation.DefaultIfEmpty()
                        select new NavigationDataTransfer
                        {
                            Id = navigation.Id,
                            CreateDate = navigation.CreateDate,
                            CreateUser = navigation.CreateUser,
                            UpdateDate = navigation.UpdateDate,
                            UpdateUser = navigation.UpdateUser,
                            Deleted = navigation.Deleted,
                            Note = navigation.Note,
                            Code = navigation.Code,
                            ControllerName = navigation.ControllerName,
                            ActionName = navigation.ActionName,
                            Icon = navigation.Icon,
                            DisplayName = navigation.DisplayName,
                            ParentCode = navigation.ParentCode,
                            TypeName = navigations.Name,
                            SortOrder = navigation.SortOrder,
                            cbxMenuType = new CategoryModelTemplate
                            {
                                Code = navigations.Code,
                                Display = navigations.Code + " - " + navigations.Name
                            }
                        };
            return query.ToList();
        }

        public bool IsExistCode(string Code)
        {
            var navigation = context.Navigation.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return navigation != null ? true : false;
        }
    }
}
