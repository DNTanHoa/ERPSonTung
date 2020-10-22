using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeContractController : ControllerBase
    {
        private readonly IEmployeeContractRepository employeeContractRepository;

        public EmployeeContractController(IEmployeeContractRepository employeeContractRepository)
        {
            this.employeeContractRepository = employeeContractRepository;
        }
    }
}
