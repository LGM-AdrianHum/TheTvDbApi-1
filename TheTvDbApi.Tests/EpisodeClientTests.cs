using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheTvDbApi.Tests {
    [TestClass]
    public class EpisodeClientTests {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void GetTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.EpisodeClient.Get(337065);

            Assert.AreEqual( 337065, result.Id );
            Assert.AreEqual( 2, result.AiredEpisodeNumber );
            Assert.AreEqual( "3T6601", result.ProductionCode );
            Assert.AreEqual( "The Big Bran Hypothesis", result.EpisodeName );
            Assert.AreEqual( "Mark Cendrowski", result.Director );
        }
    }
}
