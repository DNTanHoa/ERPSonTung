using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Repository;
using ERP.ResponeModel;
using ERP.Ultilities.Enum;
using ERP.Ultilities.Factory.Implement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EntityCenterController : BaseController
    {
        private readonly IEntityCenterRepository entityCenterRepository;

        public EntityCenterController(IEntityCenterRepository entityCenterRepository)
        {
            this.entityCenterRepository = entityCenterRepository;
        }

        [HttpGet]
        public ActionResult<CommonResponeModel> Get()
        {
            Data = entityCenterRepository.Get();
            Result = new SuccessResultFactory().Factory(ActionType.Select);
            return GetCommonRespone();
        }
    }
}
