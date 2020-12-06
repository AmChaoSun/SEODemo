using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SEODemo.Test.StrategyTests.TestData
{
    public class EmptyTaskListTestData : TheoryData<List<Task<List<int>>>, string>
    {
        public EmptyTaskListTestData()
        {
            Add(new List<Task<List<int>>>(), "0");
            Add(new List<Task<List<int>>> { Task.Run(() => new List<int>()), Task.Run(() => new List<int>()) }, "0");
        }
    }
}
