using SEODemo.Services.EngineStrategies;
using SEODemo.Test.StrategyTests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SEODemo.Test.StrategyTests
{
    public class BingStrategyTests
    {
        private readonly BingStrategy _strategy;

        public BingStrategyTests()
        {
            _strategy = new BingStrategy(50);
        }

        [Theory]
        [InlineData("test", 10, 1, "https://www.bing.com/search?q=test&count=10&first=1")]
        [InlineData("online+title+search", 10, 11, "https://www.bing.com/search?q=online+title+search&count=10&first=11")]
        public void GenerateUrl_EqualTest(string query, int itemsPerPage, int first, string expectedUrl)
        {
            Assert.Equal(expectedUrl, _strategy.GenerateUrl(query, itemsPerPage, first));
        }

        [Theory]
        [ClassData(typeof(EmptyTaskListTestData))]
        public void GenerateStringFromTasks_EmptyListTest(List<Task<List<int>>> tasks, string expected)
        {
            Assert.Equal(expected, _strategy.GenerateStringFromTasks(tasks));
        }

        [Theory]
        [ClassData(typeof(TaskListTestData))]
        public void GenerateStringFromTasks_EqualTest(List<Task<List<int>>> tasks, string expected)
        {
            Assert.Equal(expected, _strategy.GenerateStringFromTasks(tasks));
        }
    }
}
