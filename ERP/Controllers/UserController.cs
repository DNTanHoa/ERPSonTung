using ERP.Helpers;
using ERP.Model.Extensions;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Create(UserCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.IsExistUsername(model.Username))
                {
                    string message = "Tên đăng nhập đã tồn tại";
                    Result = new ErrorResult(ActionType.Login, message);
                }
                else
                {
                    var databaseObject = model.MapTo<User>();
                    databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                    databaseObject.InitDefault();
                    databaseObject.SetPassword();
                    int result = userRepository.Insert(databaseObject);

                    if (result > 0)
                    {
                        Result = new SuccessResult(ActionType.Insert, AppGlobal.CreateSucess);
                        Data = databaseObject;
                    }
                    else
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.CreateError);
                        Data = databaseObject;
                    }
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Login, message);
            }

            return GetCommonRespone();
        }

        [HttpPut]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Update(UserUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.GetById(model.Id);

                if (user != null)
                {
                    if (userRepository.IsExistUsername(model.Username) && user.Username != model.Username)
                    {
                        string message = "Tên đăng nhập đã tồn tại";
                        Result = new ErrorResult(ActionType.Login, message);
                        return GetCommonRespone();
                    }
                    else
                    {
                        if (model.Password == user.Password) //Not change password
                        {
                            user.Password = user.Password; //update to old password
                        }
                        else //change password
                        {
                            user.MapFrom(model);
                            user.InitBeforeSave(RequestUsername, InitType.Update);
                            user.InitDefault();
                            user.SetPassword();
                        }

                        int result = userRepository.Update(user);

                        if (result > 0)
                        {
                            Result = new SuccessResult(ActionType.Edit, AppGlobal.EditSuccess);
                            Data = user;
                        }
                        else
                        {
                            Result = new ErrorResult(ActionType.Edit, AppGlobal.EditError);
                            Data = user;
                        }
                    }
                }
                else
                {
                    string message = "Người dùng không tồn tại trong hệ thống";
                    Result = new ErrorResult(ActionType.Login, message);
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Login, message);
            }
            return GetCommonRespone();
        }

        [HttpPost]
        [AllowAnonymous]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> Login(LoginUserRequestModel model)
        {
            var LoginResponeModel = new LoginResponeModel();

            //login success
            if (userRepository.IsValidUser(model.Username, model.Password))
            {
                Result = new SuccessResultFactory().Factory(ActionType.Login);

                LoginResponeModel.TokenExpireDate = DateTime.Now.AddDays(1);
                LoginResponeModel.Token = TokenProvider.GenerateTokenString(model.ToDictionaryStringString());
                LoginResponeModel.User = userRepository.GetDataTransferByUsername(model.Username);
            }
            else //login fail
            {
                Result = new ErrorResultFactory().Factory(ActionType.Login);
            }

            //set data
            Data = LoginResponeModel;

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Get()
        {
            Data = userRepository.Get().ToList();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(UserDeleteRequestModel model)
        {
            var user = userRepository.GetByUsername(model.Username);

            if (user != null)
            {
                user.IsActive = false; //Set user to in active

                user.InitBeforeSave(RequestUsername, InitType.Update);

                int result = userRepository.Update(user);

                if (result > 0)
                {
                    Result = new SuccessResult(ActionType.Delete, AppGlobal.DeleteSuccess);
                    Data = user;
                }
                else
                {
                    Result = new ErrorResult(ActionType.Delete, AppGlobal.DeleteError);
                    Data = user;
                }
            }
            else
            {
                string message = "Người dùng không tồn tại trong hệ thống";
                Result = new ErrorResult(ActionType.Login, message);
            }

            return GetCommonRespone();
        }
    }
}