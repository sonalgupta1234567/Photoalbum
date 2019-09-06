using System;
using Marvel.Services.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarvelApiClientTests.Utility
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void GivenHash_WhenGetHashIsCalled_ReturnsHash()
        {
            //arrange
            var hash = new Hash();
            var expectedOutput = "8835f8511e16514163d7ec0eeddacf03";

            //act
            var result = hash.GetHash("09/09/2019 00:00:00", "privatekey", "publickey");

            //assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
