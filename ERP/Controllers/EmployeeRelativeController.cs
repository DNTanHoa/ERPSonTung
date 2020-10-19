using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.EmployeeRelative;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeRelativeController : BaseController
    {
        #region constructor

        private readonly IEmployeeRelativeRepository _employeeRelativeRepository;

        public EmployeeRelativeController(IEmployeeRelativeRepository employeeRelativeRepository)
        {
            this._employeeRelativeRepository = employeeRelativeRepository;
        }

        #endregion constructor

        #region public method

        /// <summary>
        /// get filtered list employee relative
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CommonResponeModel> Get(string employeeCode)
        {
            var result = this._employeeRelativeRepository.GetFilteredItems(employeeCode);

            Data = result;
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }



        [HttpGet]
        public ActionResult<CommonResponeModel> GetById(long id)
        {
            var currentObj = this._employeeRelativeRepository.GetById(id);

            if (currentObj == null || currentObj.Deleted==true)
            {
                Result = new ErrorResult(ActionType.Select, "Lỗi 404");

            }

            Data = currentObj;
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        /// <summary>
        /// Add and update employee relative
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CommonResponeModel> SaveChange(EmployeeRelativeRequest request)
        {
            if (!ModelState.IsValid)
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Result = new ErrorResult(ActionType.Insert, message);
                return GetCommonRespone();
            }
            else
            {
                var result = 0;

                var model = request.MapTo<EmployeeRelative>();

                if (model.Id == 0)
                {
                    model.InitBeforeSave(RequestUsername, InitType.Create);
                    result = this._employeeRelativeRepository.Insert(model);
                }
                else
                {
                    var currentObj = this._employeeRelativeRepository.GetItemById(model.Id);

                    if (currentObj != null)
                    {
                        model.InitBeforeSave(RequestUsername, InitType.Update);
                        result = this._employeeRelativeRepository.Update(model);
                    }
                    else
                    {
                        Result = new ErrorResult(ActionType.Select, "Lỗi 404");
                    }
                }

                if (result > 0)
                {
                    Result = new SuccessResult(ActionType.Insert, AppGlobal.SaveChangeSuccess);
                }
                else
                {
                    Result = new ErrorResult(ActionType.Insert, AppGlobal.SaveChangeFalse);
                }

                return GetCommonRespone();
            }
        }

        /// <summary>
        /// deleted a object set deleted is true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<CommonResponeModel> Delete(long id)
        {
            var result = 0;

            var currentObj = this._employeeRelativeRepository.GetById(id);

            if (currentObj != null && currentObj.Deleted==false)
            {
                currentObj.Deleted = true;
                result = this._employeeRelativeRepository.Update(currentObj);
            }
            else
            {
                Result = new ErrorResult(ActionType.Select, "Lỗi 404");
            }

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Delete, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Delete, AppGlobal.SaveChangeFalse);
            }

            return GetCommonRespone();
        }

        #endregion public method
    }
}