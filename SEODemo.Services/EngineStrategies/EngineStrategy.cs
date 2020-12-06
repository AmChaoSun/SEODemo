using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEODemo.Services.EngineStrategies
{
    public abstract class EngineStrategy : IEngineStrategy
    {
        static readonly HttpClient _client = new HttpClient();

        // <summary>
        /// The number of records being searched
        /// </summary>
        protected readonly int _scope;

        protected string _entryRegex;
        protected string _baseUrl;
        public EngineStrategy(int scope)
        {
            _scope = scope;
        }

        //virtual methods
        public virtual async Task<string> GetHTMLContent(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public virtual MatchCollection GetEntries(string html, string entryRegex) => Regex.Matches(html, entryRegex);

        public virtual List<int> GetTargetRecords(MatchCollection entries, string target)
        {
            var result = new List<int>();
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Value.Contains(target))
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }
       
        public virtual async Task<List<int>> SearchAsync(string target, string url)
        {
            try
            {
                var content = await GetHTMLContent(url);
                var entries = GetEntries(content, _entryRegex);
                return GetTargetRecords(entries, target);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual string GenerateUrl() => _baseUrl;

        //Interface method
        public abstract Task<string> GetSEOResult(string query, string target);
    }
}
