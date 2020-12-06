using SEODemo.Services.EngineStrategies;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEODemo.Test.EngineServiceTests.TestData
{
    public class SetEngineStrategyEqualData : TheoryData<string, int, EngineStrategy>
    {
        public SetEngineStrategyEqualData()
        {
            Add("Bing", 50, new BingStrategy(50));
            Add("Google", 50, new GoogleStrategy(50));
            Add("InfoTrackGoogle", 50, new InfoTrackGoogleStrategy(50));
        }
    }
}
