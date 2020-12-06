using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Services.EngineStrategies
{
    public class BingStrategy : EngineStrategy
    {
        /// <summary>
        /// We can set how many records we want on each page to improve the performance.
        /// Neither retriving too many records at once nor managing too many threads is a good approach.
        /// Here I set it as 10.
        /// </summary>
        private readonly int _itemsPerPage = 10;
        public BingStrategy(int scope) : base(scope)
        {
            _entryRegex = "class=\"b_algo\">.*?</a>";
            _baseUrl = "https://www.bing.com/search?q={0}&count={1}&first={2}";
        }
        public override async Task<string> GetSEOResult(string query, string target)
        {
            int pages = _scope % _itemsPerPage == 0 ? _scope / _itemsPerPage : _scope / _itemsPerPage + 1;
            List<Task<List<int>>> tasks = new List<Task<List<int>>>();
            for (int pageNum = 1; pageNum < pages; pageNum++)
            {
                var url = GenerateUrl(query, _itemsPerPage, _itemsPerPage * (pageNum - 1) + 1);
                tasks.Add(SearchAsync(target, url));
            }

            await Task.WhenAll(tasks.ToArray());

            return GenerateStringFromTasks(tasks);
        }

        //For the static pages, we do not need to pass the query parameter
        public string GenerateUrl(string query, int itemsPerPage, int first) => String.Format(_baseUrl, query, itemsPerPage, first);

        public string GenerateStringFromTasks(List<Task<List<int>>> tasks)
        {
            List<int> records = null;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (records == null)
                {
                    records = tasks[i].Result.Select(r => r + _itemsPerPage * i).ToList();
                }
                else
                {
                    records = records.Concat(tasks[i].Result.Select(r => r + _itemsPerPage * i)).ToList();
                }
            }
            if (records == null || records.Count() == 0)
            {
                return "0";
            }
            return String.Join(", ", records.Where(r => r <= _scope));
        }
    }
}
