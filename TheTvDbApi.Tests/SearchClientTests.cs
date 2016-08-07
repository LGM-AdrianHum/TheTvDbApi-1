using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheTvDbApi.Tests {
    [TestClass]
    public class SearchClientTests {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void SearchTest() {
            var client = new TheTvDbClient(Apikey);
            var result = client.SearchClient.Search( "quantico" ).ToList();
            
            Assert.AreEqual(1, result.Count );
            Assert.AreEqual(295515, result[0].Id);
        }
    }
}
