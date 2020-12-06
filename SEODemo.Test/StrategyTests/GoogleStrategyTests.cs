using SEODemo.Services.EngineStrategies;
using SEODemo.Test.StrategyTests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEODemo.Test.StrategyTests
{
    public class GoogleStrategyTests
    {
        private readonly GoogleStrategy _strategy;

        public GoogleStrategyTests()
        {
            _strategy = new GoogleStrategy(50);
        }

        [Theory]
        [InlineData("online+title+search", 50, "https://www.google.com/search?q=online+title+search&num=50")]
        public void GenerateUrl_EqualTest(string query, int scope, string expectedUrl)
        {
            Assert.Equal(expectedUrl, _strategy.GenerateUrl(query, scope));
        }

        [Theory]
        [ClassData(typeof(RecordListTestData))]
        public void GenerateStringFromList_EqualTest(List<int> list, string expected)
        {
            Assert.Equal(expected, _strategy.GenerateStringFromList(list));
        }
    }
}
