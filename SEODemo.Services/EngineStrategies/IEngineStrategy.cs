using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Services.EngineStrategies
{
    interface IEngineStrategy
    {
        public Task<string> GetSEOResult(string query, string target);
    }
}
