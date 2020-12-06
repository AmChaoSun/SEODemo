using SEODemo.Services.EngineStrategies;
using SEODemo.Test.StrategyTests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SEODemo.Test.StrategyTests
{
    public class InfoTrackGoogleStrategyTests
    {
        private readonly InfoTrackGoogleStrategy _strategy;

        public InfoTrackGoogleStrategyTests()
        {
            _strategy = new InfoTrackGoogleStrategy(50);
        }

        [Theory]
        [InlineData(1, "https://infotrack-tests.infotrack.com.au/Google/Page01.html")]
        [InlineData(10, "https://infotrack-tests.infotrack.com.au/Google/Page10.html")]
        public void GenerateUrl_EqualTest(int pageNum, string expectedUrl)
        {
            Assert.Equal(expectedUrl, _strategy.GenerateUrl(pageNum));
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
