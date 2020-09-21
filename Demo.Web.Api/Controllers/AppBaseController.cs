using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Demo.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        public string UserId
        {
            get
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return userId;
            }
        }
    }
}
