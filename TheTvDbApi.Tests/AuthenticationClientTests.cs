using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheTvDbApi.Tests {
    [TestClass]
    public class AuthenticationClientTests {
        private const string Apikey = "8101D1A289918B8A";

        [TestMethod]
        public void LoginTest() {
            var client = new TheTvDbClient(Apikey);
            Assert.IsFalse(string.IsNullOrEmpty( client.AuthenticationClient.Token ) );
        }
        [TestMethod]
        public void RefreshTokenTest() {
            var client = new TheTvDbClient(Apikey);
            var token1 = client.AuthenticationClient.Token;
            Thread.Sleep(200);
            client.AuthenticationClient.RefreshToken();
            var token2 = client.AuthenticationClient.Token;
            Assert.AreNotEqual(token1, token2);
        }
    }
}
