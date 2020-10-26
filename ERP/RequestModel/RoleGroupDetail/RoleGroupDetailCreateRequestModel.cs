namespace ERP.RequestModel.Role
{
    public class RoleGroupDetailCreateRequestModel
    {
        public string RoleGroupCode { get; set; }

        public string NavigationCode { get; set; }

        public bool? IsAllow { get; set; }

        public string Entity { get; set; }

        public bool? CanCreate { get; set; }

        public bool? CanUpdate { get; set; }

        public bool? CanRead { get; set; }

        public bool? CanDelete { get; set; }
    }
}