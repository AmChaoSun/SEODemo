using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public SEOController(IEngineService service, IOptions<SEOSettingsModel> appSettings)
        {
            _service = service;
            _appSettings = appSettings;
        }

        //urlencode
        [HttpGet]
        public int Get()
        {
            var a = _appSettings.Value.Scope;
            return a;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] SEORequest request)
        {
            _service.SetEngineStrategy(request.Engine, _appSettings.Value.Scope);
            var query = WebUtility.UrlEncode(request.Input);
            return await _service.GetSEOResult(query, request.Target);
        }
    }
}
