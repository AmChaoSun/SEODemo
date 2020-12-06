using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEODemo.Test.StrategyTests.TestData
{
    public class RecordListTestData : TheoryData<List<int>, string>
    {
        public RecordListTestData()
        {
            Add(new List<int>(), "0");
            Add(new List<int> { 1, 15, 45 }, "1, 15, 45");
        }
    }
}
