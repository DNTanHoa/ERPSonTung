﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ERP.Ultilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        BaseResult Result;

        public string RequestUsername
        {
            get
            {
                return this.RequestUserClaims.Where(p => p.Type == "Username").FirstOrDefault()?.Value;
            }
        }

        public IEnumerable<Claim> RequestUserClaims
        {
            get
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                    return identity.Claims;
                return null;
            }
        }
    }
}
