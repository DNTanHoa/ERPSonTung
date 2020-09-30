using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Model.Extensions;
using ERP.Model.Models;
using ERP.MVC.Models;
using ERP.MVC.Models.Employee;
using ERP.Repository;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEntityCenterRepository entityCenterRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                  IEntityCenterRepository entityCenterRepository)
        {
            this.employeeRepository = employeeRepository;
            this.entityCenterRepository = entityCenterRepository;
        }

        public IActionResult Index(EmployeeFilterModel model)
        {
            return View(model);
        }

        public IActionResult Detail(long Id, bool HasLayout = false)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            var model = employee.MapTo<EmployeeDetailModel>();
            if (HasLayout)
            {
                return View(model);
            }
            else
            {
                return PartialView("~/Views/Employee/_Detail.cshtml",model);
            }
        }

        public IActionResult Contact(long Id, bool HasLayout = false)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            var model = employee.MapTo<EmployeeContactDetailModel>();
            if (HasLayout)
            {
                return View(model);
            }
            else
            {
                return PartialView("~/Views/Employee/_Contact.cshtml", model);
            }
        }

        public IActionResult Identity(long Id, bool HasLayout = false)
        {
            var employee = employeeRepository.GetById(Id) ?? new Model.Models.Employee();
            var model = employee.MapTo<EmployeeIdentityDetailModel>();
            if (HasLayout)
            {
                return View(model);
            }
            else
            {
                return PartialView("~/Views/Employee/_Identity.cshtml", model);
            }
        }

        public IActionResult GetDataTransfer()
        {
            return Json(employeeRepository.GetDataTransfer());
        }

        public IActionResult GetDataTransferHasFilter(EmployeeFilterModel filterModel)
        {
            return Json(employeeRepository.GetDataTransferHasFilter(filterModel.DepartmentCode, filterModel.GroupCode, filterModel.LaborGroupCode, filterModel.StatusCode, filterModel.StartFromDate, filterModel.StartToDate));
        }

        public IActionResult GetModelTemplates()
        {
            return Json(employeeRepository.GetModelTemplates());
        }

        public ActionResult<BaseResponeModel> SaveChange(EmployeeDetailModel model)
        {
            BaseResponeModel response = new BaseResponeModel();
            var databaseObject = new Employee();
            int result;
            
            if(model.Id == 0)
            {
                databaseObject = model.MapTo<Employee>();

                if(string.IsNullOrEmpty(databaseObject.Code))
                {
                    var code = entityCenterRepository.GetCodeByEntity(nameof(Employee));

                    if(string.IsNullOrEmpty(code))
                    {
                        response = response.SetStatus(AppGlobal.Error).SetMessage(AppGlobal.MakeCodeError);
                        return response;
                    }

                    databaseObject.Code = code;
                }    

                if(employeeRepository.IsExistCode(databaseObject.Code))
                {
                    response = response.SetStatus(AppGlobal.Error).SetMessage(AppGlobal.ExistCodeError);
                    return response;
                }    

                databaseObject.InitBeforeSave(RequestUsername, InitType.Create);
                databaseObject.InitDefault();
                result = employeeRepository.Insert(databaseObject);
            }
            else
            {
                databaseObject = employeeRepository.GetById(model.Id);
                databaseObject.MapFrom(model);
                databaseObject.InitBeforeSave(RequestUsername, InitType.Update);
                databaseObject.InitDefault();
                result = employeeRepository.Update(databaseObject);
            }
            
            if(result > 0)
            {
                response.SetStatus(AppGlobal.Success).SetMessage(AppGlobal.SaveChangeSuccess);
            }
            else
            {
                response.SetStatus(AppGlobal.Error).SetMessage(AppGlobal.SaveChangeFalse);
            }

            return response;
        }

        public ActionResult<BaseResponeModel> SaveChangeContact(EmployeeContactDetailModel model)
        {
            BaseResponeModel response = new BaseResponeModel();
            var databaseObject = new Employee();
            int result;
            if (model.Id == 0)
            {
                response.SetStatus(AppGlobal.Error).SetMessage("Mã nhân viên không tồn tại");
                return response;
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
                response.SetStatus(AppGlobal.Success).SetMessage(AppGlobal.SaveChangeSuccess);
            }
            else
            {
                response.SetStatus(AppGlobal.Error).SetMessage(AppGlobal.SaveChangeFalse);
            }

            return response;
        }
    }
}
