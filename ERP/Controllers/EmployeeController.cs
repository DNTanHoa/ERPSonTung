using ERP.Helpers;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.Repository;
using ERP.RequestModel.Employee;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEntityCenterRepository entityCenterRepository;
        private readonly IWebHostEnvironment _env;


        public EmployeeController(IEmployeeRepository employeeRepository,
                                  IEntityCenterRepository entityCenterRepository,
                                    IWebHostEnvironment env)
        {
            this.employeeRepository = employeeRepository;
            this.entityCenterRepository = entityCenterRepository;
            this._env = env;
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Detail(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Employee();
            Data = employee.MapTo<EmployeeDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Contact(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Employee();
            Data = employee.MapTo<EmployeeContactDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Identity(long Id)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            Data = employee.MapTo<EmployeeIdentityDetailResponeModel>();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransfer()
        {
            Data = employeeRepository.GetDataTransfer();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetDataTransferHasFilter(EmployeeFilterRequestModel filterModel)
        {
            Data = employeeRepository.GetDataTransferHasFilter(filterModel?.DepartmentCode, filterModel?.GroupCode, filterModel?.LaborGroupCode, filterModel?.StatusCode, filterModel?.StartFromDate, filterModel?.StartToDate);
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> GetModelTemplates()
        {
            Data = employeeRepository.GetModelTemplates();
            Result = new SuccessResultFactory().Factory(ActionType.Select);

            return GetCommonRespone();
        }


        [HttpDelete]
        public ActionResult<CommonResponeModel> DeleteByCode(string Code)
        {
            int result = employeeRepository.Delete(Code);

            if (result > 0)
            {
                Result = new SuccessResultFactory().Factory(ActionType.Delete);
            }
            else
            {
                Result = new ErrorResultFactory().Factory(ActionType.Delete);
            }

            return GetCommonRespone();
        }

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChange([FromForm] EmployeeSaveChangeRequestModel model)
        {
            var databaseObject = new Employee();
            int result;

            if (model.Id == 0)
            {
                databaseObject.MapFrom(model);

                if (string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(Employee));

                    if (string.IsNullOrEmpty(code))
                    {
                        Result = new ErrorResult(ActionType.Insert, AppGlobal.MakeCodeError);
                        return GetCommonRespone();
                    }

                    databaseObject.Code = code;
                }

                if (employeeRepository.IsExistCode(databaseObject.Code))
                {
                    Result = new ErrorResult(ActionType.Insert, CommonMessageGlobal.Exist("Mã nhân viên"));
                    return GetCommonRespone();
                }

                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                databaseObject.InitDefault();

                //lưu hình nếu tồn tại
                if (model.ImageFile != null && string.IsNullOrWhiteSpace(model.ImageFile.FileName))
                {
                    model.ImageFile.SaveTo(AppGlobal.AvatarFolder);
                    databaseObject.Image = Path.Combine(AppGlobal.AvatarFolder, model.ImageFile.FileName);
                }

                result = employeeRepository.Insert(databaseObject);
            }
            else
            {
                databaseObject = employeeRepository.GetById(model.Id);
                databaseObject.MapFrom(model);
                databaseObject.InitBeforeSave(RequestUsername, InitType.Update);
                databaseObject.InitDefault();

                //lưu hình nếu tồn tại
                if (model.ImageFile != null && !string.IsNullOrWhiteSpace(model.ImageFile.FileName))
                {
                    var pathFolder = $@"\Storages\Avatars";
                    var folder = this._env.WebRootPath + pathFolder;
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string filePath = Path.Combine(folder, model.ImageFile.FileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        model.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }

                    databaseObject.Image = Path.Combine(pathFolder, model.ImageFile.FileName).Replace(@"\", @"/");
                }

                result = employeeRepository.Update(databaseObject);
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

        [HttpPost]
        [ApiValidationFilter]
        public ActionResult<CommonResponeModel> SaveChangeContact(EmployeeContactDetailRequestModel model)
        {
            var databaseObject = new Employee();
            int result;

            if (model.Id == 0)
            {
                Result = new ErrorResult(ActionType.Insert, CommonMessageGlobal.NotExist("Mã nhân viên"));
                return GetCommonRespone();
            }
            else
            {
                databaseObject = employeeRepository.GetById(model.Id);
                databaseObject.MapFrom(model);
                databaseObject.InitBeforeSave(RequestUsername, InitType.Update);
                databaseObject.InitDefault();

                result = employeeRepository.Update(databaseObject);
            }

            if (result > 0)
            {
                Result = new SuccessResult(ActionType.Edit, AppGlobal.SaveChangeSuccess);
            }
            else
            {
                Result = new ErrorResult(ActionType.Edit, AppGlobal.SaveChangeFalse);
            }

            return GetCommonRespone();
        }
    }
}
