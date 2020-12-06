using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Services.EngineStrategies
{
    /// <summary>
    /// This is for live google search. 
    /// We are going to use query parameters in the url.
    /// Since we have tried multiple thread with the static test pages,
    /// here we try to retrive all the required entried with one request to Google
    /// </summary>
    public class GoogleStrategy : EngineStrategy
    {
        public GoogleStrategy(int scope) : base(scope)
        {
            _entryRegex = "<div class=\"g\">.*?</a>";
            _baseUrl = "https://www.google.com/search?q={0}&num={1}";
        }
        public override async Task<string> GetSEOResult(string query, string target)
        {
            var url = GenerateUrl(query, _scope);
            var records = await SearchAsync(target, url);
            return GenerateStringFromList(records);
        }

        public string GenerateUrl(string query, int scope) => String.Format(_baseUrl, query, scope);

        public string GenerateStringFromList(List<int> list) => list.Count == 0? "0": String.Join(", ", list);
    }
}
