using SEODemo.Services;
using SEODemo.Services.EngineStrategies;
using SEODemo.Test.EngineServiceTests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEODemo.Test.EngineServiceTests
{
    public class EngineServiceTests
    {
        private readonly EngineService _service;

        public EngineServiceTests()
        {
            _service = new EngineService();
        }

        [Theory]
        [ClassData(typeof(SetEngineStrategyEqualData))]
        public void SetEngineStrategy_EqualTests(string engine, int scope, EngineStrategy strategy)
        {
            _service.SetEngineStrategy(engine, scope);
            Assert.IsType(strategy.GetType(), _service._engineStrategy);
        }

        [Theory]
        [InlineData("wrongEngine", 50)]
        public void SetEngineStrategy_ExceptionTests(string engine, int scope)
        {
            var exception = Assert.Throws<Exception>(() => _service.SetEngineStrategy(engine, scope));
            Assert.Equal(exception.Message, String.Format("Failed to create engine strategy for engine : {0}, scope : {1}", engine, scope));
        }
    }
}
