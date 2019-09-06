using System;
using Marvel.Services;
using Marvel.Services.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace MarvelApiClientTests
{
    [TestClass]
    public class TimeStampTests
    {
        private ISystemClock _clock;
        private ITimeStamp _timeStamp;
        [TestInitialize]
        public void TestInit()
        {
            _clock = MockRepository.GenerateMock<ISystemClock>();
            _clock.Stub(c => c.Now).Return(DateTime.Now);
            _timeStamp = new TimeStamp(_clock);
        }

        [TestMethod]
        public void GivenTimestamp_WhenGetTimeStampIsCalled_ReturnsTimeStamp()
        {
            
            var expected = _clock.Now.ToString("yyyyMMddHHmmssffff");
         
            //act
            var result = _timeStamp.GetTimestamp();

            //assert
            Assert.AreEqual(expected,result);
        }
    }
}
