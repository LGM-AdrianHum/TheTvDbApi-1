using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheTvDbApi.Series;

namespace TheTvDbApi.Tests {
    [TestClass]
    public class SeriesClientTests {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void GetTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.Get(295515);

            Assert.AreEqual( 295515, result.Id );
            Assert.AreEqual( "Quantico", result.SeriesName );
            Assert.AreEqual( 196122, result.SeriesId );
            Assert.AreEqual( "ABC (US)", result.Network );
        }

        [TestMethod]
        public void GetImagesForPostersTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.GetImages(295515, ImageTypes.Poster);
            Assert.AreEqual( 6, result.Count() );
        }

        [TestMethod]
        public void GetImagesForFanartTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.GetImages(295515, ImageTypes.Fanart);
            Assert.AreEqual( 10, result.Count() );
        }

        [TestMethod]
        public void GetImagesForSeasonTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.GetImages(295515, ImageTypes.Season);
            Assert.AreEqual( 8, result.Count() );
        }

        [TestMethod]
        public void GetImagesForSeriesTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.GetImages(295515, ImageTypes.Series);
            Assert.AreEqual( 3, result.Count() );
        }

        [TestMethod]
        public void GetEpisodesForSeriesTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SeriesClient.GetSeasonsAndEpisodes(72129);
            Assert.AreEqual( 3, result.Count() );
            Assert.AreEqual( 14, result.ElementAt( 1 ).EpisodeList.Count() );
        }
    }
}
