using SEODemo.Data.Models;
using SEODemo.Data.Repositories;
using SEODemo.Services.EngineStrategies;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Services
{
    public class EngineService : IEngineService
    {
        public EngineStrategy _engineStrategy;
        private readonly ISEORepository _repo;

        public EngineService(ISEORepository repo)
        {
            _repo = repo;
        }

        public async Task<string> GetSEOResult(string query, string target, string engine)
        {
            var result = await _engineStrategy.GetSEOResult(query, target);
            await _repo.AddAsync(new SEOResult
            {
                Query = query,
                Target = target,
                Engine = engine,
                Result = result,
                DateTime = DateTime.Now
            });
            return result;
        }

        public void SetEngineStrategy(string engine, int scope)
        {
            _engineStrategy = GetEngineStrategy(engine, scope);
        }

        private EngineStrategy GetEngineStrategy(string engine, int scope)
        {
            Object[] args = { scope };
            try
            {
                return (EngineStrategy)Activator.CreateInstance(Type.GetType($"SEODemo.Services.EngineStrategies.{engine}Strategy"), args);
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Failed to create engine strategy for engine : {0}, scope : {1}", engine, scope));
            }
        }

        public IEnumerable<SEOResult> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
