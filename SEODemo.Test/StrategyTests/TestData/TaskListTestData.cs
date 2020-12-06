using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SEODemo.Test.StrategyTests.TestData
{
    public class TaskListTestData : TheoryData<List<Task<List<int>>>, string>
    {
        public TaskListTestData()
        {
            Add(new List<Task<List<int>>> { Task.Run(() => new List<int> { 1 }), Task.Run(()=> new List<int>()), Task.Run(() => new List<int> { 2}) }, "1, 22");
            Add(new List<Task<List<int>>> { Task.Run(() => new List<int>{ 1 }), 
                Task.Run(() => new List<int> { 1 }),
                Task.Run(() => new List<int> { 1 }),
                Task.Run(() => new List<int> { 1 }),
                Task.Run(() => new List<int> { 1 }),
                Task.Run(() => new List<int> { 1 }),
            },"1, 11, 21, 31, 41");
        }
    }
}
