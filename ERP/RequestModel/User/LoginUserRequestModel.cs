namespace ERP.RequestModel.User
{
    public class LoginUserRequestModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberPassword { get; set; }
    }
}