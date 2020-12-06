using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SEODemo.Models;
using SEODemo.Services;

namespace SEODemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SEOController : ControllerBase
    {
        private readonly IEngineService _service;
        private readonly IOptions<SEOSettingsModel> _appSettings;
        private readonly ILogger _logger;
        public SEOController(IEngineService service, IOptions<SEOSettingsModel> appSettings, ILogger<SEOController> logger)
        {
            _service = service;
            _appSettings = appSettings;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public async Task<string> Post([FromBody] SEORequest request)
        {
            try
            {
                _service.SetEngineStrategy(request.Engine, _appSettings.Value.Scope);
                var query = WebUtility.UrlEncode(request.Input);
                return await _service.GetSEOResult(query, request.Target, request.Engine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "Internal Error";
            }
            
        }
    }
}
