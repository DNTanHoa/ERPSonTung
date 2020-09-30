using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.User;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Providers;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<BaseResponeModel> Login(LoginUserRequestModel model)
        {
            var LoginResponeModel = new LoginResponeModel();
            BaseResult Result;

            if(ModelState.IsValid)
            {
                if (userRepository.IsValidUser(model.Username, model.Password))
                {
                    Result = new SuccessResultFactory().Factory(ActionType.Login);
                    LoginResponeModel.TokenExpireDate = DateTime.Now.AddDays(1);
                    LoginResponeModel.Token = TokenProvider.GenerateTokenString(model.ToDictionaryStringString());
                }
                else
                {
                    Result = new ErrorResultFactory().Factory(ActionType.Login);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Login, message);
            }

            return new BaseResponeModel(LoginResponeModel, Result);
        }

        [HttpGet]
        public ActionResult<BaseResponeModel> Get()
        {
            var Data = userRepository.Get().ToList();
            return new BaseResponeModel(Data, new SuccessResultFactory().Factory(ActionType.Select));
        }
    }
}
