using ERP.Helpers;
using ERP.Model.DataTransferObjects;
using ERP.Repository;
using ERP.ResponeModel;
using ERP.TemplateImport;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Factory.Implement;
using ERP.Ultilities.Global;
using ERP.Ultilities.Results;
using ERP.Validators;
using ExcelDataReader;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileImportController : BaseController
    {
        private readonly ILogger<CandidateController> logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICategoryRepository categoryRepository;

        public FileImportController(ILogger<CandidateController> logger,
            IWebHostEnvironment webHostEnvironment,
            ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public ActionResult<CommonResponeModel> CheckFileEmployees([FromForm]IFormFile file)
        {
            if (file == null || string.IsNullOrWhiteSpace(file.FileName))
            {
                Result = new ErrorResult(ActionType.CheckFileExcel, CommonMessageGlobal.Require("File Excel"));
                return GetCommonRespone();
            }

            try
            {
                string path = Path.Combine(AppGlobal.ExcelImportDestFolder, DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName);
                string pathXmlCheck = Path.Combine(AppGlobal.XmlTemplateImportFolder, "Employee.xml");

                //save file to server
                file.SaveTo(path);

                //read file to check
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true // Use first row is ColumnName here 
                            }
                        });

                        if (dataSet.Tables.Count > 0)
                        {
                            SheetTemplateImport templateImport = new SheetTemplateImport(pathXmlCheck);

                            DataTable table = dataSet.Tables[templateImport.SheetName];

                            foreach (var column in templateImport.Columns)
                            {
                                if (!string.IsNullOrWhiteSpace(column.excelHeader))
                                {
                                    table.Columns[column.excelHeader].ColumnName = column.propertyName;
                                }
                            }

                            //validate data
                            var validator = new ImportEmployeeExcelFileValidator(categoryRepository);
                            List<EmployeeImportDataTransfer> employees = table.ToList<EmployeeImportDataTransfer>(true);
                            foreach (var employee in employees)
                            {
                                ValidationResult results = validator.Validate(employee);

                                if (!results.IsValid)
                                {
                                    foreach (var failure in results.Errors)
                                    {
                                        employee.IsError = true;
                                        employee.ErrorMessage.Add(failure.ErrorMessage);
                                    }
                                }
                            }

                            Data = employees;
                        }
                    }
                }

                Result = new SuccessResultFactory().Factory(ActionType.CheckFileExcel);
            }
            catch (Exception)
            {
                Result = new ErrorResultFactory().Factory(ActionType.CheckFileExcel);
            }

            return GetCommonRespone();
        }
    }
}
