using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Repository;
using ERP.RequestModel.User;
using ERP.ResponeModel;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Providers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult<LoginResponeModel> Login(LoginUserRequestModel model)
        {
            var responeModel = new LoginResponeModel();
            if(ModelState.IsValid)
            {
                if (userRepository.IsValidUser(model.Username, model.Password))
                {
                    responeModel.Status = AppGlobal.Success;
                    responeModel.TokenExpireDate = DateTime.Now.AddDays(1);
                    responeModel.Token = TokenProvider.GenerateTokenString(model.ToDictionaryStringString());
                }
                else
                {
                    responeModel.Status = AppGlobal.Fail;
                    responeModel.Message = AppGlobal.LoginFailMessage;
                }
            }
            else
            {
                responeModel.Status = AppGlobal.Error;
                responeModel.Message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return responeModel;
        }
    }
}
