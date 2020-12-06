using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEODemo.Services.EngineStrategies
{
    /// <summary>
    /// This is used for InfoTrack Test static google pages.
    /// </summary>
    public class InfoTrackGoogleStrategy : EngineStrategy
    {
        // The number of entries on test pages are fixed.
        private readonly int _itemsPerPage = 10;
        public InfoTrackGoogleStrategy(int scope) : base(scope)
        {
            _entryRegex = "<div class=\"g\">.*?</a>";
            _baseUrl = "https://infotrack-tests.infotrack.com.au/Google/Page{0}.html";
        }
        public override async Task<string> GetSEOResult(string query, string target)
        {
            int pages = _scope % _itemsPerPage == 0 ? _scope / _itemsPerPage : _scope / _itemsPerPage + 1;
            List<Task<List<int>>> tasks = new List<Task<List<int>>>();
            for(int pageNum = 1; pageNum < pages; pageNum++)
            {
                var url = GenerateUrl(pageNum);
                tasks.Add(SearchAsync(target, url));
            }

            await Task.WhenAll(tasks.ToArray());

            return GenerateStringFromTasks(tasks);
        }

        //For the static pages, we do not need to pass the query parameter
        public string GenerateUrl(int pageNum) => String.Format(_baseUrl, pageNum.ToString("D2"));

        public string GenerateStringFromTasks(List<Task<List<int>>> tasks)
        {
            List<int> records = null;
            for (int i = 0; i < tasks.Count; i++)
            {
                if(records == null)
                {
                    records = tasks[i].Result.Select(r => r + _itemsPerPage * i).ToList();
                }
                else
                {
                    records = records.Concat(tasks[i].Result.Select(r => r + _itemsPerPage * i)).ToList();
                }
            }
            if(records == null || records.Count() == 0)
            {
                return "0";
            }
            return String.Join(", ", records.Where(r => r <= _scope));
        }
    }
}
