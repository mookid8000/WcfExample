using Moq;
using NUnit.Framework;
using Server.AppServices.Api;
using Server.Handlers.ServerVersion;

namespace Server.Tests.Handlers.ServerVersion
{
    [TestFixture]
    public class TestQueryServerVersionHandler
    {
        QueryServerVersionHandler handler;
        Mock<IDetermineServerVersion> determineServerVersion;

        [SetUp]
        public void SetUp()
        {
            // Shows how the handler is completely decoupled from its surroundings, allowing it to be unit tested properly
            determineServerVersion = new Mock<IDetermineServerVersion>();
            handler = new QueryServerVersionHandler(determineServerVersion.Object);
        }

        [Test]
        public void CanDetermineVersionOfServer()
        {
            // Example on how a handler can be tested, stubbing a return value on the dependency,
            // following the classic AAA pattern

            // arrange
            determineServerVersion.Setup(d => d.GetVersionString()).Returns("v. 0.9 beta something");

            // act
            var response = (QueryServerVersionResponse)handler.Process(new QueryServerVersionRequest());

            // assert
            Assert.That(response.Version, Is.EqualTo("v. 0.9 beta something"));
        }
    }
}
