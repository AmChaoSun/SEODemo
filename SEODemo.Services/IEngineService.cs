using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Services
{
    public interface IEngineService
    {
        public void SetEngineStrategy(string engine, int scope);
        public Task<string> GetSEOResult(string query, string target);
    }
}
