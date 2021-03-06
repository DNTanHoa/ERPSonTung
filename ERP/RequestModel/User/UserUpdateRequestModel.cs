﻿namespace ERP.RequestModel.User
{
    public class UserUpdateRequestModel
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public string EmployeeCode { get; set; }

        public string Note { get; set; }
    }
}