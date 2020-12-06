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

        //add db things
        public EngineService()
        {
            //repo
        }

        public async Task<string> GetSEOResult(string query, string target)
        {
            return await _engineStrategy.GetSEOResult(query, target);
            //repo.save
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
            catch (Exception ex)
            {
                //log
                throw new Exception(String.Format("Failed to create engine strategy for engine : {0}, scope : {1}", engine, scope));
            }
        }
    }
}
