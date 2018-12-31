using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiWithSecurity.Controllers
{
    [Route("[controller]")]
    public class StatusCodeController : Controller
    {
        private ILogger<StatusCodeController> _iLogger;

        public StatusCodeController(ILogger<StatusCodeController> ilogger)
        {
            _iLogger = ilogger;
        }

        [HttpGet("/StatusCode/{StatusCode}")]
        public IActionResult Index(int statusCode)
        {
            var reExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            _iLogger.LogInformation("Unexpected StatusCode:{StatusCode}, page: {OriginalPath})", statusCode, reExecuteFeature.OriginalPath);
            return View(statusCode);
        }
    }
}